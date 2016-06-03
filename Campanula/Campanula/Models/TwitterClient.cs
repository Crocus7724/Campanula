using Aster;
using CoreTweet;

namespace Campanula.Models
{
    public class TwitterClient:NotificationObject
    {
        public static TwitterClient Current { get; }=new TwitterClient();

        #region User 変更通知プロパティ

        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public OAuth.OAuthSession Session { get; }

        public TwitterClient()
        {
            User=new User();

            Session = OAuth.AuthorizeAsync(TwitterKeys.ConsumerKey, TwitterKeys.ConsumerSecret).Result;
        }
    }
}