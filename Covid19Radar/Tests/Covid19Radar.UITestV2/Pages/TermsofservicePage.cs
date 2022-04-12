using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// TermsofservicePageクラス.
    /// </summary>
    public class TermsofservicePage : BasePage
    {
        /***********
         * 利用規約
        ***********/

        private readonly Query toolBarBack;
        private readonly Query openMenuPage;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public TermsofservicePage()
        {
            if (OnAndroid)
            {
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); // 戻るボタン
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); // ハンバーガーメニュー
            }

            if (OniOS)
            {
                toolBarBack = x => x.Class("UIButton").Index(0); // 戻るボタン
                openMenuPage = x => x.Class("UIButton").Index(0); // ハンバーガーメニュー
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TermsofservicePageTitle"),
            iOS = x => x.Marked("TermsofservicePageTitle"),
        };

        /// <summary>
        /// TermsofservicePageのアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertTermsofservicePage(TimeSpan? timeout = default(TimeSpan?))
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
        /// MenuPage(ハンバーガーメニュー)を開く.
        /// </summary>
        /// <returns>MenuPage.</returns>
        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();
        }
    }
}
