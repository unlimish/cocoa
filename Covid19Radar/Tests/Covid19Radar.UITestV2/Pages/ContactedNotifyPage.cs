﻿using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class ContactedNotifyPage : BasePage
    {

        /***********
         * 過去14日間の接触
        ***********/

        readonly Query openIntroducePopup;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("NotContactPageTitle"),
            iOS = x => x.Marked("NotContactPageTitle")
        };

        public ContactedNotifyPage()
        {
            

            if (OnAndroid)
            {
                openIntroducePopup = x => x.Marked("NotContactPageTitle").Class("ButtonRenderer").Index(0);//処理番号の取得方法
            }

            if (OniOS)
            {
                openIntroducePopup = x => x.Marked("NotContactPageTitle").Class("UIButton").Index(0);//処理番号の取得方法
            }
        }

        // メニュー表示確認
        public void AssertContactedNotify(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public void OpenIntroducePopup()
        {
            app.Tap(openIntroducePopup);
        }

    }
}
