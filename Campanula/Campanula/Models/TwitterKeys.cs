using CoreTweet;

namespace Campanula.Models
{
    /// <summary>
    /// Twitterの各種Keyなどを扱うクラスです。
    /// </summary>
    internal class TwitterKeys
    {
        /// <summary>
        /// このアプリケーションのConsumerKeyを取得します。
        /// </summary>
        internal static string ConsumerKey =>
            "ConsumerKey";

        /// <summary>
        /// このアプリケーションのConsumerSercretを取得します。
        /// </summary>
        internal static string ConsumerSecret =>
            "ConsumerSecret";



        /// <summary>
        /// トークンを保存します。
        /// </summary>
        internal static void SaveToken(Tokens token)
        {
            //Databaseに保存
        }

        /// <summary>
        /// 保存してあるデータから<see cref="Tokens"/>を取得します。
        /// </summary>
        /// <param name="userId">Twitter user id</param>
        /// <returns>user idに紐づいた<see cref="Tokens"/></returns>
        internal static Tokens GetTokens(long userId)
        {
            //DatabaseからTokenKeyとTokenSercretを取得
            return Tokens.Create(ConsumerKey,ConsumerSecret,"accessToken","accessSecret");
        }
    }
}