using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X_Forms.PersonenDb.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(X_Forms.Droid.Services.AndroidJsonService))]
namespace X_Forms.Droid.Services
{
    public class AndroidJsonService : IJsonService
    {
        private static string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "jsonFile.txt");
        public T LoadJson<T>()
        {
            if (!File.Exists(path))
                File.Create(path).Dispose();

            string jsonString = File.ReadAllText(path);

            if (!string.IsNullOrWhiteSpace(jsonString))
                return JsonConvert.DeserializeObject<T>(jsonString);
            else
                return default(T);
        }

        public void SaveJson(object data)
        {
            string jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, jsonString);
        }
    }
}