using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherApp.Models;

namespace WeatherApp.Adapters
{
    class WeatherAdapter : BaseAdapter<WeatherList>
    {

        List<WeatherList> _items;
        Activity _context;

        public WeatherAdapter(Activity context, List<WeatherList> items)
        {
            _context = context;
            _items = items;
        }

        public override WeatherList this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
             View view = convertView;
             if (view == null)
             {
                 view = _context.LayoutInflater.Inflate(Resource.Layout.weather_row_layout, null);
             }
             view.FindViewById<TextView>(Resource.Id.dayTextView).Text = _items[position].dt_txt;
             view.FindViewById<TextView>(Resource.Id.tempTextView).Text = _items[position].main.temp.ToString() + " °C";
             view.FindViewById<TextView>(Resource.Id.windTextView).Text = _items[position].wind.speed.ToString() + "m/s";

             return view;
        }
        public void UpdateData(List<WeatherList> items)
        {
            _items = items;
        }
    }
}