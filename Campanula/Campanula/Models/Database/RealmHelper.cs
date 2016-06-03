using System;
using System.Linq;
using Campanula.Models.Database.Data;
using Realms;

namespace Campanula.Models.Database
{
    public static class RealmHelper
    {
        /// <summary>
        /// <see cref="Realm"/>のインスタンス。
        /// </summary>
        public static Realm Instance { get; }= Realm.GetInstance("Campanula.realm");


        /// <summary>
        /// <see cref="RealmObject"/>から既存のカラムを更新します。
        /// </summary>
        /// <typeparam name="T"><see cref="RealmObject"/></typeparam>
        /// <param name="item">既存のカラム</param>
        /// <param name="updateAction">更新アクション</param>
        public static void Update<T>(this T item,Action<T> updateAction)where T:RealmObject
        {
            using (var transaction=Instance.BeginWrite())
            {
                updateAction(item);

                transaction.Commit();
            }
        }

        /// <summary>
        /// <see cref="RealmObject"/>からカラムを作成します。
        /// </summary>
        /// <typeparam name="T"><see cref="RealmObject"/></typeparam>
        /// <param name="item">作成するオブジェクト</param>
        public static void Create<T>(this T item)where T:RealmObject,new ()
        {
            using (var transaction=Instance.BeginWrite())
            {
                Instance.Manage(item);

                transaction.Commit();
            }
        }

        public static void Marge<T>(Func<T,bool> predicate,Action<T> action) where T:RealmObject,new ()
        {
            using (var transaction=Instance.BeginWrite())
            {
                var copyitem = Instance.All<T>().ToList().FirstOrDefault(predicate) ?? Instance.CreateObject<T>();

                action(copyitem);

                transaction.Commit();
            }
        }
    }
}