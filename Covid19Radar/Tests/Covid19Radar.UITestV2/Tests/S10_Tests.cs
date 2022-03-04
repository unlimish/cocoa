using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Queries;

namespace CovidRadar.UITestV2
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    [Culture("ja-JP")]
    public class S10_Tests : BaseTestFixture
    {
        public S10_Tests(Platform platform)
            : base(platform)
        {
        }


        [Test]
        public void Case01_Test()
        {

            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            //S1 ホーム画面で、ハンバーガーメニュー内の「使い方」ボタンを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            HelpMenuPage helpMenuPage = menuPage.OpenHelpMenuPage();
            helpMenuPage.AssertHelpMenuPage();

            //S2 「使い方」画面で、「どのように接触を記録していますか？」ボタンを押下
            HelpPage1 helpPage1 = helpMenuPage.OpenHelpPage1();
            helpPage1.AssertHelpPage1();
        }

    }
}
