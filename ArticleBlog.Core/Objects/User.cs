using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ArticleBlog.Core.Objects
{
    /// <summary>
    /// Kullanıcı Tablosu
    /// </summary>
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz!")]
        [Display(Name = "Kullanıcı Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kullanıcı Soyadı Giriniz!")]
        [Display(Name = "Kullanıcı Soyadı")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "E-Posta Giriniz!")]
        [Display(Name = "E-Posta ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola Giriniz!")]
        [Display(Name = "Parola")]
        public string Password { get; set; }
        public bool Gentle { get; set; }
        [Display(Name = "Üye Statüsü")]
        public int UserStatu { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
