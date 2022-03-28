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
    public class S07_Tests : BaseTestFixture
    {
        public S07_Tests(Platform platform)
            : base(platform)
        {
        }





        [Test]
        public void Case01_1_Test()
        //S-7の遷移確認のみを行うシナリオ
        {
            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            //ホーム画面で、ハンバーガーメニューを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //ハンバーガーメニューから、デバッグメニューを押下
            DebugPage debugPage = menuPage.OpenDebugPage();
            debugPage.AssertDebugPage();

            //デバッグメニューで「ReAgreePrivacyPolicyPage」ボタンを押下し、「プライバシーポリシーの改定」画面に遷移
            ReAgreePrivacyPolicyPage reAgreePrivacyPolicyPage = debugPage.OpenReAgreePrivacyPolicyPage();
            reAgreePrivacyPolicyPage.AssertReAgreePrivacyPolicyPage();

            //「プライバシーポリシーの改定」画面で「確認しました」ボタンを押下し、ホーム画面に遷移
            reAgreePrivacyPolicyPage.OpenHomePage();
            homePage.AssertHomePage();

            //ホーム画面で、ハンバーガーメニューを押下
            homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //ハンバーガーメニューから、デバッグメニューを押下
            menuPage.OpenDebugPage();
            debugPage.AssertDebugPage();

            //デバッグメニューで「ReAgreeTermsOfServicePage」ボタンを押下し、「利用規約の改定」画面に遷移
            ReAgreeTermsOfServicePage reAgreeTermsOfService = debugPage.OpenReAgreeTermsOfServicePage();
            reAgreeTermsOfService.AssertReAgreeTermsOfServicePage();

            //「利用規約の改定」画面で「確認しました」ボタンを押下し、ホーム画面に遷移
            reAgreeTermsOfService.OpenHomePage();
            homePage.AssertHomePage();

        }

        [Test]
        public void Case01_2_Test()
        //S-7のプライバシーポリシーの改訂画面の確認を行うシナリオ
        {
            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            //ホーム画面で、ハンバーガーメニューを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //ハンバーガーメニューから、デバッグメニューを押下
            DebugPage debugPage = menuPage.OpenDebugPage();
            debugPage.AssertDebugPage();

            //デバッグメニューで「ReAgreePrivacyPolicyPage」ボタンを押下し、「プライバシーポリシーの改定」画面に遷移
            ReAgreePrivacyPolicyPage reAgreePrivacyPolicyPage = debugPage.OpenReAgreePrivacyPolicyPage();
            reAgreePrivacyPolicyPage.AssertReAgreePrivacyPolicyPage();

            //「プライバシーポリシーの改定」画面で「プライバシーポリシーを確認する」リンクを押下し、外部ページに遷移
            reAgreePrivacyPolicyPage.OpenPrivacyPolicyLink();
            Thread.Sleep(5000);

            //スクリーンショットを取得して終了
            app.Screenshot("Browser Check");
            if (OnAndroid)
            {
                app.Invoke("FinishAndRemoveTask");
            }
        }
        [Test]
        public void Case01_3_Test()
        //S-7の利用来の改訂画面の確認を行うシナリオ
        {
            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            //ホーム画面で、ハンバーガーメニューを押下
            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            //ハンバーガーメニューから、デバッグメニューを押下
            DebugPage debugPage = menuPage.OpenDebugPage();
            debugPage.AssertDebugPage();

            //デバッグメニューで「ReAgreeTermsOfServicePage」ボタンを押下し、「利用規約の改定」画面に遷移
            ReAgreeTermsOfServicePage reAgreeTermsOfService = debugPage.OpenReAgreeTermsOfServicePage();
            reAgreeTermsOfService.AssertReAgreeTermsOfServicePage();

            //「利用規約の改定」画面で「利用規約を確認する」リンクを押下し、外部ページに遷移
            reAgreeTermsOfService.OpenTermsOfServiceLinkLink();
            Thread.Sleep(5000);

            //スクリーンショットを取得して終了
            app.Screenshot("Browser Check");
            if (OnAndroid)
            {
                app.Invoke("FinishAndRemoveTask");
            }
        }
    }
}
