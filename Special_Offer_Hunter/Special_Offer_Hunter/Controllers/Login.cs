using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Special_Offer_Hunter.Models;

namespace Special_Offer_Hunter.Controllers
{
    public class LoginController : Controller
    {


        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;
        IHostingEnvironment _environment;
        public LoginController(IHostingEnvironment _environment, IRepository repo, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
        {
            this.repository = repo;
            this._environment = _environment;
            if (GetUser == null)
            {
                string UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                this.GetUser = () => UserId;

            }
            else
            {
                this.GetUser = GetUser;
            }
        }



        public IActionResult Capture()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Capture(string name)
        {
            //string UserId = GetUser();
            //string Name = repository.GetUserEmail(UserId);
            Random rnd = new Random();
            int FileName = rnd.Next(1, 1000000);

            string FileNameOfUser = "";

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

                            var fileNameToStore = string.Concat(+FileName, Path.GetExtension(fileName));
                            var filepath = Path.Combine(_environment.WebRootPath, "UserImages") + $@"\{fileNameToStore}";
                            FileNameOfUser = filepath;
                            if (!string.IsNullOrEmpty(filepath))
                            {
                                using (FileStream fileStream = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                            }


                        }
                    }
                    UserImageFileNameViewModel model = new UserImageFileNameViewModel(FileNameOfUser);

                    return PartialView("FileName", model);


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



        [HttpPost]
        public IActionResult ChangeCapture(string name)
        {
            //string UserId = GetUser();
            //string Name = repository.GetUserEmail(UserId);
            Random rnd = new Random();
            int FileName = rnd.Next(1, 1000000);

            string FileNameOfUser = "";

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

                            var fileNameToStore = string.Concat(name + FileName, Path.GetExtension(fileName));
                            var filepath = Path.Combine(_environment.WebRootPath, "UserImages") + $@"\{fileNameToStore}";
                            FileNameOfUser = filepath;
                            if (!string.IsNullOrEmpty(filepath))
                            {
                                using (FileStream fileStream = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                            }


                        }
                    }
                    UserImageFileNameViewModel model = new UserImageFileNameViewModel(FileNameOfUser);

                    return PartialView("FileName", model);


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



        public int GetRandomNumber()
        {
            Random rnd = new Random();
            int FileName = rnd.Next(1, 1000000);
            return FileName;
        }



        [HttpPost]
        public async Task<IActionResult> ChangePicture(IFormFile file /*, string PictureNumber*/)
        {
            string Message = "Dodanie zdjęcia nie powiodło się !!!";
            string FilePath = "Nie udało się dodać pliku";

            string UserId = GetUser();
            int Number = GetRandomNumber();
            bool success = false;
            long size = 20000000;

            if (file != null && file.Length < size)
            {
                var uploads = Path.Combine(_environment.ContentRootPath, "UserImages");
                //var uploads = Path.Combine(_environment.WebRootPath, "UserImages");

                if (file.Length > 0)
                {

                    if (Path.GetExtension(file.FileName) == ".jpg")
                    {

                        string PathText = Path.Combine(uploads, file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, Number + file.FileName), FileMode.Create))
                        {
                            FilePath = Number + file.FileName;
                            await file.CopyToAsync(fileStream);
                        }

                    }
                    else
                    {
                        Message = "Zdjęcie musi być w formacie jpg";
                        success = false;
                    }




                }

                bool check = repository.ChangeUserPicture(UserId, "/Home/GetPicture/"+FilePath);




            }

            UserImageFileNameViewModel model = new UserImageFileNameViewModel("/Home/GetPicture/"+FilePath);
            return PartialView("FileName", model);


        }

















        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile file /*, string PictureNumber*/)
        {
            string Message = "Dodanie zdjęcia nie powiodło się !!!";
            string FilePath = "Nie udało się dodać pliku";

            bool success = false;
            long size = 20000000;
            int Number = GetRandomNumber();
            if (file != null && file.Length < size)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "UserImages");

                if (file.Length > 0)
                {

                    if (Path.GetExtension(file.FileName) == ".jpg")
                    {

                        string PathText = Path.Combine(uploads, file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, Number + file.FileName), FileMode.Create))
                        {
                            FilePath = "~/UserImages/" + Number + file.FileName;
                            await file.CopyToAsync(fileStream);
                        }
                        //string Id = GetUser();
                        //PictureType type = GetPictureType(PictureNumber);
                        //success = repository.AddPicture(Id, type, FilePath);
                    }
                    else
                    {
                        Message = "Zdjęcie musi być w formacie jpg";
                        success = false;
                    }




                }



            }

            UserImageFileNameViewModel model = new UserImageFileNameViewModel(FilePath);
            return PartialView("FileName", model);


        }

    }
}
