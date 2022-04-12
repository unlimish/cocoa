﻿using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// SendLogConfirmationPageクラス.
    /// </summary>
    public class SendLogConfirmationPage : BasePage
    {
        /***********
         * 動作情報の送信
        ***********/

        private readonly Query toolBarBack;
        private readonly Query openMenuPage;
        private readonly Query submitConsentPageBtn;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public SendLogConfirmationPage()
        {
            if (OnAndroid)
            {
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); // 戻るボタン
                openMenuPage = x => x.Class("AppCompatImageButton").Index(0); // ハンバーガーメニュー
                submitConsentPageBtn = x => x.Marked("SendLogConfirmationPageTitle").Class("ButtonRenderer").Index(0); // 登録するボタン
            }

            if (OniOS)
            {
                toolBarBack = x => x.Class("UIButton").Index(1); // 戻るボタン
                openMenuPage = x => x.Class("UIButton").Marked("OK"); // ハンバーガーメニュー
                submitConsentPageBtn = x => x.Marked("SendLogConfirmationPageTitle").Class("UIButton").Index(0); // 登録するボタン
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("SendLogConfirmationPageTitle"),
            iOS = x => x.Marked("SendLogConfirmationPageTitle"),
        };

        /// <summary>
        /// SendLogConfirmationPageのアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertSendLogConfirmationPage(TimeSpan? timeout = default(TimeSpan?))
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

        /// <summary>
        /// SubmitConsentPageに遷移する.
        /// </summary>
        /// <returns>SendLogCompletePage.</returns>
        public SendLogCompletePage OpenSubmitConsentPage()
        {
            app.ScrollDownTo("SendLogConfirmationPageButton", "SendLogConfirmationPageScrollView");
            app.Tap("SendLogConfirmationPageButton");
            return new SendLogCompletePage();
        }
    }
}
