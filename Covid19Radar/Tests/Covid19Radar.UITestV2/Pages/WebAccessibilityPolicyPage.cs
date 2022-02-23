using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class WebAccessibilityPolicyPage : BasePage
    {
        /***********
         * ウェブアクセシビリティ方針
        ***********/

        readonly Query toolBarBack;
        readonly Query openMenuPage;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("WebAccessibilityPolicyPageTitle"),
            iOS = x => x.Marked("WebAccessibilityPolicyPageTitle")
        };

        public WebAccessibilityPolicyPage()
        {
            toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("AppCompatImageButton").Index(0); //戻るボタン
            openMenuPage = x => x.Class("AppCompatImageButton").Marked("OK"); //ハンバーガーメニュー



            if (OnAndroid)
            {
            }

            if (OniOS)
            {

            }
        }

        // メニュー表示確認
        public void AssertWebAccessibilityPolicyPage(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }
        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }

        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();

        }







    }
}
