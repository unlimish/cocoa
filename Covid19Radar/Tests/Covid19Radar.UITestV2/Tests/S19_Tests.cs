﻿using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// S19_Testsクラス
    /// S-19　使い方-接触記録方法の確認シナリオ.
    /// </summary>
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    [Category("ja-JP")]
    public class S19_Tests : BaseTestFixture
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="platform">動作OS.</param>
        public S19_Tests(Platform platform)
            : base(platform)
        {
        }

        /// <summary>
        /// ホーム画面から接触確認アプリに関する情報画面までの遷移確認.
        /// </summary>
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

            // Browserが立ち上がるまで待機
            Thread.Sleep(5000);
        }

        /// <summary>
        /// 遷移を確認するためのスクリーンショット取得と、アプリを確実に終了するための処理.
        /// </summary>
        [TearDown]
        public override void TearDown()
        {
            app.Screenshot("(Manual) Browser Check");
            if (OnAndroid)
            {
                app.Invoke("FinishAndRemoveTask");
            }
        }
    }
}
