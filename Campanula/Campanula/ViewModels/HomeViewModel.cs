using System.Diagnostics.Tracing;
using System.Windows.Input;
using Aster;
using Campanula.Models;
using Reactive.Bindings;
using StatefulModel.EventListeners;
using Xamarin.Forms;

namespace Campanula.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {
        private readonly User _user = TwitterClient.Current.User;
        public ReadOnlyReactiveCollection<TweetItemViewModel> TimeLine { get; private set; }

        public ICommand RefreshCommand { get; }

        public HomeViewModel()
        {
            if (_user.IsExit)
                TimeLine = _user.HomeTimeLine.ToReadOnlyReactiveCollection(x => new TweetItemViewModel(x));

            RefreshCommand=new Command(() =>
            {



            });
        }
    }
}