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
    [Category("ja-JP")]
    public class S07_Tests : BaseTestFixture
    {
        public S07_Tests(Platform platform)
            : base(platform)
        {
        }





        [Test]
        public void Case01_Test()
        {
            TimeSpan ts1 = new TimeSpan(0, 0, 10);
            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            //S9 ホーム画面で、ハンバーガーメニューを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            menuPage.OpenDebugPage();
            app.ScrollDownTo("ReAgreePrivacyPolicyPageBtn", "DebugPageScrollView", ScrollStrategy.Auto, 0.67, 3000, true, ts1);
            app.Tap("ReAgreePrivacyPolicyPageBtn");
            app.ScrollDownTo("ReAgreeTermsOfServicePageBtn", "DebugPageScrollView", ScrollStrategy.Auto, 0.67, 3000, true, ts1);
            app.Tap("ReAgreeTermsOfServicePageBtn");
            AppManager.ReStartApp();

        }




    }
}
