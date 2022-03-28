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
            Android = x => x.Marked("ContactedNotifyPageTitle"),
            iOS = x => x.Marked("ContactedNotifyPageTitle")
        };

        public ContactedNotifyPage()
        {
            

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
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public void OpenIntroducePopup()
        {
            app.Tap(openIntroducePopup);
        }

    }
}
