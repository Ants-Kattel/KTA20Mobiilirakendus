using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CarListApp.Models
{
    class Car
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int KW { get; set; }
        public int Date { get; set; }
    }
}