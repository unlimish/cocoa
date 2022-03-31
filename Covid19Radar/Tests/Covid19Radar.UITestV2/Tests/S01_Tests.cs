using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CovidRadar.UITestV2
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    [Category("ja-JP")]
    public class S01_Tests : BaseTestFixture
    {
        public S01_Tests(Platform platform)
            : base(platform)
        {
        }

        [TearDown]
        public override void TearDown()
        {
            app.Screenshot("(Manual) BottomSheet Check");
        }


        [Test]
        public void Case01_Test()
        {
            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            //S1 ホーム画面で、「陽性者との接触を確認する」ボタンを押下
            ExposureCheckPage exposureCheckPage = homePage.OpenExposureCheckPage();
            exposureCheckPage.AssertExposureCheckPage();

            //S2 過去１４日間の接触画面で、「アプリを周りの人に知らせる」ボタンを押下
            exposureCheckPage.OpenIntroducePopup();

            //ボトムシートが立ち上がるまで待機
            Thread.Sleep(3000);

        }




    }
}
