using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class ServiceItem :EntityBase
    {
        [Required(ErrorMessage ="Заполните название услуги")]
        [Display(Name ="Название услуги")]
        public override string Title { get; set; }

        [Display(Name ="Краткое описание услгуи")]
        public override string SubTitle { get; set; }

        [Display(Name ="Полное описание услгуи")]
        public override string Text { get; set; }
    }
}
