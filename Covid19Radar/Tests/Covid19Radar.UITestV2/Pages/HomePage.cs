using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// HomePageクラス.
    /// </summary>
    public class HomePage : BasePage
    {
        /***********
         * ホームページ
        ***********/

        private readonly Query openMenuPage;
        private readonly Query openHelpMenuPage;
        private readonly Query toolBarBack;
        private readonly Query openNotContactPage;
        private readonly Query openSubmitConsentPage;
        private readonly Query openNotContactPageENoff;
        private readonly Query openQuestionMark;
        private readonly Query openSubmitConsentPageENoff;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public HomePage()
        {
            if (OnAndroid)
            {
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); // ハンバーガーメニュー
                openHelpMenuPage = x => x.Marked("LabelMainTutorial"); // 使い方
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); // 戻るボタン
                openNotContactPage = x => x.Marked("HomePageTitle").Class("ButtonRenderer").Index(0); // 陽性者との接触結果を確認
                openNotContactPageENoff = x => x.Marked("HomePageTitle").Class("ButtonRenderer").Index(1); // 陽性者との接触結果を確認 (接触通知OFF)
                openSubmitConsentPage = x => x.Marked("HomePageTitle").Class("ButtonRenderer").Index(1); // 陽性情報の登録
                openSubmitConsentPageENoff = x => x.Marked("HomePageTitle").Class("ButtonRenderer").Index(2); // 陽性情報の登録(接触通知OFF)
                openQuestionMark = x => x.Marked("HomePageTitle").Class("CachedImageFastRenderer").Index(2); // ?マーク
            }

            if (OniOS)
            {
                openMenuPage = x => x.Class("UIButton").Index(3); // ハンバーガーメニュー
                openHelpMenuPage = x => x.Marked("LabelMainTutorial"); // 使い方
                toolBarBack = x => x.Class("UIButton").Index(3); // 戻るボタン
                openNotContactPage = x => x.Marked("HomePageTitle").Class("UIButton").Index(1); // 陽性者との接触結果を確認
                openNotContactPageENoff = x => x.Marked("HomePageTitle").Class("UIButton").Index(2); // 陽性者との接触結果を確認 (接触通知OFF)
                openSubmitConsentPage = x => x.Marked("HomePageTitle").Class("UIButton").Index(2); // 陽性情報の登録
                openSubmitConsentPageENoff = x => x.Marked("HomePageTitle").Class("UIButton").Index(3); // 陽性情報の登録(接触通知OFF)
                openQuestionMark = x => x.Marked("HomePageTitle").Class("UIButton").Index(0); // ?マーク
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HomePageTitle"),
            iOS = x => x.Marked("HomePageTitle"),
        };

        /// <summary>
        /// HomePagenoのアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertHomePage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            AssertOnPage(timeout);
        }

        /// <summary>
        /// MenuPage(ハンバーガーメニュー)を開く.
        /// </summary>
        /// <returns>MenuPage.</returns>
        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();
        }

        /// <summary>
        /// 戻るボタンをタップ.
        /// </summary>
        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }

        /// <summary>
        /// 過去14日間の接触ページに遷移(接触通知ON時に使用).
        /// </summary>
        /// <returns>ExposureCheckPage.</returns>
        public ExposureCheckPage OpenExposureCheckPage()
        {
            app.Tap(openNotContactPage);
            return new ExposureCheckPage();
        }

        /// <summary>
        /// 陽性情報の登録に遷移(接触通知ON時に使用).
        /// </summary>
        /// <returns>SubmitConsentPage.</returns>
        public SubmitConsentPage OpenSubmitConsentPage()
        {
            app.Tap(openSubmitConsentPage);
            return new SubmitConsentPage();
        }

        /// <summary>
        /// 陽性情報の登録に遷移(接触通知OFF時に使用).
        /// </summary>
        /// <returns>SubmitConsentPage.</returns>
        public SubmitConsentPage OpenSubmitConsentPage_ENoff()
        {
            app.Tap(openSubmitConsentPageENoff);
            return new SubmitConsentPage();
        }

        /// <summary>
        /// ?ボタンを押下する.
        /// </summary>
        public void OpenQuestionMark()
        {
            app.Tap(openQuestionMark);
        }
    }
}
