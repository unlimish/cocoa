using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class ReAgreePrivacyPolicyPage : BasePage
    {
        /***********
         * プライバシーポリシーの改訂ページ
        ***********/

        readonly Query openHomePage;
        readonly Query openPrivacyPolicyLink;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("ReAgreePrivacyPolicyPageTitle"),
            iOS = x => x.Marked("ReAgreePrivacyPolicyPageTitle")
        };

        public ReAgreePrivacyPolicyPage()
        {
            

            if (OnAndroid)
            {
                openHomePage = x => x.Class("ButtonRenderer").Index(0);
                openPrivacyPolicyLink = x => x.Class("LabelRenderer").Index(2);
            }

            if (OniOS)
            {

            }
        }


        public void AssertReAgreePrivacyPolicyPage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }


        public HomePage OpenHomePage()
        {
            app.Tap(openHomePage);
            return new HomePage();
        }

        public void OpenPrivacyPolicyLink()
        {
            app.Tap(openPrivacyPolicyLink);
        }







    }
}
