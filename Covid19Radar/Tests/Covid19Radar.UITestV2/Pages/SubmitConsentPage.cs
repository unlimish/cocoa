using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// SubmitVonsenPageクラス.
    /// </summary>
    public class SubmitConsentPage : BasePage
    {
        /***********
         * 陽性登録への同意
        ***********/

        private readonly Query openNotifyOtherPage;
        private readonly Query toolBarBack;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public SubmitConsentPage()
        {
            if (OnAndroid)
            {
                // (陽性登録への同意画面)
                openNotifyOtherPage = x => x.Marked("SubmitConsentPageTitle").Class("ButtonRenderer").Index(0); // 同意して登録する
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); // 戻るボタン
            }

            if (OniOS)
            {
                // (陽性登録への同意画面)
                openNotifyOtherPage = x => x.Marked("SubmitConsentPageTitle").Class("UIButton").Index(0); // 同意して登録する
                toolBarBack = x => x.Class("UIButton").Index(1); // 戻るボタン
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("SubmitConsentPageTitle"),
            iOS = x => x.Marked("SubmitConsentPageTitle"),
        };

        /// <summary>
        /// SubmitConsentPageのアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertSubmitConsentPage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            AssertOnPage(timeout);
        }

        /// <summary>
        /// 戻るボタンを押下する.
        /// </summary>
        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }

        /// <summary>
        /// NotifyOtherPageに遷移する.
        /// </summary>
        /// <returns>NotifyOtherPage.</returns>
        public NotifyOtherPage OpenNotifyOtherPage()
        {
            app.ScrollDownTo("SubmitConsentPageScrollBtn", "SubmitConsentPageScrollView");
            app.Tap(openNotifyOtherPage);
            return new NotifyOtherPage();
        }
    }
}
