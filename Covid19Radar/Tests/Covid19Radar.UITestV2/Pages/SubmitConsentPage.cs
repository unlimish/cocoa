using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class SubmitConsentPage : BasePage
    {
        /***********
         * 陽性登録への同意
        ***********/

        readonly Query openNotifyOtherPage;
        readonly Query toolBarBack;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("SubmitConsentPageTitle"),
            iOS = x => x.Marked("SubmitConsentPageTitle")
        };

        public SubmitConsentPage()
        {

            

            if (OnAndroid)
            {
                //(陽性登録への同意画面)
                openNotifyOtherPage = x => x.Marked("SubmitConsentPageTitle").Class("ButtonRenderer").Index(0); //同意して登録する
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); //戻るボタン
            }

            if (OniOS)
            {
                //(陽性登録への同意画面)
                openNotifyOtherPage = x => x.Marked("SubmitConsentPageTitle").Class("UIButton").Index(0); //同意して登録する
                toolBarBack = x => x.Class("UIButton").Index(1); //戻るボタン
            }
        }

        // ページ表示確認
        public void AssertSubmitConsentPage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);

        }

        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }

        public NotifyOtherPage OpenNotifyOtherPage()
        {

            app.ScrollDownTo("SubmitConsentPageScrollBtn", "SubmitConsentPageScrollView");
            app.Tap(openNotifyOtherPage);
            return new NotifyOtherPage();
        }

    }

}
