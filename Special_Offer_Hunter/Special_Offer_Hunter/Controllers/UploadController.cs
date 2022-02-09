using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Controllers
{
    public class UploadController : Controller
    {


        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;
        IHostingEnvironment _environment;
        public UploadController(IHostingEnvironment _environment, IRepository repo, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
        {
            this._environment = _environment;
            //if (GetUser == null)
            //{
            //    //string UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //    //this.GetUser = () => UserId;

            //}
            //else
            //{
            //    this.GetUser = GetUser;
            //}
        }




        public IActionResult Index()
        {
            return View();
        }





        public enum PictureType
        {
            MainPhotoPath,
            PhotoPath1,
            PhotoPath2,
            PhotoPath3
        }

        public PictureType GetPictureType(string PictureNumber)
        {
            PictureType type = new PictureType();
            int number;
            try
            {
                number = Convert.ToInt32(PictureNumber);
            }
            catch
            {
                number = 0;
            }


            if (number > 3 || number < 0)
            {
                number = 0;
            }
            else
            {
                type = (PictureType)number;
            }

            return type;
        }



        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult PictureAdder(UserDetailsModel model)
        //{
        //    bool success = repository.ChangeUserDetails(model);
        //    if (success)
        //    {
        //        return RedirectToRoute(new { controller = "Home", action = "Panel", Id = "MyId" });
        //    }
        //    else
        //    {
        //        string Message = "Dodanie zmian się nie powiodło";
        //        return View("Error_1", Message);
        //    }

        //}
        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult RemovePicture(string Number)
        //{

        //    bool success = false;

        //    if (Number != null)
        //    {
        //        string Id = GetUser().Result.Id;
        //        PictureType type = GetPictureType(Number);
        //        success = repository.RemovePicture(Id, type);

        //    }


        //    if (success)
        //    {

        //        return RedirectToRoute(new { controller = "Home", action = "Panel", Id = "MyId" });
        //    }
        //    else
        //    {
        //        string Message = "Usunięcie zdjęcia się nie powiodło";
        //        return View("Error_1", Message);
        //    }

        //}

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile file /*, string PictureNumber*/)
        {
            string Message = "Dodanie zdjęcia nie powiodło się !!!";


            bool success = false;
            long size = 20000000;

            if (file != null && file.Length < size)
            {
                var uploads = Path.Combine(_environment.ContentRootPath, "UserImages");
                string FilePath;
                if (file.Length > 0)
                {

                    if (Path.GetExtension(file.FileName) == ".jpg")
                    {

                        string PathText = Path.Combine(uploads, file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            FilePath = "/Upload/GetPicture/" + file.FileName;
                            await file.CopyToAsync(fileStream);
                        }
                        string Id = GetUser();
                        //PictureType type = GetPictureType(PictureNumber);
                        //success = repository.AddPicture(Id, type, FilePath);
                    }
                    else
                    {
                        Message = "Zdjęcie musi być w formacie jpg";
                        success = false;
                    }




                }


                if (success)
                {
                    return RedirectToRoute(new { controller = "Home", action = "Panel", Id = "MyId" });
                }
                else
                {

                    return View("Error_1", Message);
                }



            }
            return RedirectToRoute(new { controller = "Home", action = "Panel", Id = "MyId" });


        }

        //[Authorize]
        //[HttpGet]
        //public IActionResult GetPicture(string id)
        //{
        //    string UserId = GetUser().Result.Id;
        //    string uploads = Path.Combine(_environment.WebRootPath, "AppPictures");
        //    string text = Path.Combine(uploads, "photo.png");
        //    var image = System.IO.File.OpenRead(text);

        //    if (repository.CheckPictureOwner(id, UserId) || repository.CheckIfPictureBelongsToPair(id, UserId))
        //    {
        //        uploads = Path.Combine(_environment.ContentRootPath, "UserImages");
        //        text = Path.Combine(uploads, id);
        //        image = System.IO.File.OpenRead(text);
        //    }

        //    return File(image, "image/jpeg");
        //}






    }
}
