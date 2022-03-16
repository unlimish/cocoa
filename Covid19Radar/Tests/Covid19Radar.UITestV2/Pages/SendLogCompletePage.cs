using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class SendLogCompletePage : BasePage
    {
        /***********
         * 動作情報の送信
        ***********/

        readonly Query openMail;



        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("SendLogCompletePageTitle"),
            iOS = x => x.Marked("SendLogCompletePageTitle")
        };

        public SendLogCompletePage()
        {

            if (OnAndroid)
            {
                openMail = x => x.Marked("SendLogCompletePageTitle").Class("ButtonRenderer").Index(0); //メールで動作情報IDを送信する
            }

            if (OniOS)
            {
                openMail = x => x.Class("UIButton").Index(0); //メールで動作情報IDを送信する

            }
        }

        // メニュー表示確認
        public void AssertSendLogCompletePage(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public void OpenMail()
        {
            app.Tap(openMail);
        }






    }
}
