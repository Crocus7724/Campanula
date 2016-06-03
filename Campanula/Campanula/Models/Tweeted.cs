using System;
using Aster;
using CoreTweet;

namespace Campanula.Models
{
    public class Tweeted:NotificationObject
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

        #region IsRetweeted 変更通知プロパティ

        private bool _isRetweeted;

        public bool IsRetweeted
        {
            get { return _isRetweeted; }
            set
            {
                _isRetweeted = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Retweeted 変更通知プロパティ

        private Tweeted _retweeted;

        public Tweeted Retweeted
        {
            get { return _retweeted; }
            set
            {
                _retweeted = value;
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



        public Tweeted(Status status)
        {
            if(status==null)throw new ArgumentNullException(nameof(status));
            ScreenName = status.User.ScreenName;

            Name = status.User.Name;

            ProfileImageUrl = status.User.ProfileImageUrl;

            CreatedAt = status.CreatedAt;

            if (status.RetweetedStatus!=null) IsRetweeted = true;

            if (IsRetweeted)
            {
                Retweeted=new Tweeted(status.RetweetedStatus);
            }

            Text = status.Text;
        }
    }
}