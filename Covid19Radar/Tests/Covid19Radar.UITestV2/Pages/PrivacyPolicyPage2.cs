using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class PrivacyPolicyPage2 : BasePage
    {
        /***********
         * プライバシーポリシー (ハンバーガーメニュー内)
        ***********/

        readonly Query toolBarBack;
        readonly Query openMenuPage;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("PrivacyPolicyPage2Title"),
            iOS = x => x.Marked("PrivacyPolicyPage2Title")
        };

        public PrivacyPolicyPage2()
        {
            
            if (OnAndroid)
            {
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); //戻るボタン
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); //ハンバーガーメニュー
            }

            if (OniOS)
            {
                toolBarBack = x => x.Id("BackButton").Class("UIButton").Index(0); //戻るボタン
                openMenuPage = x => x.Class("UIButton").Marked("OK"); //ハンバーガーメニュー
            }
        }

        // メニュー表示確認
        public void AssertPrivacyPolicyPage2(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
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
