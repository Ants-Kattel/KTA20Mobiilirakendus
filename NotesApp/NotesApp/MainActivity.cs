using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using NotesApp.Adapters;
using NotesApp.Models;
using NotesApp.Services;

namespace NotesApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static public SqlService SqlService = new SqlService();
        ListView _listView;
        List<Note> _notes;
        NotesAdapter _notesAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _listView = FindViewById<ListView>(Resource.Id.notesListView);
            _listView.ItemClick += _listView_ItemClick;

            var addButton = FindViewById<Button>(Resource.Id.addButton);
            addButton.Click += AddButton_Click;

            _notes = SqlService.GetAllNotes();
            _notesAdapter = new NotesAdapter(this, _notes);
            _listView.Adapter = _notesAdapter;
        }

        private void _listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(DetailActivity));
            intent.PutExtra("id", _notes[e.Position].Id);
            intent.PutExtra("mode", "edit");
            StartActivity(intent);
        }

        protected override void OnResume()
        {
            base.OnResume();
            _notes = SqlService.GetAllNotes();
            RunOnUiThread(() =>
            {
                _notesAdapter.UpdateData(_notes);
                _notesAdapter.NotifyDataSetChanged();
            });
            
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DetailActivity));
            intent.PutExtra("mode", "add");
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}