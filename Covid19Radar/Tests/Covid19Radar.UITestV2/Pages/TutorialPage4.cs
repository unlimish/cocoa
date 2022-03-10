using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class TutorialPage4 : BasePage
    {
        /***********
         * チュートリアルページ_4
        ***********/

        readonly Query openTutorialPage6;
        readonly Query openTutorialPage6BluetoothOff;
        readonly Query RegistDialogOKBtn;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TutorialPage4Title"),
            iOS = x => x.Marked("TutorialPage4Title")
        };

        public TutorialPage4()
        {

            
            RegistDialogOKBtn = x => x.Id("button2");//「登録をキャンセルしました」ダイアログでのOKボタン



            if (OnAndroid)
            {
                openTutorialPage6 = x => x.Marked("TutorialPage4Title").Class("ButtonRenderer").Index(0);
                openTutorialPage6BluetoothOff = x => x.Marked("TutorialPage4Title").Class("ButtonRenderer").Index(1); //BluetoothOFF
            }

            if (OniOS)
            {
                openTutorialPage6 = x => x.Marked("TutorialPage4Title").Class("UIButton").Index(0);
                openTutorialPage6BluetoothOff = x => x.Marked("TutorialPage4Title").Class("UIButton").Index(1); //BluetoothOFF
            }
        }

        // メニュー表示確認
        public void AssertTutorialPage4(TimeSpan? timeout = default(TimeSpan?))
        {
            app.Screenshot(this.GetType().Name.ToString());
            base.AssertOnPage(timeout);
        }

        public TutorialPage6 OpenTutorialPage6()
        {
            app.Tap(openTutorialPage6);
            //app.Repl();
            return new TutorialPage6();
        }

        public TutorialPage6 OpenTutorialPage6BluetoothOff()
        {

            app.ScrollDownTo("TutorialPage4Button_2", "TutorialPage4ScrollView");
            app.Tap(openTutorialPage6BluetoothOff);
            return new TutorialPage6();
        }







    }
}
