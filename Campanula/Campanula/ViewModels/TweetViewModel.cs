using System;
using System.Reactive.Linq;
using Aster;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace Campanula.ViewModels
{
    public class TweetViewModel:ViewModelBase
    {
        #region Text 変更通知プロパティ

        private ReactiveProperty<string> _text;

        public ReactiveProperty<string> Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region TextCount 変更通知プロパティ

        private ReactiveProperty<int> _textCount;

        public ReactiveProperty<int> TextCount
        {
            get { return _textCount; }
            set
            {
                _textCount = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ReactiveCommand SubscribingCommand { get; }

        public TweetViewModel()
        {
            Text=new ReactiveProperty<string>().AddTo(this.CompositeDisposable);

            TextCount=Text
                .Select(x => 140-x.Length)
                .ToReactiveProperty()
                .AddTo(this.CompositeDisposable);

            SubscribingCommand = TextCount
                .Select(x => x > 0 && x < 141)
                .ToReactiveCommand()
                .AddTo(this.CompositeDisposable);

            SubscribingCommand.Subscribe(_ =>
            {

            });
        }
    }
}