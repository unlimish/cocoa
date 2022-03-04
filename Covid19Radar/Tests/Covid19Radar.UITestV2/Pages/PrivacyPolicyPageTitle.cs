using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class PrivacyPolicyPageTitle : BasePage
    {

        readonly Query Tutorial_btn;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("PrivacyPolicyPageTitle"),
            iOS = x => x.Marked("PrivacyPolicyPageTitle")
        };

        public PrivacyPolicyPageTitle()
        {

            if (OnAndroid)
            {
                Tutorial_btn = x => x.Marked("PrivacyPolicyPageTitle").Class("ButtonRenderer").Index(0);
            }

            if (OniOS)
            {
                Tutorial_btn = x => x.Marked("PrivacyPolicyPageTitle").Class("UIButton").Index(0);
            }
        }

        // メニュー表示確認
        public void AssertPrivacyPolicyPageTitle(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public void Tutorial_privacypolicy()
        {
            app.Tap(Tutorial_btn);
        }





        

    }
}
