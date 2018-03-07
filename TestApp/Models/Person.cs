using System;
using System.Data.SqlClient;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
   public enum Sex
    {
        Unknown,
        Men,
        Women
    }

    public class Person
    {
        public int Id { get; set; }

        [Display (Name ="Имя")]
        [Required (ErrorMessage ="Данное поле обязательно для заполнения")]
        [MaxLength(100, ErrorMessage ="Превышена максимальная длина данного поля")]
        public string Name  { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [MaxLength(100, ErrorMessage = "Превышена максимальная длина данного поля")]
        public string MiddleName { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [MaxLength(100, ErrorMessage = "Превышена максимальная длина данного поля")]
        public string Patronic { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Пол")]
        public Sex Sex { get; set; }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        public int Age { get; set; }
    }

    public class PersonContext : DbContext
    {
        public PersonContext () : base("DefaultConnection")
        {
          
        }

      public  DbSet <Person> People { get; set; }
    }


    

    
}