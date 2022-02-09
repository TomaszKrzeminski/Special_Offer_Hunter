using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

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
                try
                {
                    string UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    this.GetUser = () => UserId;
                }
                catch (Exception ex)
                {
                    GetUser = null;
                }


            }
            else
            {
                this.GetUser = GetUser;
            }
        }

        //public LoginController(IHostingEnvironment _environment, IRepository repo, Func<string> GetUser = null)
        //{
        //    this.repository = repo;
        //    this._environment = _environment;
        //    if (GetUser == null)
        //    {
        //        try
        //        {
        //            string UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //            this.GetUser = () => UserId;
        //        }
        //        catch (Exception ex)
        //        {
        //            GetUser = null;
        //        }


        //    }
        //    else
        //    {
        //        this.GetUser = GetUser;
        //    }
        //}







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
            string Date = DateTime.Now.ToShortDateString();
            string FilePath = "";

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

                            var fileNameToStore = string.Concat(FileName + Date, Path.GetExtension(fileName));
                            FilePath = fileNameToStore;
                            var filepath = Path.Combine(_environment.ContentRootPath, "UserImages") + $@"\{fileNameToStore}";
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
                    UserImageFileNameViewModel model = new UserImageFileNameViewModel("/Home/GetPicture/" + FilePath);

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


        [Authorize]
        [HttpPost]
        public IActionResult ChangeCapture(string name)
        {
            string UserId = GetUser();
            //string Name = repository.GetUserEmail(UserId);
            Random rnd = new Random();
            int FileName = rnd.Next(1, 1000000);
            string fileNameToStore = "";
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

                            /* var*/
                            fileNameToStore = string.Concat(name + FileName, Path.GetExtension(fileName));
                            var filepath = Path.Combine(_environment.ContentRootPath, "UserImages") + $@"\{fileNameToStore}";
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

                    bool check = repository.ChangeUserPicture(UserId, "/Home/GetPicture/" + fileNameToStore);
                    UserImageFileNameViewModel model = new UserImageFileNameViewModel("/Home/GetPicture/" + fileNameToStore);

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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemovePicture(string Path)
        {
            string UserId = GetUser();
            string Message = "";

            bool check = repository.ChangeUserPicture(UserId, "/Home/GetPicture/" + "unnamed.jpg");

            if (!check)
            {
                Message = "Problemy z usunięciem pliku";
            }


            UserImageFileNameViewModel model = new UserImageFileNameViewModel("/Home/GetPicture/" + "unnamed.jpg");
            model.Message = Message;
            return PartialView("FileName", model);
        }





        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePicture(IFormFile file /*, string PictureNumber*/)
        {
            string Message = "Dodanie zdjęcia nie powiodło się !!!";
            string FilePath = "/Home /GetPicture/unnamed.jpg";

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
                            success = true;
                        }

                    }
                    else
                    {
                        Message = "Zdjęcie musi być w formacie jpg";
                        success = false;
                    }




                }

                if (success)
                {
                    bool check = repository.ChangeUserPicture(UserId, "/Home/GetPicture/" + FilePath);
                    Message = "";
                }






            }
            UserImageFileNameViewModel model = new UserImageFileNameViewModel("/Home/GetPicture/" + FilePath);
            model.Message = Message;
            return PartialView("FileName", model);


        }



        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile file /*, string PictureNumber*/)
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

                bool check = repository.ChangeUserPicture(UserId, "/Home/GetPicture/" + FilePath);




            }

            UserImageFileNameViewModel model = new UserImageFileNameViewModel("/Home/GetPicture/" + FilePath);
            return PartialView("FileName", model);

        }
    }
}
