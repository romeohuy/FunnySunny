using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using QRCoder;

namespace Nop.Services.Helpers
{
    public static class QrCodeHelper
    {
        public static Bitmap GenerateQrCode(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText,
                QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
        public static byte[] GenerateQrCodeBytes(string qrText)
        {
            
            return BitmapToBytes(GenerateQrCode(qrText));
        }

        public static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
