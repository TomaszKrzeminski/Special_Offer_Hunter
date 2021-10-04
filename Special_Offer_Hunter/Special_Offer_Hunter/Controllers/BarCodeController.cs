using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
