using System.Collections.ObjectModel;
using System.Linq;
using Aster;
using Campanula.Models.Database;
using Campanula.Models.Database.Data;
using CoreTweet;

namespace Campanula.Models
{
    public class User:NotificationObject
    {
        #region ScreenName 変更通知プロパティ

        private string _screenName;

        public string ScreenName
        {
            get { return _screenName; }
            set
            {
                _screenName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Name 変更通知プロパティ

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region ProfileImageUrl 変更通知プロパティ

        private string _profileImageUrl;

        public string ProfileImageUrl
        {
            get { return _profileImageUrl; }
            set
            {
                _profileImageUrl = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region HomeTimeLine 変更通知プロパティ

        private HomeTimeLine _homeTimeLine;

        public HomeTimeLine HomeTimeLine
        {
            get { return _homeTimeLine; }
            set
            {
                _homeTimeLine = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region IsExit 変更通知プロパティ

        private bool _isExit;

        public bool IsExit
        {
            get { return _isExit; }
            set
            {
                _isExit = value;
                OnPropertyChanged();
            }
        }

        #endregion
        
        public Tokens Token { get; set; }

        public User()
        {
            var data = RealmHelper.Instance.All<UserData>().ToList().FirstOrDefault(x => x.Current);

            if(data!=null)Initialize(TwitterKeys.GetTokens(data.Id));
        }

        public User(long userId)
        {
            Initialize(TwitterKeys.GetTokens(userId));
        }


        public User(string pin)
        {
            var token = TwitterClient.Current.Session.GetTokensAsync(pin).Result;
            TwitterKeys.SaveTokens(token);
            Initialize(token);
        }

        private void Initialize(Tokens token)
        {
            Token = token;
            ScreenName = token.ScreenName;
            
           HomeTimeLine=new HomeTimeLine(token.Statuses.HomeTimelineAsync(count=>50).Result.Where(x => x!=null).Select(x=>new Tweeted(x)),token.Streaming);
            var user = token.Users.ShowAsync(id => token.UserId).Result;

            Name = user.Name;

            ProfileImageUrl = user.ProfileImageUrl;
            IsExit = true;
        }
    }
}