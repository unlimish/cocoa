using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// HelpPage2.
    /// </summary>
    public class HelpPage2 : BasePage
    {
        /***********
         * 接触の有無はどのように知ることができますか
        ***********/

        private readonly Query toolBarBack;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public HelpPage2()
        {
            if (OnAndroid)
            {
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); // 戻るボタン
            }

            if (OniOS)
            {
                toolBarBack = x => x.Class("UIButton").Index(0); // 戻るボタン
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HelpPage2Title"),
            iOS = x => x.Marked("HelpPage2Title"),
        };

        /// <summary>
        /// HelpPage2のアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertHelpPage2(TimeSpan? timeout = default(TimeSpan?))
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
    }
}
