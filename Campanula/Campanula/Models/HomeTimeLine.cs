using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using Aster;
using CoreTweet.Streaming;
using StatefulModel;

namespace Campanula.Models
{
    public class HomeTimeLine : NotificationObject
    {
        #region List 変更通知コレクション

        private ObservableSynchronizedCollection<Tweeted> _list;

        public ObservableSynchronizedCollection<Tweeted> List
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public HomeTimeLine(IEnumerable<Tweeted> list, StreamingApi api)
        {
            List = new ObservableSynchronizedCollection<Tweeted>(list);
            /*api.UserAsObservable()
                .Where(x => x.Type == MessageType.Create)
                .Cast<StatusMessage>()
                .Select(x => new Tweeted(x.Status))
                .Subscribe(x => List.Insert(0, x));*/
        }

        public void Update()
        {
            foreach (var tweeted in TwitterClient.Current
                .User.Token.Statuses
                .HomeTimelineAsync(count => 20)
                .Result
                .Select(x => new Tweeted(x))
                .Reverse()
                .Where(x => !List.Contains(x)))
            {
                List.Insert(0,tweeted);
            }
        }
    }
}