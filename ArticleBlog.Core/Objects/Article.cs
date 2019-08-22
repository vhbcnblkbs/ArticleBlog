using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleBlog.Core.Objects
{
    /// <summary>
    /// Makale Tablosu
    /// </summary>
    public class Article
    {
        public int ID { get; set; }
        [Display(Name = "Makale Başlığı")]
        [Required(ErrorMessage = "Makale Başlığı Giriniz")]
        [StringLength(50, ErrorMessage = "Makale Başlığı En Fazla 50 Karakter Olabilir")]
        public string Title { get; set; }
        [Display(Name = "Makale İçeriği")]
        [Required(ErrorMessage = "Makale İçeriği Giriniz")]
        public string Content { get; set; }
        public int UserID { get; set; }
        [Display(Name = "Makale Kategori")]
        [Required(ErrorMessage = "Makale Kategori Seçiniz")]
        public int CategoryID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
