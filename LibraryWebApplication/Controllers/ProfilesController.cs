using LibraryWebApplication.Data;
using LibraryWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ILogger<ProfilesController> _logger;
        private readonly LibraryWebApplicationContext _context;

        public ProfilesController(ILogger<ProfilesController> logger, LibraryWebApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                    firstName = model.FirstName,
                    lastName = model.LastName,
                    phoneNumber = model.PhoneNumber,
                    roleID = 1
                    // You can set the role here or use a default role, etc.
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                HttpContext.Session.SetString("firstName", newUser.firstName);
                HttpContext.Session.SetString("lastName", newUser.lastName);

                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, so redisplay the form
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userInDb = _context.Users.SingleOrDefault(u => u.Email == model.Email);

            if (userInDb == null)
            {
                ModelState.AddModelError("", "Invalid email address.");
                return View(model);
            }

            if (model.Password != userInDb.Password)
            {
                ModelState.AddModelError("", "Invalid password.");
                return View(model);
            }

            if (userInDb.isBlocked)
            {
                ModelState.AddModelError("", "Your account is blocked. Please contact the admin.");
                return View(model);
            }

            HttpContext.Session.SetInt32("userId", userInDb.userID);
            HttpContext.Session.SetInt32("userRole", userInDb.roleID);
            HttpContext.Session.SetString("firstName", userInDb.firstName);
            HttpContext.Session.SetString("lastName", userInDb.lastName);

            // Check if the "Remember Me" checkbox is selected
            if (model.RememberMe)
            {
                var option = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)
                };
                Response.Cookies.Append("UserLoginCookie", userInDb.userID.ToString(), option);
            }

            return RedirectToAction("Index", "Home");
        }




        public User GetCurrentUser()
        {
            var userId = HttpContext.Session.GetInt32("userId");

            if (userId.HasValue)
            {
                return _context.Users.FirstOrDefault(u => u.userID == userId.Value);
            }

            return null;
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var userId = HttpContext.Session.GetInt32("userId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = _context.Users.Find(userId);

            var viewModel = new EditProfileViewModel
            {
                FirstName = user.firstName,
                LastName = user.lastName,
                PhoneNumber = user.phoneNumber,
                Email = user.Email
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(EditProfileViewModel model)
        {
            var userId = HttpContext.Session.GetInt32("userId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = _context.Users.Find(userId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.OldPassword) &&
                model.OldPassword != user.Password)
            {
                ModelState.AddModelError("", "Invalid old password.");
                return View(model);
            }

            user.firstName = model.FirstName;
            user.lastName = model.LastName;
            user.phoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                user.Password = model.NewPassword;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> ManageUsers()
        {
            if (HttpContext.Session.GetInt32("userRole") != 2)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(await _context.Users.ToListAsync());
        }

        // This function will change the "isBlocked" attribute of user with given id. This function should be accessible only for users with role "Administrator"
        public async Task<IActionResult> ChangeBlockStatus(int? id)
        {
            if (HttpContext.Session.GetInt32("userRole") != 2)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.isBlocked = !user.isBlocked;
            _context.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageUsers));
        }

        // This function will delete user with given id from database. This function should be accessible only for users with role "Administrator"
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("userRole") != 2)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageUsers));
        }
    }
}
