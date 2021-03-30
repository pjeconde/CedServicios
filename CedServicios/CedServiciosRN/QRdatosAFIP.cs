using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace CedServicios.RN
{
    public class QRdatosAFIP
    {
        public static Bitmap RenderQrCodeAFIP(Entidades.QRdatosAFIP qrdatosAFIP)
        {
            Bitmap bm = null;
            string qrStr = Newtonsoft.Json.JsonConvert.SerializeObject(qrdatosAFIP);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(qrStr);
            string qrStrBase64 = System.Convert.ToBase64String(plainTextBytes);
            bm = RenderQrCode("https://www.afip.gob.ar/fe/qr/?p=" + qrStrBase64, "L");
            return bm;
        }
        private static Bitmap RenderQrCode(string datos, string level)
        {
            Bitmap bm = null;
            if (level == string.Empty)
            { level = "L"; } //comboBoxECC.SelectedItem.ToString(); //L - M - Q - H
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(datos, eccLevel))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        //pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(20, GetPrimaryColor(), GetBackgroundColor(), GetIconBitmap(), (int)iconSize.Value);
                        bm = qrCode.GetGraphic(20, GetPrimaryColor(), GetBackgroundColor(), GetIconBitmap(), (int)5);
                        //this.pictureBoxQRCode.Size = new System.Drawing.Size(pictureBoxQRCode.Width, pictureBoxQRCode.Height);
                        ////Set the SizeMode to center the image.
                        //this.pictureBoxQRCode.SizeMode = PictureBoxSizeMode.CenterImage;
                        //pictureBoxQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            return bm;
        }
        private static Bitmap GetIconBitmap()
        {
            Bitmap img = null;
            string pathIcon = "";
            if (pathIcon.Length > 0)
            {
                try
                {
                    img = new Bitmap(pathIcon.ToString());
                }
                catch (Exception)
                {
                }
            }
            return img;
        }
        private static Color GetPrimaryColor()
        {
            return Color.Black;
        }
        private static Color GetBackgroundColor()
        {
            return Color.White;
        }
    }
}
