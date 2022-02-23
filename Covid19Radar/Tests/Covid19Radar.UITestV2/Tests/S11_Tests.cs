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
    public class S11_Tests : BaseTestFixture
    {
        public S11_Tests(Platform platform)
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

            //S2 「使い方」画面で、「接触の有無はどのように知ることができますか？」ボタンを押下
            HelpPage2 helpPage2 = helpMenuPage.OpenHelpPage2();
            helpPage2.AssertHelpPage2();
        }

    }
}
