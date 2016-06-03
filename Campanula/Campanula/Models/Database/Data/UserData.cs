using Realms;

namespace Campanula.Models.Database.Data
{
    public class UserData:RealmObject
    {
        /// <summary>
        /// アカウントのUserId
        /// Primary Key
        /// </summary>
        [ObjectId]
        public long Id { get; set; }

        /// <summary>
        /// アクセストークン
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// トークンシークレット
        /// </summary>
        public string AccessSecret { get; set; }

        /// <summary>
        /// 暗号化に用いるSalt
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// 現在ユーザーが表示しているアカウントかのフラグ
        /// </summary>
        public bool Current { get; set; }

       
    }
}