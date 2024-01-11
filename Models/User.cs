﻿using System.ComponentModel.DataAnnotations;

namespace productoApp.Models
{
    public class User : : ObservableObject
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string UserMail { get; set; }
        [Required]
        public string UserPassword { get; set; }
       

    }
}
