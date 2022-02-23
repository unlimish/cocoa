using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class TutorialPage5 : BasePage
    {

        readonly Query Tutorial_btn;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TutorialPage5Title"),
            iOS = x => x.Marked("TutorialPage5Title")
        };

        public TutorialPage5()
        {

            Tutorial_btn = x => x.Marked("TutorialPage5Title").Class("ButtonRenderer").Index(0);



            if (OnAndroid)
            {
            }

            if (OniOS)
            {

            }
        }

        // メニュー表示確認
        public void AssertTutorialPage5(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }

        public void Tutorial_step5()
        {
            app.Tap(Tutorial_btn);
        }





        

    }
}
