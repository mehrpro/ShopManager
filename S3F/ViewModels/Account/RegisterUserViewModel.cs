﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace SPS.ViewModels.Account
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "نام کاربری")]
        [Remote("IsUsernameInUse","Account",HttpMethod = "POST",
        AdditionalFields = "__RequestVerificationToken")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "ایمیل کاربر")]
        [EmailAddress(ErrorMessage = "قالب آدرس ایمیل درست وارد نشده است")]
        [Remote("IsEmailInUse", "Account" , HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]// کنترل مقادیر از طریق ای جکس فقط با این خصوصیت بدون یک کد اضافه جاوا

        public string Email { get; set; }


        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "تکرار رمز عبور")]
        [Compare(nameof(Password),ErrorMessage = "رمزعبور یکسان نیست")]
        [DataType(DataType.Password)]
        public string ComfermPassword { get; set; }
    }
}
