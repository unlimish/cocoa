using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class TutorialPage1 : BasePage
    {
        /***********
         * チュートリアルページ_1
        ***********/

        readonly Query openTutorialPage2;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TutorialPage1Title"),
            iOS = x => x.Marked("TutorialPage1Title")
        };

        public TutorialPage1()
        {

            



            if (OnAndroid)
            {
                openTutorialPage2 = x => x.Marked("TutorialPage1Title").Class("ButtonRenderer").Index(0);
            }

            if (OniOS)
            {
                openTutorialPage2 = x => x.Marked("TutorialPage1Title").Class("UIButton").Index(0);
            }
        }

        // メニュー表示確認
        public void AssertTutorialPage1(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public TutorialPage2 OpenTutorialPage2()
        {
            app.Tap(openTutorialPage2);
            return new TutorialPage2();
        }





        

    }
}
