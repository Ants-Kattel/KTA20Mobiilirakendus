using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace FirstApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView ansTextView;
        EditText firstNumberEditText;
        EditText secondNumberEditText;
        Button addButton;
        Button subButton;
        Button multButton;
        Button divButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            firstNumberEditText = FindViewById<EditText>(Resource.Id.editText1);
            secondNumberEditText = FindViewById<EditText>(Resource.Id.editText2);
            addButton = FindViewById<Button>(Resource.Id.addButton);
            subButton = FindViewById<Button>(Resource.Id.subtractButton);
            multButton = FindViewById<Button>(Resource.Id.multiplyButton);
            divButton = FindViewById<Button>(Resource.Id.divideButton);
            ansTextView = FindViewById<TextView>(Resource.Id.answerTextView);
            addButton.Click += AddButton_Click;
            subButton.Click += subButton_Click;
            multButton.Click += multButton_Click;
            divButton.Click += divButton_Click;
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            var firstNumber = double.Parse(firstNumberEditText.Text);
            var secondNumber = double.Parse(secondNumberEditText.Text);
            var answer = firstNumber + secondNumber;

            ansTextView.Text = answer.ToString();
        }

        private void subButton_Click(object sender, System.EventArgs e)
        {
            var firstNumber = double.Parse(firstNumberEditText.Text);
            var secondNumber = double.Parse(secondNumberEditText.Text);
            var answer = firstNumber - secondNumber;

            ansTextView.Text = answer.ToString();
        }

        private void multButton_Click(object sender, System.EventArgs e)
        {
            var firstNumber = double.Parse(firstNumberEditText.Text);
            var secondNumber = double.Parse(secondNumberEditText.Text);
            var answer = firstNumber * secondNumber;

            ansTextView.Text = answer.ToString();
        }

        private void divButton_Click(object sender, System.EventArgs e)
        {
            var firstNumber = double.Parse(firstNumberEditText.Text);
            var secondNumber = double.Parse(secondNumberEditText.Text);
            var answer = firstNumber / secondNumber;

            ansTextView.Text = answer.ToString();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
            
        }
    }
}