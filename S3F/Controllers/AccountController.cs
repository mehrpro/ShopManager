using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SPS.Repository;
using SPS.ViewModels.Account;

namespace SPS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMessageSend21 _messageSend21;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IMessageSend21 messageSend21)
        {
            _userManager = userManager;//کلاسی برای دسترسی به جدول کاربران و متدهای مانند ایجاد کاربر و بررسی صحت نام کاربری وپسورد
            _signInManager = signInManager;//کلاسی برای مدیریت ورود و خروج کاربران
            _messageSend21 = messageSend21;
        }


        [HttpGet]//کنترلر ثبت نام کاربران
        public IActionResult Register()
        {
            //if (_signInManager.IsSignedIn(User))//بررسی اینکه آیا کاربر وارد شده است که اگر وارد شده باشد دیگر به صفحه ثبت نام دسترسی ندارد
            //    return RedirectToAction("index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel register)
        {
            //ثبت نام کاربر جدید
            if (ModelState.IsValid)// بررسی صحت مقادیر
            {
                var user = new IdentityUser()// مپ کردن مدل به مدل
                {
                    UserName = register.UserName,
                    Email = register.Email,
                };

                var result = await _userManager.CreateAsync(user, register.Password);// ساخت کاربر جدید

                if (result.Succeeded)// اگر ایجاد در بانک موفقیت آمیزباشد
                {
                    var emailConfirmationToken =
                        await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var emailMessage =
                        Url.Action("ConfirmEmail", "Account",
                            new { username = user.UserName, token = emailConfirmationToken },
                            Request.Scheme);
                   await _messageSend21.SendEmailAsync(register.Email, "Email confirmation", emailMessage);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)// اگر خطایی رخ دهد
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(register);// بازگشت به صفحه ثبت نام با لیست خطاها
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))//بررسی اینکه آیا کاربر وارد شده است که اگر وارد شده باشد دیگر به صفحه  ورود دسترسی ندارد
                return RedirectToAction("index", "Home");
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login ,string returnUrl = null)// بررسی صحت ورود
        {
            if (_signInManager.IsSignedIn(User))//بررسی اینکه آیا کاربر وارد شده است که اگر وارد شده باشد دیگر به صفحه  ورود دسترسی ندارد
                return RedirectToAction("index", "Home");

            ViewData["returnUrl"] = returnUrl;
            if (ModelState.IsValid)//مقادیر درست است
            {
                var result = await _signInManager.PasswordSignInAsync(
                    login.UserName, login.Password, login.Remember, true);// بررسی صحت نام کاربری و رمز عبور


                if (result.Succeeded)// ورود موفقیت آمیز است
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))// بررسی اینکه لینک بازگشتی خالی نباشد و حتما مربوط به لینک های این سایت است
                        return RedirectToAction(returnUrl);


                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)// کاربر قفل شده است
                {
                    ViewData["ErrorMessage"] = $" ارتباط شما  بدلیل اشتباه وارد کردن تا 10 دقیقه مسدود خواهد بود";
                    return View(login);
                }
                ModelState.AddModelError("", "رمز عبور یا نام کاربری شما اشتباه است");
            }

            return View(login);
        }

        [HttpPost]// خروج کاربر که حتما باید از خصوصیت پست برای آن استفاده کرد
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();// خروج کاربر
            return RedirectToAction("Index", "Home");//رفتن به صفحه نخست
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var find = await _userManager.FindByEmailAsync(email);
            if (find == null) return Json(true);
            return Json("این ایمیل قبلا ثبت شده است");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUsernameInUse(string username)
        {
            var find = await _userManager.FindByNameAsync(username);
            if (find == null) return Json(true);
            return Json("این نام کاربری قبلا ثبت شده است");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userName, string token)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(token))
                return NotFound();
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return NotFound();
            var result = await _userManager.ConfirmEmailAsync(user, token);

            return Content(result.Succeeded ? "Email Confirmed" : "Email Not Confirmed");
        }
    }
}
