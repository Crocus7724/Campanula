using System;
using System.Reactive.Linq;
using System.Windows.Input;
using Aster;
using Aster.Messaging;
using Campanula.Models;
using Reactive.Bindings;
using Xamarin.Forms;

namespace Campanula.ViewModels
{
    public class OAuthWebPageViewModel:ViewModelBase
    {
        public Uri AuthorizeUrl { get; } = TwitterClient.Current.Session.AuthorizeUri;

        public ReactiveProperty<string> Pin { get;}=new ReactiveProperty<string>();

        public ReactiveCommand SubmitCommand { get; }

        public OAuthWebPageViewModel()
        {
            SubmitCommand = Pin.Select(string.IsNullOrEmpty)
                .ToReactiveCommand();

            SubmitCommand.Subscribe(_ =>
            {
                TwitterClient.Current.User=new User(Pin.Value);

                Messenger.Raise(new TransitionMessage("Pop"));
            });


        }
    }
}