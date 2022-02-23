using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class PrivacyPolicyPage : BasePage
    {
        /***********
         * プライバシーポリシー (チュートリアル内)
        ***********/

        readonly Query openTutorialPage4;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("PrivacyPolicyPageTitle"),
            iOS = x => x.Marked("PrivacyPolicyPageTitle")
        };

        public PrivacyPolicyPage()
        {

            



            if (OnAndroid)
            {
                openTutorialPage4 = x => x.Marked("PrivacyPolicyPageTitle").Class("ButtonRenderer").Index(0);
            }

            if (OniOS)
            {
                openTutorialPage4 = x => x.Marked("PrivacyPolicyPageTitle").Class("UIButton").Index(0);
            }
        }

        // メニュー表示確認
        public void AssertPrivacyPolicyPage(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }

        public TutorialPage4 OpenTutorialPage4()
        {
            app.Tap(openTutorialPage4);
            return new TutorialPage4();
        }





        

    }
}
