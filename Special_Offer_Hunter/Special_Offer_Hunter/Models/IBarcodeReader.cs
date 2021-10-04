using Microsoft.AspNetCore.Hosting;
using System;
using System.Drawing;
using System.IO;
using ZXing;
using ZXing.Common;

namespace Special_Offer_Hunter.Models
{
    public interface IBarcodeReaderInterface
    {
        string BarCode { get; set; }
        string BarCodeImagePath { get; set; }
        string ReadBarCode(string FilePath);

    }

    public class BarCodeReader1 : IBarcodeReaderInterface
    {
        IHostingEnvironment _environment;
        public BarCodeReader1(IHostingEnvironment _environment)
        {
            this._environment = _environment;
        }


        public string BarCode { get; set; }
        public string BarCodeImagePath { get; set; }

        public string ReadBarCode(string FilePath)
        {
            try
            {
                string id = FilePath;
                string uploads = Path.Combine(_environment.WebRootPath, "Barcodes");
                string text = Path.Combine(uploads, id);

                Bitmap image;
                try
                {
                    image = (Bitmap)Bitmap.FromFile(text);
                }
                catch (Exception)
                {
                    throw new FileNotFoundException("Resource not found: " + FilePath);
                }

                using (image)
                {
                    LuminanceSource source;
                    source = new BitmapLuminanceSource(image);
                    BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                    Result result = new MultiFormatReader().decode(bitmap);
                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return null;
                    }

                }
            }

            catch (Exception ex)
            {
                return null;
            }




           

               

            
        }
    }






}
