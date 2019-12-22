﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Semestrovka.Models.DBModels
{
    public class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
            Ordersofusers = new HashSet<Ordersofusers>();
        }

        public int Id { get; set; }

        [StringLength(255)] public string Firstname { get; set; }

        [StringLength(255)] public string Middlename { get; set; }

        [StringLength(255)] public string Lastname { get; set; }

        public int? City { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 4, ErrorMessage = "Incorrect login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Incorrect password")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [StringLength(255, MinimumLength = 4)] public string Address { get; set; }
        public string Token { get; set; }

        public virtual Cities CityNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Ordersofusers> Ordersofusers { get; set; }
    }
}