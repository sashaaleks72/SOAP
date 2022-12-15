using System;
using WcfClient.TeapotServiceReference;

namespace WcfClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new TeapotServiceClient();

            Console.WriteLine("Recieving all teapots from db");
            var teapots = client.GetTeapots();

            if (teapots != null)
            {
                foreach (var t in teapots)
                {
                    Console.WriteLine($"Id: {t.Id}\nTitle: {t.Title}\nQuantity: {t.Quantity}\nPrice: {t.Price}UAH\nManufacturer: {t.ManufacturerCountry}\n");
                }
            }

            Console.WriteLine("Recieving teapot by id = 1");
            var teapot = client.GetTeapotById(1);
            Console.WriteLine($"Id: {teapot.Id}\nTitle: {teapot.Title}\nQuantity: {teapot.Quantity}\nPrice: {teapot.Price}UAH\nManufacturer: {teapot.ManufacturerCountry}\n");

            Console.WriteLine("Adding new teapot");
            var teapotToAdd = new Teapot
            {
                Title = "Teapot 3",
                Description = "Some good teapot",
                ImgUrl = "image3.png",
                ManufacturerCountry = "China",
                Price = 1899,
                Quantity = 10,
                WarrantyInMonths = 12,
                Capacity = 1.9
            };

            client.AddTeapot(teapotToAdd);

            Console.WriteLine("The result after adding: ");
            teapots = client.GetTeapots();

            if (teapots != null)
            {
                foreach (var t in teapots)
                {
                    Console.WriteLine($"Id: {t.Id}\nTitle: {t.Title}\nQuantity: {t.Quantity}\nPrice: {t.Price}UAH\nManufacturer: {t.ManufacturerCountry}\n");
                }
            }

            Console.WriteLine("Updating last teapot");
            var teapotToUpdate = client.GetTeapotById(3);

            if (teapotToUpdate != null)
            {
                teapotToUpdate.Title = "Teapot Model C30";
                client.EditTeapot(teapotToUpdate);
            }

            Console.WriteLine("The result after updating: ");
            teapots = client.GetTeapots();

            if (teapots != null)
            {
                foreach (var t in teapots)
                {
                    Console.WriteLine($"Id: {t.Id}\nTitle: {t.Title}\nQuantity: {t.Quantity}\nPrice: {t.Price}UAH\nManufacturer: {t.ManufacturerCountry}\n");
                }
            }

            Console.WriteLine("Removing last teapot");
            client.DeleteTeapotById(3);

            Console.WriteLine("The result after removing: ");
            teapots = client.GetTeapots();

            if (teapots != null)
            {
                foreach (var t in teapots)
                {
                    Console.WriteLine($"Id: {t.Id}\nTitle: {t.Title}\nQuantity: {t.Quantity}\nPrice: {t.Price}UAH\nManufacturer: {t.ManufacturerCountry}\n");
                }
            }

            client.Close();
        }
    }
}
