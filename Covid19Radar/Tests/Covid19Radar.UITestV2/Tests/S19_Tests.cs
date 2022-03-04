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
    [Culture("ja-JP")]
    public class S19_Tests : BaseTestFixture

    {
        public S19_Tests(Platform platform)
            : base(platform)
        {
        }


        [Test]
        public void Case01_Test()
        {

            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            // S1 ホーム画面で、ハンバーガーメニューを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            // S2 ハンバーガーメニューで、「お問い合わせ」ボタンを押下
            InqueryPage inqueryPage = menuPage.OpenInqueryPage();
            inqueryPage.AssertInqueryPage();

            // S3 「アプリに関するお問い合わせ」画面で、「接触確認アプリに関する情報」のリンクを押下
            inqueryPage.TapAppImfoLink();
            //app.Screenshot("AppImfo");
        }

        
        [TearDown]
        public override void TearDown()
        {
            if (OnAndroid)
            {
                app.Invoke("FinishAndRemoveTask");
            }
        }
        

    }
}
