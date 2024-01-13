using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Travel.Models;
using System.Web;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.Collections;
//using Travel.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using Travel.Models.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System;

namespace Travel.Controllers
{
    public class AdminController : Controller
    {
        private readonly TouristContext _context;
        private readonly AdminRepository adminRepo;
        private readonly GuideRepository guideRepo;
        private readonly PlaceRepository placeRepo;
        private readonly HotelRepository hotelRepo;
        private readonly PhotographerRepository photographerRepo;

        private IHostingEnvironment _environment;
        public AdminController(IHostingEnvironment environment)
        {
            _environment = environment;
            _context = new TouristContext();
            adminRepo = new AdminRepository(_context);
            placeRepo = new PlaceRepository(_context);
            guideRepo = new GuideRepository(_context);
            hotelRepo = new HotelRepository(_context);
            photographerRepo = new PhotographerRepository(_context);


        }
        public object Environment { get; private set; }

        //private readonly IWebHostEnvironment _hostingEnvironment;

        //public AdminController(IWebHostEnvironment hostingEnvironment)
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //}



        public ViewResult Login()
        {
            return View("~/Views/Admin/Login.cshtml");
        }
        [HttpPost]
        public ViewResult VerifyAdmin(string email, string password)
        {
            //HttpContext.Session.SetString("user", email);
            HttpContext.Response.Cookies.Append("user", email);
            Admin admin = adminRepo.GetAdminByEmailPassword(email, password);
            if (admin != null)
            {
                string name=admin.FirstName+admin.LastName;
                return View("~/Views/Admin/AdminFirst.cshtml", name);
            }
            string msg = "Invalid Credentials!";
            return View("~/Views/Admin/Login.cshtml",msg);
        }
        public ViewResult GoHome()
        {
            //HttpContext.Session.GetString("user");
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                return View("~/Views/Admin/AdminFirst.cshtml");
            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }
        public ViewResult Logout()
        {
            //HttpContext.Session.GetString("user");
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                //HttpContext.Session.Remove("user");
                HttpContext.Response.Cookies.Delete("user");
                return View("~/Views/Admin/Login.cshtml");
            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }
        public ViewResult AddPlace()
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                return View("~/Views/Admin/AddPlace.cshtml");
            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }

