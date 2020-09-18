using System;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Reflection;

namespace ConfigBuildConfig
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            var data = LoadFileToList("myfolder");

            Console.WriteLine(data.Environment);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        public static ClientProperties LoadFileToList(string clientName)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            string filePath = "ConfigBuildConfig.ClientResources." + clientName + ".config.json";

            Stream stream = assembly.GetManifestResourceStream(filePath);

            ClientProperties clientProperties;

            using (StreamReader sr = new StreamReader(stream))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    clientProperties = serializer.Deserialize<ClientProperties>(reader);
                }
            }

            return clientProperties;
        }
    }
}
