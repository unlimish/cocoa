using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class HelpPage2 : BasePage
    {
        /***********
         * 接触の有無はどのように知ることができますか
        ***********/

        readonly Query toolBarBack;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HelpPage2Title"),
            iOS = x => x.Marked("HelpPage2Title")
        };

        public HelpPage2()
        {
            

            if (OnAndroid)
            {
                toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("AppCompatImageButton").Index(0); //戻るボタン
            }

            if (OniOS)
            {
                toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("UIButton").Index(0); //戻るボタン
            }
        }

        // メニュー表示確認
        public void AssertHelpPage2(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }
        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }







    }
}
