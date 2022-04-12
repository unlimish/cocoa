using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// HelpPage3クラス.
    /// </summary>
    public class HelpPage3 : BasePage
    {
        /***********
         * 新型コロナウイルスに感染していると判定されたら
        ***********/

        private readonly Query toolBarBack;
        private readonly Query openSubmitConsentPage;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public HelpPage3()
        {
            if (OnAndroid)
            {
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); // 戻るボタン
                openSubmitConsentPage = x => x.Marked("HelpPage3Title").Class("ButtonRenderer").Index(0); // 陽性情報を登録
            }

            if (OniOS)
            {
                toolBarBack = x => x.Class("UIButton").Index(1); // 戻るボタン
                openSubmitConsentPage = x => x.Marked("HelpPage3Title").Class("UIButton").Index(0); // 陽性情報を登録
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HelpPage3Title"),
            iOS = x => x.Marked("HelpPage3Title"),
        };

        /// <summary>
        /// HelpPage3のアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertHelpPage3(TimeSpan? timeout = default(TimeSpan?))
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
        /// SubmitConsentPageに遷移する.
        /// </summary>
        /// <returns>SubmitConsentPage.</returns>
        public SubmitConsentPage OpenSubmitConsentPage()
        {
            app.ScrollDownTo("HelpPage3Btn", "HelpPage3ScrollView");
            app.Tap(openSubmitConsentPage);
            return new SubmitConsentPage();
        }
    }
}
