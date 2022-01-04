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
using CarListApp.Models;
using Android.App;

namespace CarListApp.Adapters
{
    class CarAdapter : BaseAdapter<Car>
    {

        List<Car> _items;
        Activity _context;

        public CarAdapter(Activity context, List<Car> items)
        {
            _context = context;
            _items = items;
        }

        public override Car this[int position]
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.car_row_layout, null);
            }
            view.FindViewById<TextView>(Resource.Id.manufacturerTextView).Text = _items[position].Manufacturer;
            view.FindViewById<TextView>(Resource.Id.modelTextView).Text = _items[position].Model;
            view.FindViewById<TextView>(Resource.Id.kwTextView).Text = _items[position].KW.ToString() + " KW";
            view.FindViewById<TextView>(Resource.Id.yearTextView).Text = _items[position].Date.ToString();

            return view;
        }
        public void UpdateData(List<Car> items)
        {
            _items = items;
        }
    }
}