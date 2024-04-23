using BharatCrafted.Data;
using BharatCrafted.Models;
using Microsoft.EntityFrameworkCore;


namespace ShoppingCart.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (!context.prods.Any())
            {
                Category fruits = new Category { Name = "Fruits", Slug = "fruits" };
                Category shirts = new Category { Name = "Shirts", Slug = "shirts" };

                context.prods.AddRange(
                        new Prod
                        {
                            Name = "Apples",
                            Slug = "apples",
                            Description = "Juicy apples",
                            Price = 1.50M,
                            Category = fruits,
                            Image = "apples.jpg"
                        },
                        new Prod
                        {
                            Name = "Bananas",
                            Slug = "bananas",
                            Description = "Fresh bananas",
                            Price = 3M,
                            Category = fruits,
                            Image = "bananas.jpg"
                        },
                        new Prod
                        {
                            Name = "Watermelon",
                            Slug = "watermelon",
                            Description = "Juicy watermelon",
                            Price = 0.50M,
                            Category = fruits,
                            Image = "watermelon.jpg"
                        },
                        new Prod
                        {
                            Name = "Grapefruit",
                            Slug = "grapefruit",
                            Description = "Juicy grapefruit",
                            Price = 2M,
                            Category = fruits,
                            Image = "grapefruit.jpg"
                        },
                        new Prod
                        {
                            Name = "White shirt",
                            Slug = "white-shirt",
                            Description = "White shirt",
                            Price = 5.99M,
                            Category = shirts,
                            Image = "white shirt.jpg"
                        },
                        new Prod
                        {
                            Name = "Black shirt",
                            Slug = "black-shirt",
                            Description = "Black shirt",
                            Price = 7.99M,
                            Category = shirts,
                            Image = "black shirt.jpg"
                        },
                        new Prod
                        {
                            Name = "Yellow shirt",
                            Slug = "yellow-shirt",
                            Description = "Yellow shirt",
                            Price = 11.99M,
                            Category = shirts,
                            Image = "yellow shirt.jpg"
                        },
                        new Prod
                        {
                            Name = "Grey shirt",
                            Slug = "grey-shirt",
                            Description = "Grey shirt",
                            Price = 12.99M,
                            Category = shirts,
                            Image = "grey shirt.jpg"
                        }
                );

                context.SaveChanges();
            }
        }
    }
}