using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            path = path + "/jp.go.mhlw.covid19radar_adhoc_dv_v2.0.0_1645768940.apk";

            return path;
        }

        private static string ApkPath = GetPath();
        public const string AppPath = "../../../Binaries/TaskyiOS.app";
        const string IpaBundleId = "com.xamarin.samples.taskytouch";

    

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
            //string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            //path = path.Substring(6);

            //path = path.Replace("bin\\Release", "Tests");
            string fileName = "Covid19Radar.UITestV2/" + lang + ".json";
            Console.WriteLine(fileName);
            string jsonStr = File.ReadAllText(fileName);
            Console.WriteLine(jsonStr);
  
            JObject jsonObj = JObject.Parse(jsonStr);
            Console.WriteLine(jsonObj);

            return jsonObj[value]["value"];

        }
    }
}
