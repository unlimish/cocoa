using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class TutorialPage2 : BasePage
    {
        /***********
         * チュートリアルページ_2
        ***********/

        readonly Query openTutorialPage3;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TutorialPage2Title"),
            iOS = x => x.Marked("TutorialPage2Title")
        };

        public TutorialPage2()
        {

            



            if (OnAndroid)
            {
                openTutorialPage3 = x => x.Marked("TutorialPage2Title").Class("ButtonRenderer").Index(0);
            }

            if (OniOS)
            {
                openTutorialPage3 = x => x.Marked("TutorialPage2Title").Class("UIButton").Index(0);
            }
        }

        // メニュー表示確認
        public void AssertTutorialPage2(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }

        public TutorialPage3 OpenTutorialPage3()
        {
            app.Tap(openTutorialPage3);
            return new TutorialPage3();
        }





        

    }
}
