using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using RayTracingLib;
using RayTracingMVC.Extensions;
using RayTracingMVC.Models;

namespace RayTracingMVC.Controllers
{
    public class AnimationController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AnimateScene(AnimateSceneRender request)
        {
            var width = request.Width;
            var height = request.Height;

            var spheres = request.Spheres;

            var pathBack = request.PathBack;
            var client = new WebClient();
            var stream = client.OpenRead(pathBack);
            var background = new Bitmap(stream ?? throw new InvalidOperationException());
            var ligths = request.Lights;
            var kolCadr = request.KolCadr;
            var disVec = request.DisVec;

            var centerOkr = request.CenterOkr;

            var ang = 0f;
            var raduisOkr = request.RaduisOkr;

            var byteArrays = new List<byte[]>();

            for (var i = 0; i < kolCadr; i++)
            {
                spheres[0].Center.x = (float)Math.Cos(ang) * raduisOkr + centerOkr.x;
                spheres[0].Center.z = (float)Math.Sin(ang) * raduisOkr + centerOkr.z;

                byteArrays.Add(RayTraceHelper.GetImageByteArray(width, height, spheres, background, ligths));
                ang += 0.1f;
            }

            var gEnc = new GifBitmapEncoder();

            var bmp2 = new Bitmap(width, height);
            foreach (var biteArray in byteArrays)
            {
                unsafe
                {
                    fixed (byte* ptr = biteArray)
                    {
                        bmp2 = new Bitmap(width, height, width * 4, PixelFormat.Format32bppArgb, new IntPtr(ptr));

                    }
                }
                var bmp = bmp2.GetHbitmap();
                var src = Imaging.CreateBitmapSourceFromHBitmap(
                    bmp,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                gEnc.Frames.Add(BitmapFrame.Create(src));
            }

            //var path = @"C:/1/gif1.gif";
            //using (FileStream fs = new FileStream(path, FileMode.Create))
            //{
            //    gEnc.Save(fs);
            //}

            using (MemoryStream ms = new MemoryStream())
            {
                gEnc.Save(ms);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(ms.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/gif");
                return result;
            }
        }
    }
}
