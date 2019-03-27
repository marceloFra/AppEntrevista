using System;

using Android.App; 
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS; 
using Android;
using System.Threading.Tasks;
using Android.Content;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android.Content.PM;

namespace AppEntrevista.Droid
{
    [Activity(Label = "AppEntrevista", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            //if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.RecordAudio) != Permission.Granted)
            //{
            //    ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.RecordAudio }, 1);
            //}

            ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage,
                Manifest.Permission.RecordAudio,
                Manifest.Permission.ReadExternalStorage,
                Manifest.Permission.ManageDocuments,
                Manifest.Permission.MediaContentControl }, 1);


        }

        // Field, properties, and method for Video Picker
        public static MainActivity Current { private set; get; }

        public static readonly int PickImageId = 1000;

        public TaskCompletionSource<string> PickImageTaskCompletionSource { set; get; }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (data != null))
                {
                    // Set the filename as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(data.DataString);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }





    }
}