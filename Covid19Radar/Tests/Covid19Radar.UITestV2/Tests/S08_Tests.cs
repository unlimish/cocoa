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
    public class S08_Tests : BaseTestFixture
    {
        public S08_Tests(Platform platform)
            : base(platform)
        {
        }


        [Test]
        public void Case01_Test()
        {
            //S1 ホーム画面に「動作中」と表示されていること
            HomePage home = new HomePage();
            home.AssertHomePage();

            //S2 「動作中」の下部の？ボタン押下

        }

        /*バックグラウンドからの起動が実装できないため、手動実行
        [Test]
        public void Case02_Test()
        {

            //タスクキルしていない状態をここで作る
            HomePage home = new HomePage();
            home.AssertHomePage();
            AppManager.ReStartApp();


            //S1 ホーム画面に「動作中」と表示されていること
            home.AssertHomePage();

            //S2 「動作中」の下部の？ボタン押下

        }
        */

        [Test]
        public void Case17_Test()
        {
            //S1 ホーム画面に「動作中」と表示されていること
            HomePage home = new HomePage();
            home.AssertHomePage();

            //S2 「動作中」の下部の？ボタン押下
            home.OpenQuestionMark();
            home.AssertHomePage();
        }

        /* Case19はAndroid11以上端末で実行するという条件の他はCase17と同一であるため、コメントアウト
        [Test]
        public void Case19_Test()
        {
            //前提：Android11以上端末が必要

            //S1 ホーム画面に「動作中」と表示されていること
            HomePage home = new HomePage();
            home.AssertHomePage();

            //S2 「動作中」の下部の？ボタン押下
            home.OpenQuestionMark();
            home.AssertHomePage();
        }
        */
    }
}
