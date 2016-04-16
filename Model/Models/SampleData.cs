using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<WebContext>
    {
        protected override void Seed(WebContext context)
        {
            var categoriess = new List<Category>
            {
                new Category { Name = "Cars" },
                new Category { Name = "Electronics" },
                new Category { Name = "Food" },
                new Category { Name = "Games" },
                new Category { Name = "Furniture" },
                new Category { Name = "Clothes" },

            };

            new List<Product>
            {
                new Product {Name="Tire", Category=categoriess.Single(x=>x.Name=="Cars"),Price=49.99M},
                new Product {Name="Computer", Category=categoriess.Single(x=>x.Name=="Electronics"),Price=149.99M},
                new Product {Name="Sandwich", Category=categoriess.Single(x=>x.Name=="Food"),Price=1.99M},
                new Product {Name="PC game", Category=categoriess.Single(x=>x.Name=="Games"),Price=19.99M},
                new Product {Name="CofeeTable", Category=categoriess.Single(x=>x.Name=="Furniture"),Price=39.99M},
                new Product {Name="Bumper", Category=categoriess.Single(x=>x.Name=="Cars"),Price=56.99M},
                new Product {Name="CarLights", Category=categoriess.Single(x=>x.Name=="Cars"),Price=32.99M},
                new Product {Name="WindShield", Category=categoriess.Single(x=>x.Name=="Cars"),Price=26.99M},
                new Product {Name="CarOil", Category=categoriess.Single(x=>x.Name=="Cars"),Price=20.99M},
                new Product {Name="Gasoline", Category=categoriess.Single(x=>x.Name=="Cars"),Price=4.99M},
                new Product {Name="RearBumper", Category=categoriess.Single(x=>x.Name=="Cars"),Price=89.99M},
                new Product {Name="Computer", Category=categoriess.Single(x=>x.Name=="Electronics"),Price=149.99M},
                new Product {Name="Sandwich", Category=categoriess.Single(x=>x.Name=="Food"),Price=1.99M},
                new Product {Name="PC game", Category=categoriess.Single(x=>x.Name=="Games"),Price=19.99M},
                new Product {Name="CofeeTable", Category=categoriess.Single(x=>x.Name=="Furniture"),Price=39.99M},
                new Product {Name="Shirt", Category=categoriess.Single(x=>x.Name=="Clothes"),Price=39.99M},
                new Product {Name="Pants", Category=categoriess.Single(x=>x.Name=="Clothes"),Price=39.99M},
            }.ForEach(a => context.Products.Add(a));

        }
    }
}
