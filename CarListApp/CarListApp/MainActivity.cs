using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using CarListApp.Adapters;
using CarListApp.Models;

namespace CarListApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var listView = FindViewById<ListView>(Resource.Id.carListView);
            var carAdapter = new CarAdapter(this, GenerateCars());
            listView.Adapter = carAdapter;
        }

        private List<Car> GenerateCars()
        {
            var cars = new List<Car>() {
            new Car (){ Manufacturer = "Volvo", Model = "XC90", Date = 2007, KW= 100 },
            new Car (){ Manufacturer = "MB", Model = "C", Date = 2010, KW= 234 },
            new Car (){ Manufacturer = "BMW", Model = "5 seeria", Date = 2016, KW= 345 },
            new Car (){ Manufacturer = "Ferrari", Model = "360", Date = 2007, KW= 590 },
            new Car (){ Manufacturer = "Lada", Model = "Niva", Date = 1990, KW= 50 },
            new Car (){ Manufacturer = "Lamorghinin", Model = "Gallardo", Date = 2004, KW= 234 },
            new Car (){ Manufacturer = "VW", Model = "Passat", Date = 1999, KW= 81 },
            new Car (){ Manufacturer = "Honda", Model = "Civic", Date = 2007, KW= 100 },
            new Car (){ Manufacturer = "Jaguar", Model = "xk", Date = 2007, KW= 100 },
            };
            return cars;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}