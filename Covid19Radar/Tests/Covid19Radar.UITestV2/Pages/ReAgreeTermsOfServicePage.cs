﻿using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// ReAgreeTermsOfServicePageクラス.
    /// </summary>
    public class ReAgreeTermsOfServicePage : BasePage
    {
        /***********
         * 利用規約の改定ページ
        ***********/

        private readonly Query openHomePage;
        private readonly Query openTermsOfServiceLink;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReAgreeTermsOfServicePage()
        {
            if (OnAndroid)
            {
                openHomePage = x => x.Class("ButtonRenderer").Index(0);
                openTermsOfServiceLink = x => x.Class("LabelRenderer").Index(2);
            }

            if (OniOS)
            {
                openHomePage = x => x.Class("UIButton").Index(0);
                openTermsOfServiceLink = x => x.Class("UILabel").Index(2);
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("ReAgreeTermsOfServicePageTitle"),
            iOS = x => x.Marked("ReAgreeTermsOfServicePageTitle"),
        };

        /// <summary>
        /// ReAgreeTermsOfServicePageのアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertReAgreeTermsOfServicePage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            AssertOnPage(timeout);
        }

        /// <summary>
        /// HomePageに遷移する.
        /// </summary>
        /// <returns>HomePage.</returns>
        public HomePage OpenHomePage()
        {
            app.Tap(openHomePage);
            return new HomePage();
        }

        /// <summary>
        /// 利用規約(外部ページ)に遷移する.
        /// </summary>
        public void OpenTermsOfServiceLink()
        {
            app.Tap(openTermsOfServiceLink);
        }
    }
}
