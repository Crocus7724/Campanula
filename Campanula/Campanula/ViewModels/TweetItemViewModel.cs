using System;
using Aster;
using Campanula.Models;

namespace Campanula.ViewModels
{
    public class TweetItemViewModel:NotificationObject
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

        #region CreatedAt 変更通知プロパティ

        private DateTimeOffset _createdAt;

        public DateTimeOffset CreatedAt
        {
            get { return _createdAt; }
            set
            {
                _createdAt = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Text 変更通知プロパティ

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region IsRetweet 変更通知プロパティ

        private bool _isRetweet;

        public bool IsRetweet
        {
            get { return _isRetweet; }
            set
            {
                _isRetweet = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region RetweetedUserName 変更通知プロパティ

        private string _retweetedUserName;

        public string RetweetedUserName
        {
            get { return _retweetedUserName; }
            set
            {
                _retweetedUserName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public TweetItemViewModel(Tweeted tweeted)
        {
            if (tweeted.IsRetweeted)
            {
                IsRetweet = true;
                RetweetedUserName = tweeted.Name;
                tweeted = tweeted.Retweeted;
            }
            ScreenName = tweeted.ScreenName;
            Name = tweeted.Name;
            ProfileImageUrl = tweeted.ProfileImageUrl;
            CreatedAt = tweeted.CreatedAt;
            Text = tweeted.Text;
        }
    }
}