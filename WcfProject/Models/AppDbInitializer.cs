using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WcfTest.Models
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            var Teapots = new List<Teapot>
            {
                new Teapot
                {
                    Id = 1,
                    Title = "Teapot 1",
                    Quantity = 11,
                    Price = 2899,
                    Description = "Some good teapot",
                    WarrantyInMonths = 12,
                    ImgUrl = "image1.png",
                    Capacity = 1.8,
                    ManufacturerCountry = "Germany"
                },
                new Teapot
                {
                    Id = 2,
                    Title = "Teapot 2",
                    Quantity = 12,
                    Price = 2900,
                    Description = "Some good teapot",
                    WarrantyInMonths = 12,
                    ImgUrl = "image2.png",
                    Capacity = 1.7,
                    ManufacturerCountry = "China"
                }
            };

            context.Teapots.AddRange(Teapots);
            context.SaveChanges();
        }
    }
}