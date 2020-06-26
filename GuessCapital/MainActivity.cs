using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using System.Net;

namespace GuessCapital
{
    [Activity(Label = "GuessCapital", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            try
            {
                var client = new Client();
                var connection = client.ReqAll();

            }
            catch (WebException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                Toast.MakeText(Application.Context, Convert.ToString("Internet connection required!"), ToastLength.Short).Show();
                Finish();
            }

            Button button = FindViewById<Button>(Resource.Id.buttonStart);

            button.Click += ButtonClicked;
  
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            RadioButton rb1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            RadioButton rb2 = FindViewById<RadioButton>(Resource.Id.radioButton2);

           
            if (rb1.Checked) //EUROPE
            {
                Toast.MakeText(this, Convert.ToString(rb1.Text), ToastLength.Short).Show();
                //Select only nation with region="EMU"
                var intent = new Intent(this, typeof(GameActivity));
                intent.PutExtra("Europe", true);
                StartActivity(intent);

            }
            else if (rb2.Checked)  //ALL
            {
                Toast.MakeText(this, Convert.ToString(rb2.Text), ToastLength.Short).Show();
                var intent = new Intent(this, typeof(GameActivity));
                intent.PutExtra("Europe", false);
                StartActivity(intent);
            }

        }
      
    }
}
     
