using CookbookApp.Model.CookbookApp.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace CookbookApp.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            RecipeContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RecipeContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        RecipeID = "Chicken Chilaquiles",
                        //SavedRecipe = PdfDocument.FromFile("D:MSSA Homework/Visual Studio Projects/CourseProject-master(1)/CourseProject-master/SampleRecipes"); //TODO: Determine appropriate file path for PDF using IronPdf
            });
            }
        }
    }
}
