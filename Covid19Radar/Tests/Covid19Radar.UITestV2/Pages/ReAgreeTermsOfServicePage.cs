using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class ReAgreeTermsOfServicePage : BasePage
    {
        /***********
         * 利用規約の改定ページ
        ***********/


        readonly Query openHomePage;
        readonly Query openTermsOfServiceLink;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("ReAgreeTermsOfServicePageTitle"),
            iOS = x => x.Marked("ReAgreeTermsOfServicePageTitle")
        };

        public ReAgreeTermsOfServicePage()
        {
            

            if (OnAndroid)
            {
                openHomePage = x => x.Class("ButtonRenderer").Index(0);
                openTermsOfServiceLink = x => x.Class("LabelRenderer").Index(2);
            }

            if (OniOS)
            {
                openHomePage = x => x.Class("UIButton").Index(0);
                openTermsOfServiceLink = x => x.Class("UILabel").Index(2);
            }
        }

        public void AssertReAgreeTermsOfServicePage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }


        public HomePage OpenHomePage()
        {
            app.Tap(openHomePage);
            return new HomePage();
        }

        public void OpenTermsOfServiceLinkLink()
        {
            app.Tap(openTermsOfServiceLink);
        }







    }
}
