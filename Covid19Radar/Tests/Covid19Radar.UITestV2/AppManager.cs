using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;



namespace CovidRadar.UITestV2
{
    static class AppManager
    {
        public static string GetPath()
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6);

            path = path.Replace("Covid19Radar\\Tests\\Covid19Radar.UITestV2\\bin\\Release", "precompiledApps");
            path = path + "/APP_PACKAGE_NAME.APP_PACKAGE_NAME.apk";

            return path;
        }

        private static string ApkPath = GetPath();
        public const string AppPath = "../../../../Covid19Radar.iOS/bin/iPhoneSimulator/Release/Covid19Radar.iOS.app";

        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {

            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    .ApkFile(ApkPath)
                    .StartApp();
            }

            if (Platform == Platform.iOS)
            {
                app = ConfigureApp
                    .iOS
                    .AppBundle(AppPath)
                    .StartApp();
            }
        }

        public static void ReStartApp()
        {

            if (Platform == Platform.Android)
            {
                ConfigureApp.Android.ApkFile(ApkPath).StartApp(AppDataMode.DoNotClear);
            }

            if (Platform == Platform.iOS)
            {
                ConfigureApp.iOS.AppBundle(AppPath).StartApp(AppDataMode.DoNotClear);
            }
        }

        public static JToken Comparison(string lang , string value)
        {
            StreamReader fileName = new StreamReader(lang + ".json");
            string allLine = fileName.ReadToEnd();
            JObject jsonObj = JObject.Parse(allLine);
            return jsonObj[value]["value"];

        }

        public static String GetCurrentCultureBackDoor()
        {
            //端末言語取得
            string cultureText = "en-US";
            if (Platform == Platform.Android)
            {
                cultureText = app.Invoke("GetCurrentCulture").ToString();
            }
            if (Platform == Platform.iOS)
            {
                cultureText = app.Invoke("GetCurrentCulture:", "UITest").ToString();
            }

            if (cultureText == "en")
            {
                cultureText = "en-US";
            }
            else if (cultureText == "ja")
            {
                cultureText = "ja-JP";
            }
            else if (cultureText == "ko")
            {
                cultureText = "en-US";
            }
            else if (cultureText == "ko-KR")
            {
                cultureText = "en-US";
            }
            return cultureText;
        }


        public static String GetTitleText()
        {
            var title = "";

            if (Platform == Platform.Android)
            {
                title = app.Query(x => x.Css("h1"))[0].TextContent;
            }
            if (Platform == Platform.iOS)
            {
                title = app.Query(c => c.Class("WKWebView").Css("H1"))[0].TextContent;
            }

            return title;
        }


        public static String RegistResultBranch(String cultureText)
        {
            string ComparisonText = "";
            if (Platform == Platform.Android)
            {
                //センターに接続できません
                ComparisonText = (string)AppManager.Comparison(cultureText, "ExposureNotificationHandler2ErrorMessage");
            }

            if (Platform == Platform.iOS)
            {
                //登録が完了しました
                ComparisonText = (string)AppManager.Comparison(cultureText, "NotifyOtherPageDialogSubmittedTitle");
            }

            return ComparisonText;

        }

        public static String RegistResultBranch2(String cultureText)
        {
            string ComparisonText = "";
            if (Platform == Platform.Android)
            {
                //センターに接続できません
                ComparisonText = (string)AppManager.Comparison(cultureText, "ExposureNotificationHandler2ErrorMessage");
            }

            if (Platform == Platform.iOS)
            {
                //処理番号が誤っているか、有効期限が切れています
                ComparisonText = (string)AppManager.Comparison(cultureText, "ExposureNotificationHandler1ErrorMessage");
            }

            return ComparisonText;

        }
    }
}
