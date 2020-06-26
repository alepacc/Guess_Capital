using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Android.App;
using Android.Graphics;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GuessCapital
{
    public class Client
    {
        public List<Capital.World> ReqAll()
        {
            HttpWebRequest HttpWReqAll = (HttpWebRequest)WebRequest.Create("https://api.worldbank.org/v2/country?per_page=305&format=json");
            HttpWebResponse HttpWRespAll = (HttpWebResponse)HttpWReqAll.GetResponse();

            Stream stream = HttpWRespAll.GetResponseStream();
            StreamReader reader1 = new StreamReader(stream);
            string itemsAsJsonAll = reader1.ReadToEnd();
            JArray a = JArray.Parse(itemsAsJsonAll);

            List<Capital.World> worlds = JsonConvert.DeserializeObject<List<Capital.World>>(a[1].ToString());
            for (int i = 1; i < worlds.Count; i++)
            {
                if (worlds[i].Region.Value.Equals("Aggregates") || worlds[i].CapitalCity.Equals(""))
                {
                    string remove = worlds[i].Name;
                    worlds.RemoveAt(i);
                }
            }
           
            HttpWRespAll.Close();

            return worlds;
        }

        public List<Capital.Europe> ReqEU()
        {
            HttpWebRequest HttpWReqEU = (HttpWebRequest)WebRequest.Create("https://api.worldbank.org/v2/country?region=EMU&format=json");
            HttpWebResponse HttpWRespEU = (HttpWebResponse)HttpWReqEU.GetResponse();


            Stream s = HttpWRespEU.GetResponseStream();
            StreamReader reader2 = new StreamReader(s);
            string itemsAsJson = reader2.ReadToEnd();
            JArray europe = JArray.Parse(itemsAsJson);

            List<Capital.Europe> europes = JsonConvert.DeserializeObject<List<Capital.Europe>>(europe[1].ToString());


            HttpWRespEU.Close();

            return europes;
        }

        public static bool Check(Client instance, string list, string resp)
        {
            if ((list != null) && list.Equals(resp.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
                return false;
        }

        public Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }


    }
}



