using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;
using System;
using System.IO;

namespace Special_Offer_Hunter.Controllers
{
    public class BarCodeController : Controller
    {
        private readonly IHostingEnvironment _environment;
        public BarCodeController(IHostingEnvironment _environment)
        {
            this._environment = _environment;
        }




        // nadaj losową nazwę plikowi potem go usuń a zapisz code
        [HttpPost]
        public IActionResult CaptureImage(string name)
        {
            Random rnd = new Random();
            int FileName = rnd.Next(1, 1000000);
            string barcode = "";
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {

                            var fileName = file.FileName;

                            var fileNameToStore = string.Concat("BarcodeToCheck" + FileName, Path.GetExtension(fileName));
                            var filepath = Path.Combine(_environment.WebRootPath, "Barcodes") + $@"\{fileNameToStore}";

                            if (!string.IsNullOrEmpty(filepath))
                            {
                                using (FileStream fileStream = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                            }

                            IBarcodeReaderInterface barcodeReader = new BarCodeReader1(_environment);
                            barcode = barcodeReader.ReadBarCode(filepath);

                            if (System.IO.File.Exists(filepath))
                            {
                                System.IO.File.Delete(filepath);
                                ViewBag.deleteSuccess = "true";
                            }
                        }
                    }

                    ProductDetailsFromBarCode x = new ProductDetailsFromBarCode();
                    ProductDetailsViewModel model = x.GetProductDetails(barcode).Result;

                    return PartialView("ProductDetailsShort", model);


                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IActionResult SearchByProductName()
        {
            return View();
        }
    }
}
