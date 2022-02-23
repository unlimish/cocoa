using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class ExposureCheckPage : BasePage
    {

        /***********
         * 過去14日間の接触
        ***********/

        readonly Query openIntroducePopup;
        readonly Query toolBarBack;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("ExposureCheckPageTitle"),
            iOS = x => x.Marked("ExposureCheckPageTitle")
        };

        public ExposureCheckPage()
        {
            openIntroducePopup = x => x.Marked("ExposureCheckPageTitle").Class("ButtonRenderer").Index(0);//処理番号の取得方法
            toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("AppCompatImageButton").Index(0); //戻るボタン

            if (OnAndroid)
            {
            }

            if (OniOS)
            {

            }
        }

        // メニュー表示確認
        public void AssertExposureCheckPage(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }

        public void OpenIntroducePopup()
        {
            app.Tap(openIntroducePopup);
        }

        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }
    }
}
