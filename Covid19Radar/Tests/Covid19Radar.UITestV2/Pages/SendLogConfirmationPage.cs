using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class SendLogConfirmationPage : BasePage
    {
        /***********
         * 動作情報の送信
        ***********/

        readonly Query toolBarBack;
        readonly Query openMenuPage;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("SendLogConfirmationPageTitle"),
            iOS = x => x.Marked("SendLogConfirmationPageTitle")
        };

        public SendLogConfirmationPage()
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
        public void AssertSendLogConfirmationPage(TimeSpan? timeout = default(TimeSpan?))
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
