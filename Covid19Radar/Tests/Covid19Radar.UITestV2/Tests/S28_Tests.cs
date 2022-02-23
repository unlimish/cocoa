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
    public class S28_Tests : BaseTestFixture

    {
        public S28_Tests(Platform platform)
            : base(platform)
        {
        }


        [Test]
        public void Case01_Test()
        {
            //前提 : 日本語、英語、中国語以外

            /* S1
             * 【iOS】　
             *  OSの設定 > 一般 > 言語と地域
             * 「編集」ボタンを押下し、「使用する言語の優先順序」内の項目を[前提]の言語以外を削除する
             */

            //S2 COCOAアプリを起動

            //S3 アプリ起動時の初期表示を確認
            HomePage home = new HomePage();
            home.AssertHomePage();

            //HOMEPAGEのbuttonテキスト取得
            var homepagebuttontitle = app.Query(x => x.Marked("MasterDetailPageTitle").Class("buttonRenderer").Index(0))[0];

            //端末言語取得
            var culture = app.Invoke("GetCurrentCulture");

            //言語から比較する単語をjsonから取得
            string ComparisonText = (string)AppManager.Comparison("en-US", "HomePageDescription2");

            //比較
            //期待値 : 遷移したホーム画面の言語が英語になっていること
            Assert.AreEqual(homepagebuttontitle.Text, ComparisonText);

        }


    }
}
