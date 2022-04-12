﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// S08_Testsクラス
    /// S-8　動作状況の確認シナリオ.
    /// </summary>
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    [Category("ja-JP")]
    public class S08_Tests : BaseTestFixture
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="platform">動作OS.</param>
        public S08_Tests(Platform platform)
            : base(platform)
        {
        }

        /// <summary>
        /// (Blootooth設定、端末のEN、位置情報)全部オン、BG復帰【動作中】.
        /// </summary>
        [Test]
        public void Case02_Test()
        {
            // タスクキルしていない状態をここで作る
            HomePage home = new HomePage();
            home.AssertHomePage();
            AppManager.ReStartApp();
            app.Screenshot("SplashPage Check");

            // S1 ホーム画面に「動作中」と表示されていること
            home.AssertHomePage();

            // S2 「動作中」の下部の？ボタン押下
        }

        /// <summary>
        /// タスクキル実装中(課題No.71).
        /// </summary>
        [Test]
        public void Case02_1_Test()
        {
            // タスクキルしていない状態をここで作る
            HomePage home = new HomePage();
            home.AssertHomePage();
            app.Invoke("FinishAndRemoveTask:", "UITest");
            AppManager.ReStartApp();
            app.Screenshot("SplashPage Check");

            // S1 ホーム画面に「動作中」と表示されていること
            home.AssertHomePage();

            // S2 「動作中」の下部の？ボタン押下
        }

        /// <summary>
        /// (Blootooth設定、端末のEN、位置情報)全部オン、再起動【動作中】.
        /// </summary>
        [Test]
        public void Case1_Test()
        {
            // S1 ホーム画面に「動作中」と表示されていること
            HomePage home = new HomePage();
            home.AssertHomePage();

            // S2 「動作中」の下部の？ボタン押下
            home.OpenQuestionMark();
            home.AssertHomePage();
        }
    }
}
