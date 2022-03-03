﻿using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class HelpPage3 : BasePage
    {
        /***********
         * 新型コロナウイルスに感染していると判定されたら
        ***********/

        readonly Query toolBarBack;
        readonly Query openSubmitConsentPage;



        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HelpPage3Title"),
            iOS = x => x.Marked("HelpPage3Title")
        };

        public HelpPage3()
        {
            


            if (OnAndroid)
            {
                toolBarBack = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); //戻るボタン
                openSubmitConsentPage = x => x.Marked("HelpPage3Title").Class("ButtonRenderer").Index(0); //陽性情報を登録
            }

            if (OniOS)
            {
                toolBarBack = x => x.Id("BackButton").Class("UIButton").Index(0); //戻るボタン
                openSubmitConsentPage = x => x.Marked("HelpPage3Title").Class("UIButton").Index(0); //陽性情報を登録
            }
        }

        // メニュー表示確認
        public void AssertHelpPage3(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }
        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }

        public SubmitConsentPage OpenSubmitConsentPage()
        {
            
            if (OnAndroid)
            {
                app.ScrollDownTo(openSubmitConsentPage);
            }

            if (OniOS)
            {
                app.ScrollDownTo("HelpPage3Btn", "HelpPage3ScrollView");
            }
            app.Tap(openSubmitConsentPage);
            return new SubmitConsentPage();
        }






    }
}