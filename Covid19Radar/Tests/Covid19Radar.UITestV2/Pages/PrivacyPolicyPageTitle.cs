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

            Tutorial_btn = x => x.Marked("PrivacyPolicyPageTitle").Class("ButtonRenderer").Index(0);



            if (OnAndroid)
            {
            }

            if (OniOS)
            {

            }
        }

        // メニュー表示確認
        public void AssertPrivacyPolicyPageTitle(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }

        public void Tutorial_privacypolicy()
        {
            app.Tap(Tutorial_btn);
        }





        

    }
}
