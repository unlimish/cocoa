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
    [Category("ko-KR")]
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


            //言語から比較する単語をjsonから取得
            string ComparisonText = (string)AppManager.Comparison("en-US", "HomePageDescription2");

            app.WaitForElement(x => x.Text(ComparisonText));
            var message = app.Query(x => x.Text(ComparisonText))[0];

            //S4(文字比較) 「登録が完了しました」ポップアップが表示されること
            Assert.AreEqual(message.Text, ComparisonText);

        }


    }
}
