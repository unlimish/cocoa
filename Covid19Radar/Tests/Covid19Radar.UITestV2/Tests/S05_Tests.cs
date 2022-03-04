using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CovidRadar.UITestV2
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    [Category("ja-JP")]
    public class S05_Tests : BaseTestFixture

    {
        public S05_Tests(Platform platform)
            : base(platform)
        {
        }


        [Test]
        public void Case01_Test()
        {

            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            // S1 ホーム画面で、ハンバーガーメニュー内の「使い方」ボタンを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            HelpMenuPage helpMenuPage = menuPage.OpenHelpMenuPage();
            helpMenuPage.AssertHelpMenuPage();


            //S2 「使い方」画面で、「新型コロナウイルスに感染していると判定されたら」ボタンを押下
            HelpPage3 helpPage3 = helpMenuPage.OpenHelpPage3();
            helpPage3.AssertHelpPage3();

            //S3 「感染していると判定されたら」画面で、「陽性情報を登録」ボタンを押下
            SubmitConsentPage submitConsent = helpPage3.OpenSubmitConsentPage();
            submitConsent.AssertSubmitConsentPage();

            //S4 「陽性登録への同意」画面で、「同意して陽性登録する」ボタンを押下
            NotifyOtherPage notifyOtherPage = submitConsent.OpenNotifyOtherPage();
            notifyOtherPage.AssertNotifyOtherPage();

            //S5 陽性情報の登録画面で、「次のような症状がありますか？」のラジオボタン「ある」を押下
            notifyOtherPage.TapYesRadioBtn();

            //S6 カレンダーに任意の日付を入力(自動で今日の日付が入力される)

            //S7 処理番号の取得方法のリンクを押下
            HowToReceiveProcessingNumberPage howToReceiveProcessingNumberPage = notifyOtherPage.OpenHowToReceiveProcessingNumber("checked");
            howToReceiveProcessingNumberPage.AssertHowToReceiveProcessingNumberPage();

            //S8 処理番号の取得方法画面で「戻る」ボタンを押下
            howToReceiveProcessingNumberPage.ToolBarBack();

            //S9 処理番号入力テキストボックスに処理番号を入力
            notifyOtherPage.EnterProcessingNumberForm("99999910");
            notifyOtherPage.AssertNotifyOtherPage();

            //S10 「登録する」ボタンを押下
            notifyOtherPage.TapRegisterBtn();

            //端末言語取得
            var cultureText = AppManager.GetCurrentCultureBackDoor();

            //S11 「登録します」ポップアップの「登録」を押下
            notifyOtherPage.TapRegisterConfirmBtn(cultureText);

            //TODO:以下の実装を加える
            //S12 ほかの人に通知するために情報を共有しますか？画面でパターンを参照して選択肢を押下し、「陽性情報の登録」画面に遷移する。
            
            //S13 「登録完了」ポップアップでOK押下
            notifyOtherPage.TapCancelDialogOKBtn();
            homePage.AssertHomePage();
        }


    }
}
