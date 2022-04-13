using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// DebugPageクラス.
    /// </summary>
    public class DebugPage : BasePage
    {
        /***********
         * デバッグページ
        ***********/

        private readonly Query openMenuPage;
        private readonly Query openReAgreePrivacyPolicyPage;
        private readonly Query openReAgreeTermsOfServicePage;
        private readonly Query openContactedNotifyPage;
        private TimeSpan ts1 = new TimeSpan(0, 0, 20);

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DebugPage()
        {
            {
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); // ハンバーガーメニュー
                openReAgreePrivacyPolicyPage = x => x.Marked("ReAgreePrivacyPolicyPage"); // ReAgreePrivacyPolicyPageボタン
                openReAgreeTermsOfServicePage = x => x.Marked("ReAgreeTermsOfServicePage"); // ReAgreeTermsOfServicePageボタン
                openContactedNotifyPage = x => x.Marked("ContactedNotifyPage"); // ContactedNotifyPageボタン
            }

            if (OniOS)
            {
                openMenuPage = x => x.Class("UIButton").Index(3); // ハンバーガーメニュー
                openReAgreePrivacyPolicyPage = x => x.Marked("ReAgreePrivacyPolicyPage"); // ReAgreePrivacyPolicyPageボタン
                openReAgreeTermsOfServicePage = x => x.Marked("ReAgreeTermsOfServicePage"); // ReAgreeTermsOfServicePageボタン
                openContactedNotifyPage = x => x.Marked("ContactedNotifyPage"); // ContactedNotifyPageボタン
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("DebugPageTitle"),
            iOS = x => x.Marked("DebugPageTitle"),
        };

        /// <summary>
        /// DebugPageのアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertDebugPage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            AssertOnPage(timeout);
        }

        /// <summary>
        /// MenuPage(ハンバーガーメニュー)を開く.
        /// </summary>
        /// <returns>MenuPage.</returns>
        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();
        }

        /// <summary>
        /// ReAgreePrivacyPolicyPageを開く.
        /// </summary>
        /// <returns>ReAgreePrivacyPolicyPage.</returns>
        public ReAgreePrivacyPolicyPage OpenReAgreePrivacyPolicyPage()
        {
            app.ScrollDownTo("ReAgreePrivacyPolicyPage", "DebugPageScrollView", ScrollStrategy.Auto, 0.67, 10000, true, ts1);
            app.Tap(openReAgreePrivacyPolicyPage);
            return new ReAgreePrivacyPolicyPage();
        }

        /// <summary>
        /// ReAgreeTermsOfServicePageを開く.
        /// </summary>
        /// <returns>ReAgreeTermsOfServicePage.</returns>
        public ReAgreeTermsOfServicePage OpenReAgreeTermsOfServicePage()
        {
            app.ScrollDownTo("ReAgreeTermsOfServicePage", "DebugPageScrollView", ScrollStrategy.Auto, 0.67, 10000, true, ts1);
            app.Tap(openReAgreeTermsOfServicePage);
            return new ReAgreeTermsOfServicePage();
        }

        /// <summary>
        /// ContactedNotifyPageを開く.
        /// </summary>
        /// <returns>ContactedNotifyPage.</returns>
        public ContactedNotifyPage OpenContactedNotifyPage()
        {
            app.ScrollDownTo("ContactedNotifyPage", "DebugPageScrollView", ScrollStrategy.Auto, 0.67, 10000, true, ts1);
            app.Tap(openContactedNotifyPage);
            return new ContactedNotifyPage();
        }
    }
}
