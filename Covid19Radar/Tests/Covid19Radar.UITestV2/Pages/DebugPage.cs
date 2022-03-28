using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class DebugPage : BasePage
    {
        /***********
         * デバッグページ
        ***********/


        readonly Query openMenuPage;
        readonly Query openReAgreePrivacyPolicyPage;
        readonly Query openReAgreeTermsOfServicePage;
        readonly Query openContactedNotifyPage;
        TimeSpan ts1 = new TimeSpan(0, 0, 10);

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("DebugPageTitle"),
            iOS = x => x.Marked("DebugPageTitle")
        };

        public DebugPage()
        {

            

            {
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); //ハンバーガーメニュー
                openReAgreePrivacyPolicyPage = x => x.Marked("ReAgreePrivacyPolicyPage");//ReAgreePrivacyPolicyPageボタン
                openReAgreeTermsOfServicePage = x => x.Marked("ReAgreeTermsOfServicePage");//ReAgreeTermsOfServicePageボタン
                openContactedNotifyPage = x => x.Marked("ContactedNotifyPage");//ContactedNotifyPageボタン
            }

            if (OniOS)
            {
                openMenuPage = x => x.Class("UIButton").Index(3);//ハンバーガーメニュー
                openReAgreePrivacyPolicyPage = x => x.Marked("ReAgreePrivacyPolicyPage");//ReAgreePrivacyPolicyPageボタン
                openReAgreeTermsOfServicePage = x => x.Marked("ReAgreeTermsOfServicePage");//ReAgreeTermsOfServicePageボタン
                openContactedNotifyPage = x => x.Marked("ContactedNotifyPage");//ContactedNotifyPageボタン
            }
        }

        // メニュー表示確認
        public void AssertDebugPage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }


        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();

        }

        public ReAgreePrivacyPolicyPage OpenReAgreePrivacyPolicyPage()
        {
            app.ScrollDownTo("ReAgreePrivacyPolicyPage", "DebugPageScrollView", ScrollStrategy.Auto, 0.67, 3000, true, ts1);
            app.Tap(openReAgreePrivacyPolicyPage);
            return new ReAgreePrivacyPolicyPage();

        }

        public ReAgreeTermsOfServicePage OpenReAgreeTermsOfServicePage()
        {
            app.ScrollDownTo("ReAgreeTermsOfServicePage", "DebugPageScrollView", ScrollStrategy.Auto, 0.67, 3000, true, ts1);
            app.Tap(openReAgreeTermsOfServicePage);
            return new ReAgreeTermsOfServicePage();

        }

        public ContactedNotifyPage OpenContactedNotifyPage()
        {
            app.ScrollDownTo("ContactedNotifyPage", "DebugPageScrollView", ScrollStrategy.Auto, 0.67, 3000, true, ts1);
            app.Tap(openContactedNotifyPage);
            return new ContactedNotifyPage();

        }

    }
}
