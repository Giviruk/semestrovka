﻿namespace Semestrovka.Models.DBModels
{
    public partial class Productimages
    {
        public int Id { get; set; }
        public int? Productid { get; set; }
        public int? Imageid { get; set; }

        public virtual Images Image { get; set; }
        public virtual Product Product { get; set; }
    }
}
