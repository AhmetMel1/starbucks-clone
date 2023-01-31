using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using StarbucksProje.PagedList;
using System.Security.Claims;

namespace StarbucksProje.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
		private readonly IToastNotification _toastNotification;
		private readonly IWebHostEnvironment webHostEnvironment;
		public AdminController(IToastNotification toastNotification, IWebHostEnvironment webHostEnvironment)
		{
			_toastNotification = toastNotification;
			this.webHostEnvironment = webHostEnvironment;
		}
        [AllowAnonymous]
		[HttpGet]
		public IActionResult Login()
        {
            return View();
        }
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Entry(Admin admin)
		{
			Context c = new Context();
			var result = c.Admins.Where(x => x.adminMail == admin.adminMail && x.adminPassword == admin.adminPassword).SingleOrDefault();
			if (result != null)
			{
				var name = result.adminFirstName + " " + result.adminLastName;
				var claims = new List<Claim> { new Claim(ClaimTypes.Email, result.adminMail), new Claim(ClaimTypes.Name, name),
				new Claim(ClaimTypes.Actor, result.adminType),new Claim(ClaimTypes.UserData,result.adminImgUrl),new Claim(ClaimTypes.Gender,result.adminGender.ToString()) };

				var userIdentify = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentify);
				await HttpContext
				.SignInAsync(
				principal,
				new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddMinutes(20) });
                admin=adminManager.adminGetByMail(admin.adminMail);
                admin.lastEntryTime = DateTime.Now;
                adminManager.adminUpdate(admin);
                return RedirectToAction("Dashboard", "Dashboard");
			}
			_toastNotification.AddErrorToastMessage("Mail or password incorrect! Please try again.");
			TempData["init"] = 1;
			return RedirectToAction("Login");
		}
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Profile()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserMail = currentUser.FindFirst(ClaimTypes.Email).Value;
            Admin admin = adminManager.adminGetByMail(currentUserMail);
            return View(admin);
        }
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Admin> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Admins.Where(admin => admin.adminFirstName.Contains(searchText) || admin.adminLastName.Contains(searchText) ||
                admin.adminMail.Contains(searchText) || admin.adminType.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Admins.Where(admin => admin.adminFirstName.Contains(searchText) || admin.adminLastName.Contains(searchText) ||
                admin.adminMail.Contains(searchText) || admin.adminType.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Admins.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Admins.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "Admin";
            ViewBag.actionName = "admin-list";
            return View(data);
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            var admin = new Admin();
            return View(admin);
        }
        [HttpPost]
        public IActionResult AddAdmin(Admin admin)
        {
            AdminValidator validations = new AdminValidator();
            var result = validations.Validate(admin);
            if (result.IsValid)
            {
                admin.adminImgUrl = FileUpload(admin);
                adminManager.adminInsert(admin);
                int page = (int)TempData["page"];
                return RedirectToAction("admin-list", new { page, searchText = "" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(admin);
            }
        }
        public IActionResult DeleteAdmin(int id)
        {
            var admin = adminManager.adminGetById(id);
            admin.adminDeleted = true;
            adminManager.adminUpdate(admin);
            int page = (int)TempData["page"];
            return RedirectToAction("admin-list", new { page, searchText = "" });
        }
        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            var admin = adminManager.adminGetById(id);
            return View(admin);
        }
        [HttpPost]
        public IActionResult UpdateAdmin(Admin admin)
        {
            AdminValidator validations = new AdminValidator();
            var result = validations.Validate(admin);
            if (result.IsValid)
            {
                admin.adminImgUrl = FileUpload(admin);
                adminManager.adminUpdate(admin);
                int page = (int)TempData["page"];
                return RedirectToAction("admin-list", new { page, searchText = "" });

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(admin);
            }
        }
        private string FileUpload(Admin admin)
        {
            string uniquefileName = "";
            if (admin.imgFile != null)
            {
                uniquefileName = Guid.NewGuid().ToString() + "_" + admin.imgFile.FileName;
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "admin_images");
                string filePath = Path.Combine(uploadfolder, uniquefileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    admin.imgFile.CopyTo(stream);
                }
            }
            return uniquefileName;
        }
    }
}
