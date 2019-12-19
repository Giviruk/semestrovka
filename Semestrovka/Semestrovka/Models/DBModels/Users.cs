﻿using System.Collections.Generic;

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
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public int? City { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }

        public virtual Cities CityNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Ordersofusers> Ordersofusers { get; set; }
    }
}