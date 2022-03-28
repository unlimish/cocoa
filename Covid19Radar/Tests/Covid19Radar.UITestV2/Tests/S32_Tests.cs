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
 //   [Category("ja-JP")]
 //   [Category("en-US")]
 //   [Category("zh-CN")]
 //   [Category("ko-KR")]
    public class S32_Tests : BaseTestFixture

    {
        public S32_Tests(Platform platform)
            : base(platform)
        {
        }


        [Test]
        public void Case01_Test()
        {
            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            //ホーム画面で、ハンバーガーメニューを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //ハンバーガーメニューから、デバッグメニューを押下
            DebugPage debugPage = menuPage.OpenDebugPage();
            debugPage.AssertDebugPage();

            //デバッグメニューで「ContactedNotifyPage」ボタンを押下し、接触あり状態の「過去14日間の接触確認」画面に遷移
            ContactedNotifyPage contactedNotifyPage = debugPage.OpenContactedNotifyPage();
            contactedNotifyPage.AssertContactedNotify();
        }

    }
}
