using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace SPS.ViewModels.Shop
{
    public class UnitViewModel
    {

        
        public int UnitId { get; set; }

        [Display(Name = "واحد")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "{0} باید وارد شود")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$",ErrorMessage = @"از کارکترهای غیر مجاز استفاده نکنید")]
        [Remote("IsNameInUse", "Units", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]// کنترل مقادیر از طریق ای جکس فقط با این خصوصیت بدون یک کد اضافه جاوا
        public string UnitName { get; set; }
        [Display(Name = "وضعیت")]
        public bool Enabled { get; set; }

        public bool IsDelete { get; set; }

    }
}
