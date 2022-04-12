using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// PrivacyPolicyPageTitleクラス.
    /// </summary>
    public class PrivacyPolicyPageTitle : BasePage
    {
        private readonly Query tutorialBtn;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PrivacyPolicyPageTitle()
        {
            if (OnAndroid)
            {
                tutorialBtn = x => x.Marked("PrivacyPolicyPageTitle").Class("ButtonRenderer").Index(0);
            }

            if (OniOS)
            {
                tutorialBtn = x => x.Marked("PrivacyPolicyPageTitle").Class("UIButton").Index(0);
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("PrivacyPolicyPageTitle"),
            iOS = x => x.Marked("PrivacyPolicyPageTitle"),
        };

        /// <summary>
        /// PrivacyPolicyPageTitleのアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertPrivacyPolicyPageTitle(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            AssertOnPage(timeout);
        }

        public void Tutorial_privacypolicy()
        {
            app.Tap(tutorialBtn);
        }
    }
}
