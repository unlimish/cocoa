using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class MenuPage : BasePage
    {
        /***********
         * ハンバーガーメニュー
        ***********/

        readonly Query openHomePage;
        readonly Query openSettingsPage;
        readonly Query openInqueryPage;
        readonly Query openTermsofservicePage;
        readonly Query openTermsofservicePageFromHelpPage;
        readonly Query openPrivacyPolicyPage2;
        readonly Query openWebAccessibilityPolicyPage;
        readonly Query toolBarBack;
        readonly Query openHelpMenuPage;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("MasterDetailPageTitle"),
            iOS = x => x.Marked("MasterDetailPageTitle")
        };

        public MenuPage()
        {

            if (OnAndroid)
            {
                openHomePage = x => x.Marked("MasterDetailPageTitle").Class("ViewCellRenderer_ViewCellContainer").Index(0); //ホーム
                openSettingsPage = x => x.Marked("MasterDetailPageTitle").Class("ViewCellRenderer_ViewCellContainer").Index(1); //設定
                openInqueryPage = x => x.Marked("MasterDetailPageTitle").Class("ViewCellRenderer_ViewCellContainer").Index(2); //お問い合わせ
                openHelpMenuPage = x => x.Marked("MasterDetailPageTitle").Class("ViewCellRenderer_ViewCellContainer").Index(3); //使い方
                openTermsofservicePage = x => x.Marked("MasterDetailPageTitle").Class("ViewCellRenderer_ViewCellContainer").Index(4); //利用規約
                openTermsofservicePageFromHelpPage = x => x.Marked("MasterDetailPageTitle").Class("ViewCellRenderer_ViewCellContainer").Index(4); //利用規約 (使い方ページから)
                openPrivacyPolicyPage2 = x => x.Marked("MasterDetailPageTitle").Class("ViewCellRenderer_ViewCellContainer").Index(5); //プライバシーポリシー
                openWebAccessibilityPolicyPage = x => x.Marked("MasterDetailPageTitle").Class("ViewCellRenderer_ViewCellContainer").Index(6); //ウェブアクセシビリティ方針
                toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("ImageButtonRenderer").Index(0); //戻るボタン
            }

            if (OniOS)
            {
                openHomePage = x => x.Marked("MasterDetailPageTitle").Class("UITableViewCell").Index(0); //ホーム
                openSettingsPage = x => x.Marked("MasterDetailPageTitle").Class("UITableViewCell").Index(1); //設定
                openInqueryPage = x => x.Marked("MasterDetailPageTitle").Class("UITableViewCell").Index(2); //お問い合わせ
                openHelpMenuPage = x => x.Marked("MasterDetailPageTitle").Class("UITableViewCell").Index(3); //使い方
                openTermsofservicePage = x => x.Marked("MasterDetailPageTitle").Class("UITableViewCell").Index(4); //利用規約
                openTermsofservicePageFromHelpPage = x => x.Marked("MasterDetailPageTitle").Class("UITableViewCell").Index(4); //利用規約 (使い方ページから)
                openPrivacyPolicyPage2 = x => x.Marked("MasterDetailPageTitle").Class("UITableViewCell").Index(5); //プライバシーポリシー
                openWebAccessibilityPolicyPage = x => x.Marked("MasterDetailPageTitle").Class("UITableViewCell").Index(6); //ウェブアクセシビリティ方針
                toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("UIButton").Index(0); //戻るボタン
            }
        }

        // メニュー表示確認
        public void AssertMenuPage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public HomePage OpenHomePage()
        {
            app.Tap(openHomePage);
            return new HomePage();
        }

        public SettingsPage OpenSettingsPage()
        {
            app.Tap(openSettingsPage);
            return new SettingsPage();
        }

        public InqueryPage OpenInqueryPage()
        {
            app.Tap(openInqueryPage);
            return new InqueryPage();
        }

        public HelpMenuPage OpenHelpMenuPage()
        {
            app.Tap(openHelpMenuPage);
            return new HelpMenuPage();
        }

        public TermsofservicePage OpenTermsofservicePage()
        {
            app.Tap(openTermsofservicePage);
            return new TermsofservicePage();
        }

        public TermsofservicePage OpenTermsofservicePageFromHelpPage()
        {
            app.Tap(openTermsofservicePageFromHelpPage);
            return new TermsofservicePage();
        }

        public PrivacyPolicyPage2 OpenPrivacyPolicyPage2()
        {
            app.Tap(openPrivacyPolicyPage2);
            return new PrivacyPolicyPage2();
        }

        public WebAccessibilityPolicyPage OpenWebAccessibilityPolicyPage()
        {
            app.Tap(openWebAccessibilityPolicyPage);
            return new WebAccessibilityPolicyPage();
        }
        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }



    }
}
