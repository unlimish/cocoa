using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// S01_Testsクラス
    /// S-1　陽性者との接触確認シナリオ.
    /// </summary>
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    [Category("ja-JP")]
    public class S01_Tests : BaseTestFixture
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="platform">動作OS.</param>
        public S01_Tests(Platform platform)
            : base(platform)
        {
        }

        /// <summary>
        /// ボトムシートの表示を確認するためのスクリーンショット取得.
        /// </summary>
        [TearDown]
        public override void TearDown()
        {
            app.Screenshot("(Manual) BottomSheet Check");
        }

        /// <summary>
        /// 濃厚接触0回(日本語).
        /// </summary>
        [Test]
        public void Case01_Test()
        {
            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            // S1 ホーム画面で、「陽性者との接触を確認する」ボタンを押下
            ExposureCheckPage exposureCheckPage = homePage.OpenExposureCheckPage();
            exposureCheckPage.AssertExposureCheckPage();

            // S2 過去１４日間の接触画面で、「アプリを周りの人に知らせる」ボタンを押下
            exposureCheckPage.OpenIntroducePopup();

            // ボトムシートが立ち上がるまで待機
            Thread.Sleep(3000);
        }
    }
}
