using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Web_Project.Storage.Entity
{
    public class Order : IdentityUser
    {
       [BindNever]
       public int id { get; set; }
       [Display(Name = "Ведите Имя")]
       [StringLength(10)]
       [Required(ErrorMessage ="Имя больше 10 символов")]
       public string name { get; set; }
       [Display(Name = "Ведите Фамилию")]
       [StringLength(15)]
       [Required(ErrorMessage = "Фамилия больше 15 символов")]
       public string surname { get; set; }
       [Display(Name = "Ведите Адресс")]
       [StringLength(30)]
       [Required(ErrorMessage = "Адресс больше 30 символов")]
       public string adress { get; set; }
       [Display(Name = "Телефон")]
       [DataType(DataType.PhoneNumber)]
       [StringLength(11)]
       [Required(ErrorMessage = "Неверный телефон")]
       public string phone { get; set; }
       [Display(Name ="Email")]
       [DataType(DataType.EmailAddress)]
       [StringLength(30)]
       [Required(ErrorMessage = "Email больше 30 символов")]
       [Key]
        public string mail { get; set; }
       [Required]
       [Display(Name = "Придумайте пароль")]
       [DataType(DataType.Password)]
       public string Password { get; set; }

       [Required]
       [Display(Name = "Повторите пароль")]
       [Compare("Password", ErrorMessage = "Пароли не совпадают")]
       [DataType(DataType.Password)]
       public string PasswordConfirm { get; set; }
       
       [BindNever]
       [ScaffoldColumn(false)]
       public DateTime ordertime { get; set; }
       public List<OrderDetail> orderDetail { get; set; }

    }
}
