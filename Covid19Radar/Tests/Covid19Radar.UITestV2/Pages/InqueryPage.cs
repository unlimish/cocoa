using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;


// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class InqueryPage : BasePage
    {
        /***********
         * アプリに関するお問い合わせ
        ***********/

        readonly Query opensendLogConfirmationPage;
        readonly Query openMenuPage;
        readonly Query openFAQBtn;
        readonly Query appImfoLink;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("InqueryPageTitle"),
            iOS = x => x.Marked("InqueryPageTitle")
        };

        public InqueryPage()
        {

            

            if (OnAndroid) 
            {
                opensendLogConfirmationPage = x => x.Marked("InqueryPageTitle").Class("ButtonRenderer").Index(2);//動作状況を送信ボタン
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); //ハンバーガーメニュー
                openFAQBtn = x => x.Marked("InqueryPageTitle").Class("ButtonRenderer").Index(0); //よくある質問ボタン
                appImfoLink = x => x.Marked("InqueryPageTitle").Class("LabelRenderer").Index(3); //接触確認アプリに関する情報リンク
            }

            if (OniOS)
            {
                opensendLogConfirmationPage = x => x.Marked("InqueryPageTitle").Class("UIButton").Index(2);//動作状況を送信ボタン
                openMenuPage = x => x.Class("UIButton").Index(3);//ハンバーガーメニュー
                openFAQBtn = x => x.Marked("InqueryPageTitle").Class("UIButton").Index(0); //よくある質問ボタン
                appImfoLink = x => x.Marked("InqueryPageTitle").Class("UILabel").Index(3); //接触確認アプリに関する情報リンク
            }
        }

        // ページ表示確認
        public void AssertInqueryPage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public SendLogConfirmationPage OpenSendLogConfirmationPage()
        {
            app.Tap(opensendLogConfirmationPage);
            return new SendLogConfirmationPage();
        }

        public void TapOpenFAQBtn()
        {
            app.Tap(openFAQBtn);
            //URLを取得する方法は保留中
            //app.Query(x => x.Marked("{WebView AutomationId}").Invoke("getUrl"));
        }

        public void TapAppImfoLink()
        {
            app.Tap(appImfoLink);
            //URLを取得する方法は保留中
            //app.Query(x => x.Marked("{WebView AutomationId}").Invoke("getUrl"));
        }


        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();

        }

    }

}
