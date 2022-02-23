using System;
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
            openIntroducePopup = x => x.Marked("MasterDetailPageTitle").Class("ButtonRenderer").Index(0);//処理番号の取得方法

            if (OnAndroid)
            {
            }

            if (OniOS)
            {

            }
        }

        // メニュー表示確認
        public void AssertContactedNotify(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }

        public void OpenIntroducePopup()
        {
            app.Tap(openIntroducePopup);
        }

    }
}
