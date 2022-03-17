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
    public class S24_Tests : BaseTestFixture
    {
        public S24_Tests(Platform platform)
            : base(platform)
        {
        }





        [Test]
        public void Case01_Test()
        {
            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            //S1 ホーム画面で、「陽性者との接触を確認する」ボタンを押下
            ExposureCheckPage exposureCheckPage = homePage.OpenExposureCheckPage();
            exposureCheckPage.AssertExposureCheckPage();

            //S2「過去14日間の接触」画面左上の戻るボタンを押下
            exposureCheckPage.ToolBarBack();
            homePage.AssertHomePage();

            //S3 ホーム画面で、「陽性情報の登録」ボタンを押下
            SubmitConsentPage submitConsentPage = homePage.OpenSubmitConsentPage();
            submitConsentPage.AssertSubmitConsentPage();

            //S4 「陽性登録への同意」画面で、「同意して陽性登録する」ボタンを押下
            NotifyOtherPage notifyOtherPage = submitConsentPage.OpenNotifyOtherPage();
            notifyOtherPage.AssertNotifyOtherPage();

            //S5 「陽性情報の登録」画面で、「処理番号の取得方法」リンクを押下
            HowToReceiveProcessingNumberPage howToReceiveProcessingNumberPage = notifyOtherPage.OpenHowToReceiveProcessingNumber();
            howToReceiveProcessingNumberPage.AssertHowToReceiveProcessingNumberPage();

            //S6 「処理番号の取得方法」画面左上の戻るボタンを押下
            howToReceiveProcessingNumberPage.ToolBarBack();
            notifyOtherPage.AssertNotifyOtherPage();

            //S7 「陽性情報の登録」画面左上の戻るボタンを押下
            notifyOtherPage.ToolBarBack();
            submitConsentPage.AssertSubmitConsentPage();

            //S8 「陽性登録への同意」画面左上の戻るボタンを押下
            submitConsentPage.ToolBarBack();
            homePage.AssertHomePage();

            //S9 ホーム画面で、ハンバーガーメニューを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S10 ハンバーガーメニューで、「設定」ボタンを押下
            SettingsPage settingsPage = menuPage.OpenSettingsPage();
            settingsPage.AssertSettingsPage();

            //S11 「設定」画面で、「ライセンス表記」を押下
            LicenseAgreementPage licenseAgreementPage = settingsPage.OpenLicenseAgreementPage();
            licenseAgreementPage.AssertLicenseAgreementPage();

            //S12 「ライセンス表記」画面左上の「設定」ボタンを押下
            licenseAgreementPage.ToolBarBack();
            settingsPage.AssertSettingsPage();

            //S13 「設定」画面左上のハンバーガーメニューを押下
            settingsPage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S14 ハンバーガーメニュー左上の戻るボタンを押下
            menuPage.ToolBarBack();
            settingsPage.AssertSettingsPage();

            //S15 「設定」画面左上のハンバーガーメニューを押下
            settingsPage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S16 ハンバーガーメニューで、「お問い合わせ」ボタンを押下
            InqueryPage inqueryPage = menuPage.OpenInqueryPage();
            inqueryPage.AssertInqueryPage();

            //S17 「アプリに関するお問い合わせ」画面で、「動作情報を送信」ボタンを押下
            SendLogConfirmationPage sendLogConfirmationPage = inqueryPage.OpenSendLogConfirmationPage();
            sendLogConfirmationPage.AssertSendLogConfirmationPage();

            //S18 「動作情報の送信について」画面左上の「戻る」ボタンを押下
            sendLogConfirmationPage.ToolBarBack();
            inqueryPage.AssertInqueryPage();

            //S19 「アプリに関するお問い合わせ」画面左上のハンバーガーメニューを押下
            inqueryPage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S20 ハンバーガーメニュー左上の戻るボタンを押下
            menuPage.ToolBarBack();
            inqueryPage.AssertInqueryPage();

            //S21 「アプリに関するお問い合わせ」画面左上のハンバーガーメニューを押下
            inqueryPage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S22 ハンバーガーメニューで、「使い方」ボタンを押下
            HelpMenuPage helpMenuPage = menuPage.OpenHelpMenuPage();
            helpMenuPage.AssertHelpMenuPage();

            //S23 「使い方」画面で、「どのように接触を記録していますか？」ボタンを押下
            HelpPage1 helpPage1 = helpMenuPage.OpenHelpPage1();
            helpPage1.AssertHelpPage1();

            //S24 「接触の記録方法」画面左上の「使い方」ボタンを押下
            helpPage1.ToolBarBack();
            helpMenuPage.AssertHelpMenuPage();

            //S25 「使い方」画面で、「接触の有無はどのように知ることができますか？」ボタンを押下
            HelpPage2 helpPage2 = helpMenuPage.OpenHelpPage2();
            helpPage2.AssertHelpPage2();

            //S26 「接触の確認方法」画面左上の「使い方」ボタンを押下
            helpPage2.ToolBarBack();
            helpMenuPage.AssertHelpMenuPage();

            //S27 「使い方」画面で、「新型コロナウイルスに感染していると判定されたら」ボタンを押下
            HelpPage3 helpPage3 = helpMenuPage.OpenHelpPage3();
            helpPage3.AssertHelpPage3();

            //S28 「感染していると判定されたら」画面で、「陽性情報を登録」ボタンを押下
            helpPage3.OpenSubmitConsentPage();
            submitConsentPage.AssertSubmitConsentPage();

            //S29 「陽性登録への同意」画面で、「同意して陽性登録する」ボタンを押下
            submitConsentPage.OpenNotifyOtherPage();
            notifyOtherPage.AssertNotifyOtherPage();

            //S30 「陽性情報の登録」画面で、「処理番号の取得方法」リンクを押下
            notifyOtherPage.OpenHowToReceiveProcessingNumber();
            howToReceiveProcessingNumberPage.AssertHowToReceiveProcessingNumberPage();

            //S31 「処理番号の取得方法」画面左上の「戻る」ボタンを押下
            howToReceiveProcessingNumberPage.ToolBarBack();
            notifyOtherPage.AssertNotifyOtherPage();

            //S32 「陽性情報の登録」画面左上の「戻る」ボタンを押下
            notifyOtherPage.ToolBarBack();
            submitConsentPage.AssertSubmitConsentPage();

            //S33 「陽性登録への同意」画面左上の「戻る」ボタンを押下
            submitConsentPage.ToolBarBack();
            helpPage3.AssertHelpPage3();

            //S34 「感染していると判定されたら」画面左上の「使い方」ボタンを押下
            helpPage3.ToolBarBack();
            helpMenuPage.AssertHelpMenuPage();

            //S35 「使い方」画面で、「接触の記録を停止 / 情報を削除するには」ボタンを押下
            HelpPage4 helpPage4 = helpMenuPage.OpenHelpPage4();
            helpPage4.AssertHelpPage4();

            //S36 「記録の停止/削除」画面で、「アプリの設定へ」ボタンを押下
            helpPage4.OpenSettingsPage();
            settingsPage.AssertSettingsPage();

            //S37 「設定」画面で、「ライセンス表記」ボタンを押下
            settingsPage.OpenLicenseAgreementPage();
            licenseAgreementPage.AssertLicenseAgreementPage();

            //S38 「ライセンス表記」画面左上の「設定」ボタンを押下
            licenseAgreementPage.ToolBarBack();
            settingsPage.AssertSettingsPage();

            //S39 「設定」画面左上の「記録の停止/削除」ボタンを押下
            settingsPage.ToolBarBack();
            helpPage4.AssertHelpPage4();

            //S40 「記録の停止/削除」画面左上の「使い方」ボタンを押下
            helpPage4.ToolBarBack();
            helpMenuPage.AssertHelpMenuPage();

            //S41 「使い方」画面左上のハンバーガーメニューを押下
            helpMenuPage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S42 ハンバーガーメニュー左上の戻るボタンを押下
            menuPage.ToolBarBack();
            helpMenuPage.AssertHelpMenuPage();

            //S43 「使い方」画面で、ハンバーガーメニューを押下
            helpMenuPage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S44 ハンバーガーメニューで、「利用規約」ボタンを押下
            TermsofservicePage termsofservicePage = menuPage.OpenTermsofservicePageFromHelpPage();
            termsofservicePage.AssertTermsofservicePage();

            //S45 「利用規約」画面左上のハンバーガーメニューを押下
            termsofservicePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S46 ハンバーガーメニュー左上の戻るボタンを押下
            menuPage.ToolBarBack();
            termsofservicePage.AssertTermsofservicePage();

            //S47 「利用規約」画面で、ハンバーガーメニューを押下
            termsofservicePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S48 ハンバーガーメニューで、「プライバシーポリシー」ボタンを押下
            PrivacyPolicyPage2 privacyPolicyPage2 = menuPage.OpenPrivacyPolicyPage2();
            privacyPolicyPage2.AssertPrivacyPolicyPage2();

            //S49 「プライバシーポリシー」画面左上のハンバーガーメニューを押下
            privacyPolicyPage2.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S50 ハンバーガーメニュー左上の戻るボタンを押下
            menuPage.ToolBarBack();
            privacyPolicyPage2.AssertPrivacyPolicyPage2();

            //S51 「プライバシーポリシー」画面で、ハンバーガーメニューを押下
            privacyPolicyPage2.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S52 ハンバーガーメニューで、「ウェブアクセシビリティ方針」ボタンを押下
            WebAccessibilityPolicyPage webAccessibilityPolicyPage = menuPage.OpenWebAccessibilityPolicyPage();
            webAccessibilityPolicyPage.AssertWebAccessibilityPolicyPage();

            //S53 「ウェブアクセシビリティ方針」画面左上のハンバーガーメニューを押下
            webAccessibilityPolicyPage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S54 ハンバーガーメニュー左上の戻るボタンを押下
            menuPage.ToolBarBack();
            webAccessibilityPolicyPage.AssertWebAccessibilityPolicyPage();

            //S55 「ウェブアクセシビリティ方針」画面左上のハンバーガーメニューを押下
            webAccessibilityPolicyPage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S56 ハンバーガーメニュー左上の「ホーム」ボタンを押下
            menuPage.OpenHomePage();
            homePage.AssertHomePage();
        }




    }
}
