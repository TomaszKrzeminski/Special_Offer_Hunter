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
							var fileNameToStore = string.Concat("BarcodeToCheck", Path.GetExtension(fileName));
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
							string barcode = barcodeReader.ReadBarCode(filepath);
						}
					}
					return Json(true);
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



		public IActionResult TakeSnapShoot()
        {


            return View();
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
