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
        readonly Query submitConsentPageBtn;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("SendLogConfirmationPageTitle"),
            iOS = x => x.Marked("SendLogConfirmationPageTitle")
        };

        public SendLogConfirmationPage()
        {

            if (OnAndroid)
            {
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); //戻るボタン
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); //ハンバーガーメニュー
                submitConsentPageBtn = x => x.Marked("SendLogConfirmationPageTitle").Class("ButtonRenderer").Index(0);//登録するボタン
            }

            if (OniOS)
            {
                toolBarBack = x => x.Class("UIButton").Index(1); //戻るボタン
                openMenuPage = x => x.Class("UIButton").Marked("OK"); //ハンバーガーメニュー
                submitConsentPageBtn = x => x.Marked("SendLogConfirmationPageTitle").Class("UIButton").Index(0);//登録するボタン
            }
        }

        // メニュー表示確認
        public void AssertSendLogConfirmationPage(TimeSpan? timeout = default(TimeSpan?))
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

        public SendLogCompletePage OpenSubmitConsentPageBtn()
        {
            app.ScrollDownTo("SendLogConfirmationPageButton", "SendLogConfirmationPageScrollView");
            app.Tap("SendLogConfirmationPageButton");
            return new SendLogCompletePage();
        }






    }
}
