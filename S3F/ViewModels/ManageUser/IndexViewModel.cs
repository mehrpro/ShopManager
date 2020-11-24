using System.ComponentModel.DataAnnotations;

namespace SPS.ViewModels.ManageUser
{
    public class IndexViewModel
    {
        [Display(Name ="شناسه")]
        public string Id { get; set; }
        [Display(Name ="نام کاربری")]
        public string UserName { get; set; }
        [Display(Name ="ایمیل")]
        public string Email { get; set; }
    }
}
