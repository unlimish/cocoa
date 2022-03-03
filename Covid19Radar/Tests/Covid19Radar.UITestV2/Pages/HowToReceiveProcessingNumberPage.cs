﻿using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class HowToReceiveProcessingNumberPage : BasePage
    {
        
        readonly Query ToolBarBtn;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HowToReceiveProcessingNumberPageTitle"),
            iOS = x => x.Marked("HowToReceiveProcessingNumberPageTitle")
        };

        public HowToReceiveProcessingNumberPage()
        {
            



            if (OnAndroid)
            {
    
                ToolBarBtn = x => x.Id("toolbar").Class("AppCompatImageButton").Index(0); //戻るボタン
                //ToolBarBtn = x => x.Marked("MasterDetailPageTitle").Class("AppCompatImageButton").Index(0); //戻るボタン
            }

            if (OniOS)
            {
                ToolBarBtn = x => x.Id("toolbar").Class("UIButton").Index(0); //戻るボタン
            }
        }

        // メニュー表示確認
        public void AssertHowToReceiveProcessingNumberPage(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }
        public void ToolBarBack()
        {
            app.Tap(ToolBarBtn);
        }







    }
}