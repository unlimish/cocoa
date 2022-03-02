using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CovidRadar.UITestV2
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class S21_Tests : BaseTestFixture

    {
        public S21_Tests(Platform platform)
            : base(platform)
        {
        }


        [Test]
        public void Case01_Test()
        {
            /* S1
             * 【iOS】　
             *  OSの設定 > 一般 > 言語と地域
             * 「編集」ボタンを押下し、「使用する言語の優先順序」内の項目を[前提]の言語以外を削除する
             */

            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            // S2 ホーム画面で、ハンバーガーメニューを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            // S3 ハンバーガーメニューで、「プライバシーポリシー」ボタンを押下
            PrivacyPolicyPage2 privacyPolicyPage2 = menuPage.OpenPrivacyPolicyPage2();
            privacyPolicyPage2.AssertPrivacyPolicyPage2();

            //タイトル取得
            var privacypolicytitle = app.Query(x => x.Css("h1"))[0];

            if (OniOS)
            {
                var privacypolicytitle = app.Query(c => c.Class("WKWebView").Css("H1"))[0];
            }

            //端末言語取得
            var cultureText = AppManager.GetCurrentCultureBackDoor();

            //言語から比較する単語をjsonから取得
            string ComparisonText = (string)AppManager.Comparison(cultureText, "privacypolicyhtml");

            //比較
            Assert.AreEqual(privacypolicytitle.TextContent, ComparisonText);

        }

    }
}
