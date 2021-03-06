﻿using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLCrypto;


namespace eKulturnoSportskiCentar_PCL.Util
{
  public  class UIHelper
    {
        #region Korisnici

        public static string GenerateSalt()
        {
          //  byte[] arr = new byte[16];
          //  RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
           // crypto.GetBytes(arr);
            //return Convert.ToBase64String(arr);

            var buf = WinRTCrypto.CryptographicBuffer.GenerateRandom(16);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string lozinka, string salt)
        {
            byte[] byteLozinka = Encoding.Unicode.GetBytes(lozinka);
            byte[] byteSalt = Convert.FromBase64String(salt);

            byte[] forHashing = new byte[byteLozinka.Length + byteSalt.Length];

            //strcpy strcat
            System.Buffer.BlockCopy(byteLozinka, 0, forHashing, 0, byteLozinka.Length);
            System.Buffer.BlockCopy(byteSalt, 0, forHashing, byteLozinka.Length, byteSalt.Length);

            var alg = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);// HashAlgorithm.Create("SHA1");
            byte[] inArray = alg.HashData(forHashing);
            return Convert.ToBase64String(inArray);

        }

        #endregion



        #region Slika

        //public static Image CropImage(Image img, Rectangle cropArea)
        //{
        //    Bitmap bmpImage = new Bitmap(img);
        //    Bitmap bmpCrop = bmpImage.Clone(cropArea,
        //        bmpImage.PixelFormat);
        //    return (Image)(bmpCrop);
        //}

        //public static Image ResizeImage(Image imgToResize, Size size)
        //{
        //    int sourceWidth = imgToResize.Width;
        //    int sourceHeight = imgToResize.Height;

        //    float nPercent = 0;
        //    float nPercentW = 0;
        //    float nPercentH = 0;

        //    nPercentW = ((float)size.Width / (float)sourceWidth);
        //    nPercentH = ((float)size.Height / (float)sourceHeight);

        //    if (nPercentH < nPercentW)
        //        nPercent = nPercentH;
        //    else
        //        nPercent = nPercentW;

        //    int destWidth = (int)(sourceWidth * nPercent);
        //    int destHeight = (int)(sourceHeight * nPercent);

        //    Bitmap b = new Bitmap(destWidth, destHeight);
        //    Graphics g = Graphics.FromImage((Image)b);
        //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        //    g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
        //    g.Dispose();

        //    return (Image)b;
        }
        #endregion
}
