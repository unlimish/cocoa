using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// ContantedNotifyクラス.
    /// </summary>
    public class ContactedNotifyPage : BasePage
    {
        /***********
         * 過去14日間の接触
        ***********/

        private readonly Query openIntroducePopup;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ContactedNotifyPage()
        {
            if (OnAndroid)
            {
            }

            if (OniOS)
            {
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("ContactedNotifyPageTitle"),
            iOS = x => x.Marked("ContactedNotifyPageTitle"),
        };

        /// <summary>
        /// ContactedNotifyPageのアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertContactedNotify(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            AssertOnPage(timeout);
        }

        /// <summary>
        /// アプリを共有するためのボトムシートを表示.
        /// </summary>
        public void OpenIntroducePopup()
        {
            app.Tap(openIntroducePopup);
        }
    }
}
