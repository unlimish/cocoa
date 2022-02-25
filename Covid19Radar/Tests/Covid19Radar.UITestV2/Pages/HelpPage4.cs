using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class HelpPage4 : BasePage
    {
        /***********
         * 接触の記録を停止/情報を削除するには
        ***********/

        readonly Query toolBarBack;
        readonly Query openSettingsPage;
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HelpPage4Title"),
            iOS = x => x.Marked("HelpPage4Title")
        };

        public HelpPage4()
        {
            

            if (OnAndroid)
            {
                toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("AppCompatImageButton").Index(0); //戻るボタン
                openSettingsPage = x => x.Marked("MasterDetailPageTitle").Class("ButtonRenderer").Index(0); //「アプリの設定へ」ボタン
            }

            if (OniOS)
            {
                toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("UIButton").Index(0); //戻るボタン
                openSettingsPage = x => x.Marked("MasterDetailPageTitle").Class("UIButton").Index(0); //「アプリの設定へ」ボタン
            }
        }

        // メニュー表示確認
        public void AssertHelpPage4(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }
        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }

        public SettingsPage OpenSettingsPage()
        {
            app.Tap(openSettingsPage);
            return new SettingsPage();
        }





    }
}
