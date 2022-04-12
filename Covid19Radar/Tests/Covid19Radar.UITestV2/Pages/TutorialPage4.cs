using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CovidRadar.UITestV2
{
    /// <summary>
    /// TutorialPage4クラス.
    /// </summary>
    public class TutorialPage4 : BasePage
    {
        /***********
         * チュートリアルページ_4
        ***********/

        private readonly Query openTutorialPage6;
        private readonly Query openTutorialPage6BluetoothOff;
        private readonly Query registDialogOKBtn;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public TutorialPage4()
        {
            registDialogOKBtn = x => x.Id("button2"); // 「登録をキャンセルしました」ダイアログでのOKボタン

            if (OnAndroid)
            {
                openTutorialPage6 = x => x.Marked("TutorialPage4Title").Class("ButtonRenderer").Index(0);
                openTutorialPage6BluetoothOff = x => x.Marked("TutorialPage4Title").Class("ButtonRenderer").Index(1); // BluetoothOFF
            }

            if (OniOS)
            {
                openTutorialPage6 = x => x.Marked("TutorialPage4Title").Class("UIButton").Index(0);
                openTutorialPage6BluetoothOff = x => x.Marked("TutorialPage4Title").Class("UIButton").Index(1); // BluetoothOFF
            }
        }

        /// <summary>
        /// ページオブジェクトクエリ.
        /// </summary>
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TutorialPage4Title"),
            iOS = x => x.Marked("TutorialPage4Title"),
        };

        /// <summary>
        /// TutorialPage4のアサーション.
        /// </summary>
        /// <param name="timeout">タイムアウト値.</param>
        public void AssertTutorialPage4(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            AssertOnPage(timeout);
        }

        /// <summary>
        /// 「有効にする」ボタンを押下し、TutorialPage6に遷移する.
        /// </summary>
        /// <returns>TutorialPage6.</returns>
        public TutorialPage6 OpenTutorialPage6()
        {
            app.Tap(openTutorialPage6);
            return new TutorialPage6();
        }

        /// <summary>
        /// 「あとで設定する」ボタンを押下し、TutorialPage6に遷移する.
        /// </summary>
        /// <returns>TutorialPage6.</returns>
        public TutorialPage6 OpenTutorialPage6BluetoothOff()
        {
            app.ScrollDownTo("TutorialPage4Button_2", "TutorialPage4ScrollView");
            app.Tap(openTutorialPage6BluetoothOff);
            return new TutorialPage6();
        }
    }
}
