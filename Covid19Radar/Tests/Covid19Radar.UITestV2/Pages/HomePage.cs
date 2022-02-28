using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class HomePage : BasePage
    {
        /***********
         * ホームページ
        ***********/

        readonly Query openMenuPage;
        readonly Query openHelpMenuPage;
        readonly Query toolBarBack;
        readonly Query openNotContactPage;
        readonly Query openSubmitConsentPage;
        readonly Query openNotContactPage_ENoff;
        readonly Query openQuestionMark;
        readonly Query openSubmitConsentPage_ENoff;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HomePageTitle"),
            iOS = x => x.Marked("HomePageTitle")
        };

        public HomePage()
        {
            

            if (OnAndroid) 
            {
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); //ハンバーガーメニュー
                openHelpMenuPage = x => x.Marked("LabelMainTutorial"); //使い方
                toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("AppCompatImageButton").Index(0); //戻るボタン
                openNotContactPage = x => x.Marked("MasterDetailPageTitle").Class("ButtonRenderer").Index(0); //陽性者との接触結果を確認
                openNotContactPage_ENoff = x => x.Marked("MasterDetailPageTitle").Class("ButtonRenderer").Index(1); //陽性者との接触結果を確認 (接触通知OFF)
                openSubmitConsentPage = x => x.Marked("MasterDetailPageTitle").Class("ButtonRenderer").Index(1); //陽性情報の登録
                openSubmitConsentPage_ENoff = x => x.Marked("MasterDetailPageTitle").Class("ButtonRenderer").Index(2); //陽性情報の登録(接触通知OFF)
                openQuestionMark = x => x.Marked("MasterDetailPageTitle").Class("CachedImageFastRenderer").Index(2); //?マーク
            }

            if (OniOS)
            {
                openMenuPage = x => x.Class("UIButton").Index(0); //ハンバーガーメニュー
                openHelpMenuPage = x => x.Marked("LabelMainTutorial"); //使い方
                toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("UIButton").Index(0); //戻るボタン
                openNotContactPage = x => x.Marked("HomePageTitle").Class("UIButton").Index(0); //陽性者との接触結果を確認
                openNotContactPage_ENoff = x => x.Marked("HomePageTitle").Class("UIButton").Index(1); //陽性者との接触結果を確認 (接触通知OFF)
                openSubmitConsentPage = x => x.Marked("HomePageTitle").Class("UIButton").Index(1); //陽性情報の登録
                openSubmitConsentPage_ENoff = x => x.Marked("HomePageTitle").Class("UIButton").Index(2); //陽性情報の登録(接触通知OFF)
                openQuestionMark = x => x.Marked("HomePageTitle").Class("UIButton").Index(2); //?マーク
            }
        }

        // ページ表示確認
        public void AssertHomePage(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }

        // ハンバーガーメニューのタップ
        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();

        }

        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }


        //過去14日間の接触ページ(接触通知ON)
        public ExposureCheckPage OpenExposureCheckPage()
        {
            app.Tap(openNotContactPage);
            return new ExposureCheckPage();
        }

        //陽性情報の登録
        public SubmitConsentPage OpenSubmitConsentPage()
        {
            app.Tap(openSubmitConsentPage);
            return new SubmitConsentPage();
        }

        //陽性情報の登録(接触通知OFF)
        public SubmitConsentPage OpenSubmitConsentPage_ENoff()
        {
            app.Tap(openSubmitConsentPage_ENoff);
            return new SubmitConsentPage();
        }

        public void OpenQuestionMark()
        {
            app.Tap(openQuestionMark);
        }
        

    }

}
