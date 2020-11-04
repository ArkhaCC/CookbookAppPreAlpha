using System;

namespace CookbookApp.Model
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace CookbookApp.Model
    {
        public class RecipeContext : DbContext
        {
            public DbSet<Recipe> Recipes { get; set; }
            public DbSet<Tags> tags { get; set; }

            public DbSet<User> user { get; set; }

            public DbSet<AccessFrequency> accessFrequency { get; set; }

            public RecipeContext(DbContextOptions<RecipeContext> options)
        : base(options)
            { }
        }

        public class User 
        {
            [Key]
            public string UserID { get; set; }
            public DateTime LastLogin { get; set; }

            public List<Recipe> Recipes { get; } = new List<Recipe>();
        }

        public class Recipe 
        {
            [Key]
            public string RecipeID { get; set; }
            public byte[] SavedRecipe { get; set; }
            public DateTime DateSaved { get; set; }

            public Tags AppliedTags { get; set; }
            //TODO: Learn Navigation Properties
        }

        public class Tags 
        {
            [Key]
            public string TagID { get; set; }
            public Recipe recipe { get; }
        }

        public class AccessFrequency 
        {
            public int AccessfrequencyID { get; set; }
            public Recipe recipe { get; set; }
            public DateTime DateLastAccessed { get; set; }
            
            public int TimesAccessed { get; set; }
        }
    }
}

