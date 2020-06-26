
using System;
using System.Collections.Generic;
using System.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GuessCapital
{
    [Activity(Label = "GuessCapital")]
    public class GameActivity : Activity
    {
        private Client client = new Client();

        private Random random = new Random(unchecked((int)DateTime.Now.Ticks));
        private int index;
        private List<Capital.Europe> europes;
        private List<Capital.World> worlds;
        private bool choose;
        internal int[] numbers;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Game);

            TextView tvNation = FindViewById<TextView>(Resource.Id.textViewNation);
            TextView tvScore = FindViewById<TextView>(Resource.Id.textViewScore);
            EditText etCapital = FindViewById<EditText>(Resource.Id.editTextCapital);
            ImageView ivFlag = FindViewById<ImageView>(Resource.Id.imageViewFlag);

            choose = Intent.Extras.GetBoolean("Europe");
            if (choose) //EUROPE
            {
                europes = client.ReqEU();
                index = random.Next(europes.Count);
                tvNation.Text = europes[index].Name;
                string link = "https://www.countryflags.io/" + europes[index].Iso2code + "/shiny/64.png";
                var imageBitmap = client.GetImageBitmapFromUrl(link);
                ivFlag.SetImageBitmap(imageBitmap);

                numbers = new int[20];
                Array.Clear(numbers, 0, numbers.Length);
                numbers[index] = index + 1;
                Console.WriteLine("\t1 ind:" + index);
            }
            else //ALL WORD
            {
                worlds = client.ReqAll();
                index = random.Next(worlds.Count);
                tvNation.Text = worlds[index].Name;
                string link = "https://www.countryflags.io/" + worlds[index].Iso2code + "/shiny/64.png";
                var imageBitmap = client.GetImageBitmapFromUrl(link);
                ivFlag.SetImageBitmap(imageBitmap);

            }


            Button button = FindViewById<Button>(Resource.Id.buttonCheck);

            button.Click += ButtonClicked;

        }


        private void ButtonClicked(object sender, EventArgs e)
        {
            TextView tvNation = FindViewById<TextView>(Resource.Id.textViewNation);
            TextView tvScore = FindViewById<TextView>(Resource.Id.textViewScore);
            TextView tvTot = FindViewById<TextView>(Resource.Id.textView2);
            EditText etCapital = FindViewById<EditText>(Resource.Id.editTextCapital);
            ImageView ivFlag = FindViewById<ImageView>(Resource.Id.imageViewFlag);


            string resp = etCapital.Text;
            int point = int.Parse(tvScore.Text);
            if (choose) //EUROPE
            {
                var resp_check = Client.Check(client, europes[index].CapitalCity, resp);
                if (resp_check)
                {
                    Toast.MakeText(this, Convert.ToString("Good job!"), ToastLength.Short).Show();
                    point++;
                    tvScore.Text = "" + point;
                }
                else
                    Toast.MakeText(this, Convert.ToString("You wrong! The capital was: " + europes[index].CapitalCity), ToastLength.Short).Show();

                bool repeat = false;
                do
                {
                    index = random.Next(europes.Count);
                    if (numbers[index] == 0)
                    {
                        numbers[index] = index + 1;
                        break;
                    }
                    repeat = true;
                } while (repeat);


                tvNation.Text = europes[index].Name;
                string link = "https://www.countryflags.io/" + europes[index].Iso2code + "/shiny/64.png";
                var imageBitmap = client.GetImageBitmapFromUrl(link);
                ivFlag.SetImageBitmap(imageBitmap);

            }
            else if (!choose) //ALL WORD
            {

                var resp_check = Client.Check(client, worlds[index].CapitalCity, resp);
                if (resp_check)
                {
                    Toast.MakeText(this, Convert.ToString("Good job!"), ToastLength.Short).Show();
                    point++;
                    tvScore.Text = "" + point;
                }
                else
                    Toast.MakeText(this, Convert.ToString("You wrong! This is the capital:" + worlds[index].CapitalCity), ToastLength.Short).Show();
                do
                {
                    index = random.Next(worlds.Count);

                } while (worlds[index].Region.Value.Equals("Aggregates"));
                tvNation.Text = worlds[index].Name;
                string link = "https://www.countryflags.io/" + worlds[index].Iso2code + "/shiny/64.png";
                var imageBitmap = client.GetImageBitmapFromUrl(link);
                ivFlag.SetImageBitmap(imageBitmap);

            }


            int tot = int.Parse(tvTot.Text);
            tvTot.Text = "" + ++tot;
            etCapital.Text = "";
            if (tot == 18)
            {
                Toast.MakeText(this, Convert.ToString("Game over! Your score is: " + point), ToastLength.Long).Show();
                Finish();
            }




        }


    }


}
