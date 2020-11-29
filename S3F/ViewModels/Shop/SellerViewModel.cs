using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace SPS.ViewModels.Shop
{
    public class SellerViewModel
    {
                [Display(Name = "شناسه")]

        public int SellerId { get; set; }
        [Display(Name = "نام و فامیلی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} باید وارد شود")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = @"از کارکترهای غیر مجاز استفاده نکنید")]
        [Remote("IsNameInUse", "Sellers", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]// کنترل مقادیر از طریق ای جکس فقط با این خصوصیت بدون یک کد اضافه جاوا
        public string SellerName { get; set; }
        [Display(Name = "شرکت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} باید وارد شود")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = @"از کارکترهای غیر مجاز استفاده نکنید")]
        [Remote("IsCompanyInUse", "Sellers", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]// کنترل مقادیر از طریق ای جکس فقط با این خصوصیت بدون یک کد اضافه جاوا
        public string Company { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime Register { get; set; }
        [Display(Name = "وضعیت")]
        public bool Enabled { get; set; }
        [Display(Name = "تلفن دفتر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} باید وارد شود")]
      //  [RegularExpression(@"[0-9]", ErrorMessage = @"از کارکترهای غیر مجاز استفاده نکنید")]
        public string PhoneNumber1 { get; set; }
        [Display(Name = "تلفن همراه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} باید وارد شود")]
      //  [RegularExpression(@"[0-9]", ErrorMessage = @"از کارکترهای غیر مجاز استفاده نکنید")]
        [Remote("IsMobileInUse", "Sellers", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]// کنترل مقادیر از طریق ای جکس فقط با این خصوصیت بدون یک کد اضافه جاوا
        public string MobileNumber1 { get; set; }
        [Display(Name = "فکس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} باید وارد شود")]
       // [RegularExpression(@"0\d\d\d\d\d\d\d\d\d\d", ErrorMessage = @"از کارکترهای غیر مجاز استفاده نکنید")]
        public string FaxNumber { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        public int AddressId { get; set; }
    }
}