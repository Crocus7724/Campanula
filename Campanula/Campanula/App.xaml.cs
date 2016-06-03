using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campanula.Models;
using Campanula.Models.Database;
using Campanula.Views;
using Realms;
using Xamarin.Forms;

namespace Campanula
{
    public partial class App : Application
    {
        public App()
        {
            // The root page of your application
            var home=new Home();

            MainPage = new NavigationPage(home);

            Initialize();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async void Initialize()
        {
            if (!TwitterClient.Current.User.IsExit)
            {
                 await MainPage.Navigation.PushModalAsync(new OAuthWebPage());
            }
        }
    }
}