        public ViewResult AllPlaces()
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                List<Place> list = placeRepo.GetAllPlaces();
                return View("~/Views/Admin/AllPlaces.cshtml",list);
            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }
        public ViewResult AllGuides()
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                List<Guide> list = guideRepo.GetAllGuides();
                return View("~/Views/Admin/AllGuides.cshtml", list);
            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }

        public ViewResult AddGuide()
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                return View("~/Views/Admin/AddGuide.cshtml");
            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }

        [HttpGet]
        public IActionResult GetGuide(int id)
        {
            var guide = _context.Guides.Find(id);

            if (guide == null)
            {
                return NotFound();
            }

            return Json(new
            {
                id = guide.Id,
                name = guide.Name,
                placeName = guide.PlaceName,
                contact = guide.Contact
            });
        }

        public ViewResult AddPhotographer()
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                return View("~/Views/Admin/AddPhotographer.cshtml");
            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }
        public ViewResult AddHotel()
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                return View("~/Views/Admin/AddHotel.cshtml");
            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }
        public ViewResult InsertPlace(string name, IFormFile img)
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                string path = "";
                path = Path.Combine(this._environment.WebRootPath, "Uploads/Backend/img/Places");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string FileName = img.FileName;

                // combining GUID to create unique name before saving in wwwroot

                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Backend/img/Places", FileName);

                // copying file
                FileStream n = new FileStream(imagePath, FileMode.Create);
                img.CopyTo(n);
                n.Close();

                Place place = new Place();
                place.Name = name;
                place.Photo = "/Backend/img/Places/" + FileName;
                
                Place check = placeRepo.GetPlaceByName(place.Name);
                if (check!=null)
                {
                    string msgX = "Place Already Exists!";
                    return View("~/Views/Admin/AddPlace.cshtml", msgX);
                }
                else
                {
                    placeRepo.Add(place);
                    string msg = "Place Added Successfully";
                    return View("~/Views/Admin/AddPlace.cshtml", msg);
                }

            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }

        public ViewResult InsertGuide(string name, IFormFile img,string contact,string place)
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                string path = "";
                path = Path.Combine(this._environment.WebRootPath, "Uploads/Backend/img/Guides");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string FileName = img.FileName;

                // combining GUID to create unique name before saving in wwwroot

                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Backend/img/Guides", FileName);

                // copying file
                FileStream n = new FileStream(imagePath, FileMode.Create);
                img.CopyTo(n);
                n.Close();

                Guide guide = new Guide();
                guide.Name = name;
                guide.Image = "/Backend/img/Guides/" + FileName;
                guide.PlaceName = place;
                guide.Contact = contact;

                Guide check = guideRepo.GetGuideByContact(guide.Contact);
                if (check != null)
                {
                    string msgX = "Guide Already Exists!";
                    return View("~/Views/Admin/AddGuide.cshtml", msgX);
                }
                else
                {
                    guideRepo.Add(guide);
                    string msg = "Guide Added Successfully";
                    return View("~/Views/Admin/AddGuide.cshtml", msg);
                }

            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }
        public ViewResult EditGuide(string name, IFormFile img, string contact, string place,int id)
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {

                var guide = _context.Guides.Find(id);

                if (guide != null)
                {
                    string path = "";
                    path = Path.Combine(this._environment.WebRootPath, "Uploads/Backend/img/Guides");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string FileName = img.FileName;
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Backend/img/Guides", FileName);

                    FileStream n = new FileStream(imagePath, FileMode.Create);
                    img.CopyTo(n);
                    n.Close();

                    //Guide guide = new Guide();
                    //guide.Name = name;
                    //guide.Image = "/Backend/img/Guides/" + FileName;
                    //guide.PlaceName = place;
                    //guide.Contact = contact;

                    // Update the guide information
                    guide.Name = name;
                    guide.Image = "/Backend/img/Guides/" + FileName;
                    guide.PlaceName = place;
                    guide.Contact = contact;

                    _context.SaveChanges();
                    List<Guide> list = guideRepo.GetAllGuides();
                    return View("~/Views/Admin/AllGuides.cshtml", list);

                }
                else
                {
                    List<Guide> list = guideRepo.GetAllGuides();
                    return View("~/Views/Admin/AllGuides.cshtml", list);
                }




                //string path = "";
                //path = Path.Combine(this._environment.WebRootPath, "Uploads/Backend/img/Guides");
                //if (!Directory.Exists(path))
                //{
                //    Directory.CreateDirectory(path);
                //}
                //string FileName = img.FileName;
                //var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Backend/img/Guides", FileName);

                //FileStream n = new FileStream(imagePath, FileMode.Create);
                //img.CopyTo(n);
                //n.Close();

                //Guide guide = new Guide();
                //guide.Name = name;
                //guide.Image = "/Backend/img/Guides/" + FileName;
                //guide.PlaceName = place;
                //guide.Contact = contact;

                //Guide check = guideRepo.GetGuideByContact(guide.Contact);
                //if (check != null)
                //{
                //    string msgX = "Guide Already Exists!";
                //    return View("~/Views/Admin/AddGuide.cshtml", msgX);
                //}
                //else
                //{
                //    guideRepo.Add(guide);
                //    string msg = "Guide Added Successfully";
                //    return View("~/Views/Admin/AddGuide.cshtml", msg);
                //}

            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }

        public ViewResult InsertPhotographer(string name, IFormFile img, string contact, string place)
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                string path = "";
                path = Path.Combine(this._environment.WebRootPath, "Uploads/Backend/img/Photographers");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string FileName = img.FileName;

                // combining GUID to create unique name before saving in wwwroot

                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Backend/img/Photographers", FileName);

                // copying file
                FileStream n = new FileStream(imagePath, FileMode.Create);
                img.CopyTo(n);
                n.Close();


                Photographer photographer = new Photographer();
                photographer.Name = name;
                photographer.Image = "/Backend/img/Photographers/" + FileName;
                photographer.Contact = contact;
                photographer.PlaceName = place;
                Photographer check = photographerRepo.GetPhotographerByContact(photographer.Contact);
                if (check != null)
                {
                    string msgX = "Photographer Already Exists!";
                    return View("~/Views/Admin/AddPhotographer.cshtml", msgX);
                }
                else
                {
                    photographerRepo.Add(photographer);
                    string msg = "Photographer Added Successfully";
                    return View("~/Views/Admin/AddPhotographer.cshtml", msg);
                }

            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }
        public ViewResult InsertHotel(string hotelname, IFormFile img, string ownername, string ownercontact, string placename, int rooms,int price)
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                string path = "";
                path = Path.Combine(this._environment.WebRootPath, "Uploads/Backend/img/Hotels");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string FileName = img.FileName;

                // combining GUID to create unique name before saving in wwwroot

                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Backend/img/Hotels", FileName);

                // copying file
                FileStream n = new FileStream(imagePath, FileMode.Create);
                img.CopyTo(n);
                n.Close();


                Hotel hotel = new Hotel();
                hotel.HotelName = hotelname;
                hotel.Image = "/Backend/img/Hotels/" + FileName;
                hotel.OwnerName = ownername;
                hotel.Contact=ownercontact;
                hotel.PlaceName = placename;
                hotel.Rooms = rooms;
                hotel.Price = price;

                Hotel check = hotelRepo.GetHotelByName(hotel.HotelName);
                if (check != null)
                {
                    string msgX = "Hotel Already Exists!";
                    return View("~/Views/Admin/AddHotel.cshtml", msgX);
                }
                else
                {
                    hotelRepo.Add(hotel);
                    string msg = "Hotel Added Successfully";
                    return View("~/Views/Admin/AddHotel.cshtml", msg);
                }

            }
            else
            {
                return View("~/Views/Admin/Login.cshtml");
            }
        }
        public ViewResult Search(string place, string option)
        {
            string placeName = place;
            string optionName = option;

            if (optionName=="guides")
            {
                List<Guide> guides = guideRepo.GetGuidesByPlaceName(placeName);
                return View("~/Views/Team/SpecificGuides.cshtml",guides);
            }
            else if (optionName == "photographers")
            {
                List<Photographer> photographers = photographerRepo.GetPhotographersByPlaceName(placeName);
                return View("~/Views/Photographer/SpecificPhotographers.cshtml",photographers);
            }
            else
            {
                List<Hotel> hotels =  hotelRepo.GetHotelsByPlaceName(placeName);
                return View("~/Views/Hotels/SpecificHotels.cshtml",hotels);
            }


        }

        [HttpGet]
        public IActionResult DeletePlace(int id)
        {
            // Find the place with the specified ID
            var place = _context.Places.Find(id);

            if (place == null)
            {
                // Handle the case where the place is not found
                return NotFound();
            }

            // Remove the place from the database
            _context.Places.Remove(place);
            _context.SaveChanges();

            List<Place> list = placeRepo.GetAllPlaces();
            return View("~/Views/Admin/AllPlaces.cshtml", list);

        }
        [HttpGet]
        public IActionResult DeleteGuide(int id)
        {
            // Find the place with the specified ID
            var guide = _context.Guides.Find(id);

            if (guide == null)
            {
                // Handle the case where the place is not found
                return NotFound();
            }

            // Remove the place from the database
            _context.Guides.Remove(guide);
            _context.SaveChanges();

            List<Guide> list = guideRepo.GetAllGuides();
            return View("~/Views/Admin/AllGuides.cshtml", list);

        }
    }
}
