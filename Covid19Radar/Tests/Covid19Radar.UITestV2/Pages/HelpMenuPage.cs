using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class HelpMenuPage : BasePage
    {
        /***********
         * 使い方メニュー
        ***********/

        readonly Query openHelpPage1;
        readonly Query openHelpPage2;
        readonly Query openHelpPage3;
        readonly Query openHelpPage4;
        readonly Query toolBarBack;
        readonly Query openMenuPage;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HelpMenuPageTitle"),
            iOS = x => x.Marked("HelpMenuPageTitle")
        };

        public HelpMenuPage()
        {
            

            if (OnAndroid)
            {
                openHelpPage1 = x => x.Marked("HelpMenuPageTitle").Class("LabelRenderer").Index(0); //どのようにして接触を記録していますか？
                openHelpPage2 = x => x.Marked("HelpMenuPageTitle").Class("LabelRenderer").Index(1); //接触の有無はどのように知ることができますか？
                openHelpPage3 = x => x.Marked("HelpMenuPageTitle").Class("LabelRenderer").Index(2); //新型コロナウイルスに感染していると判定されたら
                openHelpPage4 = x => x.Marked("HelpMenuPageTitle").Class("LabelRenderer").Index(3); //接触の記録を停止/情報を削除するには
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); //戻るボタン
            }

            if (OniOS)
            {
                openHelpPage1 = x => x.Marked("HelpMenuPageTitle").Class("UILabel").Index(0); //どのようにして接触を記録していますか？
                openHelpPage2 = x => x.Marked("HelpMenuPageTitle").Class("UILabel").Index(1); //接触の有無はどのように知ることができますか？
                openHelpPage3 = x => x.Marked("HelpMenuPageTitle").Class("UILabel").Index(2); //新型コロナウイルスに感染していると判定されたら
                openHelpPage4 = x => x.Marked("HelpMenuPageTitle").Class("UILabel").Index(3); //接触の記録を停止/情報を削除するには
                toolBarBack = x => x.Id("BackButton").Class("UIButton").Index(0); //戻るボタン
                openMenuPage = x => x.Class("UIButton").Index(3);//ハンバーガーメニュー
            }
        }

        // メニュー表示確認
        public void AssertHelpMenuPage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }

        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();

        }

        public HelpPage1 OpenHelpPage1()
        {
            app.Tap(openHelpPage1);
            return new HelpPage1();
        }
        public HelpPage2 OpenHelpPage2()
        {
            app.Tap(openHelpPage2);
            return new HelpPage2();
        }
        public HelpPage3 OpenHelpPage3()
        {
            app.Tap(openHelpPage3);
            return new HelpPage3();
        }
        public HelpPage4 OpenHelpPage4()
        {
            app.Tap(openHelpPage4);
            return new HelpPage4();
        }


    }
}
