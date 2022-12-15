﻿namespace WcfTest.Models
{
    public class Teapot
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }

        public string ManufacturerCountry { get; set; }

        public double Capacity { get; set; }

        public int WarrantyInMonths { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nTitle: {Title}\nQuantity: {Quantity}\nPrice: {Price}UAH\nManufacturer: { ManufacturerCountry}\n";
        }
    }
}
