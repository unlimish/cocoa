using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class SettingsPage : BasePage
    {
        /***********
         * 設定ページ
        ***********/

        readonly Query openLicenseAgreementPage;
        readonly Query toolBarBack;
        readonly Query openMenuPage;
        readonly Query tapSyokika;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("SettingsPageTitle"),
            iOS = x => x.Marked("SettingsPageTitle")
        };

        public SettingsPage()
        {
            

            if (OnAndroid)
            {
                openLicenseAgreementPage = x => x.Marked("SettingsPageTitle").Class("ButtonRenderer").Index(0); //ライセンスページ
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); //戻るボタン
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); //ハンバーガーメニュー
                tapSyokika = x => x.Marked("SettingsPageTitle").Class("ButtonRenderer").Index(1); //アプリ初期化
            }

            if (OniOS)
            {
                openLicenseAgreementPage = x => x.Marked("SettingsPageTitle").Class("UIButton").Index(0); //ライセンスページ
                toolBarBack = x => x.Class("UIButton").Index(2); //戻るボタン
                openMenuPage = x => x.Class("UIButton").Index(2);//ハンバーガーメニュー
                tapSyokika = x => x.Marked("SettingsPageTitle").Class("UIButton").Index(1); //アプリ初期化
            }
        }

        // メニュー表示確認
        public void AssertSettingsPage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public LicenseAgreementPage OpenLicenseAgreementPage()
        {
            app.Tap(openLicenseAgreementPage);
            return new LicenseAgreementPage();
        }

        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }
        public void TapSyokika()
        {
            app.Tap(tapSyokika);

        }

        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();

        }


        public void TaplDialogOKBtn()
        {
            app.WaitForElement(x => x.Text("OK"));
            app.Tap("OK");
        }

        public void TapDialogCancelBtn(String cultureText = "ja-JP")
        {
            string ComparisonText = (string)AppManager.Comparison(cultureText, "ButtonCancel");
            app.WaitForElement(x => x.Text(ComparisonText));
            app.Tap(ComparisonText);//陽性情報の登録をしますダイアログ→(「登録」ボタン)
        }


    }
}
