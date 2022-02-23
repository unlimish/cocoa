using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class TutorialPage3 : BasePage
    {
        /***********
         * チュートリアルページ_3
        ***********/

        readonly Query openPrivacyPolicyPage;
        readonly Query NetworkErrorDialogOKBtn;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TutorialPage3Title"),
            iOS = x => x.Marked("TutorialPage3Title")
        };

        public TutorialPage3()
        {

            
            NetworkErrorDialogOKBtn = x => x.Id("button1");//通信エラー時に、「規約に同意して次へ」押下時に出現するダイアログのOKボタン


            if (OnAndroid)
            {
                openPrivacyPolicyPage = x => x.Marked("TutorialPage3Title").Class("ButtonRenderer").Index(0);
            }

            if (OniOS)
            {
                openPrivacyPolicyPage = x => x.Marked("TutorialPage3Title").Class("UIButton").Index(0);
            }
        }

        // メニュー表示確認
        public void AssertTutorialPage3(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }

        public PrivacyPolicyPage OpenPrivacyPolicyPage()
        {
            app.Tap(openPrivacyPolicyPage);
            return new PrivacyPolicyPage();
        }

        public void TapOpenPrivacyPolicyPage()
        {
            //wifi通信エラー時にボタン押下するケース用のメソッド
            app.Tap(openPrivacyPolicyPage);
            app.Tap(NetworkErrorDialogOKBtn);
        }






    }
}
