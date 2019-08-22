using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticleBlog.Core.Objects
{
    public class Category
    {
        [Display(Name = "Kategori Id")]
        public int ID { get; set; }
        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "Kategori Adı Giriniz")]
        [StringLength(50, ErrorMessage = " Kategori Adı En Fazla 50 Karakter Olabilir")]
        public string Name { get; set; }
    }
}
