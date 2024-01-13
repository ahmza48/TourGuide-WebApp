//using Microsoft.AspNetCore.Mvc;
//using System.Collections;
//using System.Runtime.Intrinsics.Arm;

//namespace Travel.Controllers
//{
//    public class LoginController : Controller
//    {
//        public ViewResult AdminLogin()
//        {
//            return View("~/Views/Admin/Login.cshtml");
//        }

//        public ViewResult adminSignIn()
//        {
//            if (HttpContext.Request.Cookies.ContainsKey("AdminName"))
//            {
//                AdminRepository ad = new AdminRepository();
//                ArrayList li = new ArrayList();
//                li.Add(HttpContext.Request.Cookies["AdminName"]);
//                return View("~/Views/Admin/AdminFirst.cshtml", li);

//            }
//            else
//            {

//                return View("~/Views/Login/adminSignIn.cshtml");
//            }
//        }
//        [HttpPost]
//        public ViewResult admindata(Adm u)
//        {
//            AdminRepository add = new AdminRepository();
//            string name = "";
//            name = add.Login(u);


//            if (name != "")
//            {
//                HttpContext.Response.Cookies.Append("AdminName", name);
//                AdminRepository ad = new AdminRepository();
//                ArrayList li = new ArrayList();
//                li.Add(name);
//                Console.WriteLine(li[0]);
//                return View("~/Views/Admin/AdminFirst.cshtml", li);
//            }
//            return View("~/Views/Login/adminSignIn.cshtml");
//        }
//        [HttpPost]
//        public ViewResult StudentSignUp(StudentLogin stu)
//        {
//            Console.WriteLine(stu.Password);
//            StudentRepository student = new StudentRepository();
//            if (student.AddStudent(stu))
//            {
//                return View("~/Views/Login/Login.cshtml");
//            }
//            return View("~/Views/Login/SignUp.cshtml");
//        }
//        [HttpPost]
//        public ViewResult StudentLogin(StudentLogin stu)
//        {
//            StudentRepository student = new StudentRepository();
//            if (student.LoginStudent(stu))
//            {
//                return View("~/Views/Admin/AdminFirst.cshtml", "SUCCESS");
//            }
//            return View("~/Views/Login/Login.cshtml");
//        }
//        [HttpGet]
//        public ViewResult AdminLogout()
//        {
//            if (HttpContext.Request.Cookies.ContainsKey("AdminName"))
//            {

//                HttpContext.Response.Cookies.Delete("AdminName");
//            }
//            return View("~/Views/Login/adminSignIn.cshtml");
//        }

//    }
//}
