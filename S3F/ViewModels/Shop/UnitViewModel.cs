using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SPS.ViewModels.Shop
{
    public class UnitViewModel
    {

        [Display(Name = "واحد")]
        [Required(ErrorMessage = "{0} باید وارد شود")]
        [Remote("IsNameInUse", "Units", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]// کنترل مقادیر از طریق ای جکس فقط با این خصوصیت بدون یک کد اضافه جاوا

        public string UnitName { get; set; }

    }
}
