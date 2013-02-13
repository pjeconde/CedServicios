using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;
using CaptchaDotNet2;
using CaptchaDotNet2.Security.Cryptography;

namespace CedServicios.Site
{
    public class Captcha : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.BufferOutput = false;

            // Get text
            string s = "No Text";
            if (context.Request.QueryString["c"] != null &&
                context.Request.QueryString["c"] != "")
            {
                string enc = context.Request.QueryString["c"].ToString();

                // space was replaced with + to prevent error
                enc = enc.Replace(" ", "+");
                try
                {
                    s = Encryptor.Decrypt(enc, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
                }
                catch { }
            }
            // Get dimensions
            int w = 120;
            int h = 50;
            // Width
            if (context.Request.QueryString["w"] != null &&
                context.Request.QueryString["w"] != "")
            {
                try
                {
                    w = Convert.ToInt32(context.Request.QueryString["w"]);
                }
                catch { }
            }
            // Height
            if (context.Request.QueryString["h"] != null &&
                context.Request.QueryString["h"] != "")
            {
                try
                {
                    h = Convert.ToInt32(context.Request.QueryString["h"]);
                }
                catch { }
            }
            // Color
            Color Bc = Color.White;
            if (context.Request.QueryString["bc"] != null &&
                context.Request.QueryString["bc"] != "")
            {
                try
                {
                    string bc = context.Request.QueryString["bc"].ToString().Insert(0, "#");
                    Bc = ColorTranslator.FromHtml(bc);
                }
                catch { }
            }
            // Generate image
            CaptchaImage ci = new CaptchaImage(s, Bc, w, h);

            // Return
            ci.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            // Dispose
            ci.Dispose();
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}