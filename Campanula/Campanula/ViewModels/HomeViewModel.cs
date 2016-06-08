using System.Windows.Input;
using Aster;
using Campanula.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Xamarin.Forms;
using Campanula.Extensions;
using User = Campanula.Models.User;

namespace Campanula.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly User _user = TwitterClient.Current.User;
        public ReadOnlyReactiveCollection<TweetItemViewModel> TimeLine { get; private set; }

        public ICommand RefreshCommand { get; }

        #region IsRefreshing 変更通知プロパティ

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public HomeViewModel()
        {
            if (_user.IsExit)
                TimeLine =
                    _user.HomeTimeLine.List
                    .ToReadOnlyReactiveCollection(x => new TweetItemViewModel(x))
                    .AddTo(this.CompositeDisposable);
            
         
            RefreshCommand = new Command(() =>
            {
                IsRefreshing = true;
                _user.HomeTimeLine.Update();
                IsRefreshing = false;
            });
        }

        protected override void Dispose(bool disposing)
        {
            CompositeDisposable.Dispose();

            base.Dispose(disposing);
        }
        
    }
}