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
    [Category("ja-JP")]
    public class S13_Tests : BaseTestFixture
    {
        public S13_Tests(Platform platform)
            : base(platform)
        {
        }





        public void S13(int count = 2)
        {
            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            //S1 ホーム画面で、ハンバーガーメニューを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S2 ハンバーガーメニューで、「設定」ボタンを押下
            SettingsPage settingsPage = menuPage.OpenSettingsPage();
            settingsPage.AssertSettingsPage();

            //S3 「設定」画面で、「アプリを初期化」ボタンを押下
            settingsPage.TapSyokika();
            settingsPage.AssertSettingsPage();

            //S4 「設定」画面で、「アプリの初期化を行います」ポップアップで「キャンセル」ボタンを押下
            settingsPage.TapDialogCancelBtn();
            settingsPage.AssertSettingsPage();

            //S5 「設定」画面で、「アプリを初期化」ボタンを押下
            settingsPage.TapSyokika();
            settingsPage.AssertSettingsPage();

            //S6 「設定」画面で、「アプリの初期化を行います」ポップアップで「OK」ボタンを押下
            settingsPage.TaplDialogOKBtn();
            settingsPage.AssertSettingsPage();

            //S7 初期化
            settingsPage.TaplDialogOKBtn();

            AppManager.ReStartApp();
            TutorialPage1 tutorialPage1 = new TutorialPage1();


            try
            {
                tutorialPage1.AssertTutorialPage1();
            }
            catch (Exception e)
            {
                if (count > 0)
                {
                    count--;
                    S13(count);
                }
                else
                {
                    throw e;
                }
            }

        }



        [Test]
        public void Case01_Test()
        {
            S13();

        }





    }
}
