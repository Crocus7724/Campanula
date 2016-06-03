using System;
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

        public string Pin { get; set; }

        public ICommand SubmitCommand { get; }

        public OAuthWebPageViewModel()
        {
            SubmitCommand = new Command(() =>
            {
                if (string.IsNullOrEmpty(Pin)) return;

                TwitterClient.Current.User = new User(Pin);

                Messenger.Raise(new TransitionMessage("Pop"));
            });

            
        }
    }
}