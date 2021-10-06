using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;

namespace Special_Offer_Hunter.Controllers
{
    public class BarCodeController : Controller
    {
        private readonly IHostingEnvironment _environment;
        public BarCodeController (IHostingEnvironment _environment)
        {
            this._environment = _environment;
        }


       

		// nadaj losową nazwę plikowi potem go usuń a zapisz code
        [HttpPost]
		public IActionResult CaptureImage(string name)
		{
			Random rnd = new Random();
			int FileName= rnd.Next(1, 1000000);
			string barcode="";
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
							//var fileNameToStore = string.Concat(Convert.ToString(Guid.NewGuid()), Path.GetExtension(fileName));
							var fileNameToStore = string.Concat("BarcodeToCheck"+FileName, Path.GetExtension(fileName));
							//  Path to store the snapshot in local folder
							var filepath = Path.Combine(_environment.WebRootPath, "Barcodes") + $@"\{fileNameToStore}";

							// Save image file in local folder
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
					//return Json(true);
					return this.Content(barcode, "application/json");
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


public void Test()
        {
			ProductDetailsFromBarCode x = new ProductDetailsFromBarCode();
			Product product=x.GetProductDetails().Result;

		}
		

        public IActionResult ScanProductCode()
        {
            IBarcodeReaderInterface barcodeReader = new BarCodeReader1(_environment);
           string barcode= barcodeReader.ReadBarCode("1111.jpg");
            return View();
        }
        public IActionResult SearchByProductName()
        {
            return View();
        }
    }
}
