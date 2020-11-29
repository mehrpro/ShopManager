using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace SPS.Entities.Product
{
    public class IndexStore
    {
        public int IndexId { get; set; }
        public byte IndexNumber { get; set; }
        public string IndexName { get; set; }
        public string IndexDescription { get; set; }

    }

    public class IndexStoreViewModel
    {
        [Display(Name="شناسه")]
        public int IndexId { get; set; }
        [Display(Name = "شماره",Prompt = "شماره انبار : قسمت اول کدینگ : 8xxyyzzzz")]
        public byte IndexNumber { get; set; }
        [Display(Name = "نام انبار",Prompt = "نام و عنوان انبار اصلی : انبار قطعات یدکی")]
        public string IndexName { get; set; }
        [Display(Name = "توضیحات",Prompt = "توضیحاتی در مورد انبار ")]
        public string IndexDescription { get; set; }
    }

    public class IndexStoreValidator : AbstractValidator<IndexStoreViewModel>
    {
        public IndexStoreValidator()
        {
            RuleFor(x => x.IndexNumber).NotNull().WithMessage("کد انبار عددی بین 1 الی 99 می تواند باشد")
                .GreaterThanOrEqualTo((byte)1).WithMessage("کد انبار عددی بین 1 الی 99 می تواند باشد")
                .LessThanOrEqualTo((byte)99).WithMessage("کد انبار عددی بین 1 الی 99 می تواند باشد");
            RuleFor(x => x.IndexName)
                .NotNull().WithMessage("شرح و عنوان انبار باید وارد شود")
                .MaximumLength(100).WithMessage("عنوان و نام انبار بیشتر از 100 حرف نمی تواند باشد")
                .NotEmpty().WithMessage("شرح و عنوان انبار باید وارد شود");
            RuleFor(x=>x.IndexDescription)
                .MaximumLength(150).WithMessage("عنوان و نام انبار بیشتر از 150 حرف نمی تواند باشد");
        }
    }


}