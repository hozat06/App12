using Android.Graphics;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Net;

namespace App1.Droid
{
    public class CustomCountDownTimer : CountDownTimer, IDisposable
    {
        private readonly ImageView imageView;

        private int imageIndex = 0;
        private readonly string[] urls = {
            "https://statics.boyner.com.tr/bannerimages/sevgililer-gunu-kozmetik-anasayfa6_2022020107222552687.jpg",
            "https://statics.boyner.com.tr/bannerimages/yeni-gelenler-kare_2022020113570378392.jpg",
            "https://statics.boyner.com.tr/bannerimages/hopi-ocak22-app-kare2_2022020212490309287.jpg",
            "https://statics.boyner.com.tr/bannerimages/tum-urunler-app-kare%20(1)_2022020411041906350.jpg",
            "https://statics.boyner.com.tr/bannerimages/sevgililer-gunu-kahve-app-kare_2022020410542346925.jpg",
        };
        private Dictionary<string, Bitmap> bitmaps;

        public CustomCountDownTimer(ImageView imageView,
            long millisInFuture, long countDownInterval) : base(millisInFuture, countDownInterval)
        {
            this.imageView = imageView;
            bitmaps = new Dictionary<string, Bitmap>();
            //imageView.SetImageResource(images[0]);
            imageView.SetImageBitmap(GetImageBitmapFromUrl(urls[imageIndex], "slider0"));
        }

        public override void OnFinish()
        {
            imageView.SetImageResource(Resource.Drawable.poseidon_logo);
            new CustomCountDownTimer(this.imageView, 60000, 5000).Start();
        }

        public override void OnTick(long millisUntilFinished)
        {
            if (imageIndex >= urls.Length - 1)
                imageIndex = 0;
            else
                imageIndex++;

            //imageView.SetImageResource(images[imageIndex]);
            imageView.SetImageBitmap(GetImageBitmapFromUrl(urls[imageIndex], $"slider{imageIndex}"));
        }

        private Bitmap GetImageBitmapFromUrl(string url, string name)
        {
            Bitmap imageBitmap = null;
            
            if (bitmaps.ContainsKey(name))
            {
                imageBitmap = bitmaps[name];
            }
            else
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                        bitmaps.Add(name, imageBitmap);
                    }
                }
            }

            return imageBitmap;
        }
    }
}