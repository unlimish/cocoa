using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class TutorialPage6 : BasePage
    {
        /***********
         * チュートリアルページ_6
        ***********/

        readonly Query openHomePage;
        readonly Query openHelpMenuPage;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TutorialPage6Title"),
            iOS = x => x.Marked("TutorialPage6Title")
        };

        public TutorialPage6()
        {


            if (OnAndroid)
            {
                openHomePage = x => x.Marked("TutorialPage6Title").Class("ButtonRenderer").Index(0);
                openHelpMenuPage = x => x.Marked("TutorialPage6Title").Class("ButtonRenderer").Index(1);
            }

            if (OniOS)
            {
                openHomePage = x => x.Marked("TutorialPage6Title").Class("UIButton").Index(0);
                openHelpMenuPage = x => x.Marked("TutorialPage6Title").Class("UIButton").Index(1);
            }
        }

        // メニュー表示確認
        public void AssertTutorialPage6(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public HomePage OpenHomePage()
        {
            app.Tap(openHomePage);
            return new HomePage();
        }
        public HelpMenuPage OpenHelpMenuPage()
        {
            app.Tap(openHelpMenuPage);
            return new HelpMenuPage();
        }







    }
}
