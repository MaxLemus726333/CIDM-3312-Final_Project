using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Collections.Any())
        {
            return;
        }

        // Add Students, Courses, and StudentCourses below
        List<Collection> collections = new List<Collection>
        {
            new Collection { FirstName = "John", LastName = "Doe" },
            new Collection { FirstName = "Jane", LastName = "Smith" },
            new Collection { FirstName = "Michael", LastName = "Johnson" },
            new Collection { FirstName = "Emily", LastName = "Davis" },
            new Collection { FirstName = "Daniel", LastName = "Garcia" },
            new Collection { FirstName = "Sophia", LastName = "Martinez" },
            new Collection { FirstName = "William", LastName = "Rodriguez" },
            new Collection { FirstName = "Olivia", LastName = "Wilson" },
            new Collection { FirstName = "James", LastName = "Anderson" },
            new Collection { FirstName = "Isabella", LastName = "Thomas" },
            new Collection { FirstName = "Alexander", LastName = "Lee" },
            new Collection { FirstName = "Mia", LastName = "Perez" },
            new Collection { FirstName = "Benjamin", LastName = "Taylor" },
            new Collection { FirstName = "Charlotte", LastName = "Moore" },
            new Collection { FirstName = "Ethan", LastName = "Jackson" },
            new Collection { FirstName = "Amelia", LastName = "Martin" },
            new Collection { FirstName = "Logan", LastName = "Harris" },
            new Collection { FirstName = "Ava", LastName = "Clark" },
            new Collection { FirstName = "Mason", LastName = "Lewis" },
            new Collection { FirstName = "Harper", LastName = "Walker" },
            new Collection { FirstName = "Elijah", LastName = "Hall" },
            new Collection { FirstName = "Ella", LastName = "Allen" },
            new Collection { FirstName = "Liam", LastName = "Young" },
            new Collection { FirstName = "Grace", LastName = "King" },
            new Collection { FirstName = "Noah", LastName = "Scott" },
            new Collection { FirstName = "Aiden", LastName = "Green" },
            new Collection { FirstName = "Abigail", LastName = "Adams" },
            new Collection { FirstName = "Lucas", LastName = "Baker" },
            new Collection { FirstName = "Emily", LastName = "Carter" },
            new Collection { FirstName = "Oliver", LastName = "Nelson" },
            new Collection { FirstName = "Hannah", LastName = "Hill" },
            new Collection { FirstName = "Jacob", LastName = "Ramirez" },
            new Collection { FirstName = "Victoria", LastName = "Mitchell" },
            new Collection { FirstName = "Matthew", LastName = "Roberts" },
            new Collection { FirstName = "Chloe", LastName = "Phillips" },
            new Collection { FirstName = "Henry", LastName = "Campbell" },
            new Collection { FirstName = "Zoe", LastName = "Parker" },
            new Collection { FirstName = "Samuel", LastName = "Evans" },
            new Collection { FirstName = "Lily", LastName = "Edwards" },
            new Collection { FirstName = "David", LastName = "Collins" },
            new Collection { FirstName = "Avery", LastName = "Stewart" },
            new Collection { FirstName = "Joseph", LastName = "Sanchez" },
            new Collection { FirstName = "Samantha", LastName = "Morris" },
            new Collection { FirstName = "Gabriel", LastName = "Rogers" },
            new Collection { FirstName = "Sofia", LastName = "Reed" },
            new Collection { FirstName = "Jackson", LastName = "Cook" },
            new Collection { FirstName = "Mila", LastName = "Morgan" },
            new Collection { FirstName = "Sebastian", LastName = "Bell" },
            new Collection { FirstName = "Layla", LastName = "Murphy" },
            new Collection { FirstName = "Emma", LastName = "Patterson" }
        };
        context.AddRange(collections);
        context.SaveChanges();

        //     List<Gen> gen = new List<Gen>
        // {
        //     new Card { Description = "Generation 1" },
        //     new Card { Description = "Generation 2" },
        //     new Card { Description = "Generation 3" },
        //     new Card { Description = "Generation 4" },
        //     new Card { Description = "Generation 5" },
        //     new Card { Description = "Generation 6" },
        //     new Card { Description = "Generation 7" },
        //     new Card { Description = "Generation 8" },
        //     new Card { Description = "Generation 9" }
        // };
        // context.AddRange(gen);
        // context.SaveChanges();
//AAAAHHHHHHH why did I choose this, IDK how I, of all people 
//forgot how many pokemon there are but oh well did this to myself

        List<Card> cards = new List<Card>
        {
            new Card { Description = "Mewtwo" },
            new Card { Description = "Lugia" },
            new Card { Description = "Articuno" },
            new Card { Description = "Zapdos" },
            new Card { Description = "Articuno" }
        };
        context.AddRange(cards);
        context.SaveChanges();

        List<CollectionCard> collectionCards = new List<CollectionCard>
        {
            new CollectionCard { CollectionID = 1, CardID = 1 },
            new CollectionCard { CollectionID = 1, CardID = 2 },
            new CollectionCard { CollectionID = 1, CardID = 3 },

            new CollectionCard { CollectionID = 2, CardID = 1 },
            new CollectionCard { CollectionID = 2, CardID = 4 },

            new CollectionCard { CollectionID = 3, CardID = 5 },

            new CollectionCard { CollectionID = 4, CardID = 2 },
            new CollectionCard { CollectionID = 4, CardID = 3 },

            new CollectionCard { CollectionID = 5, CardID = 1 },

            new CollectionCard { CollectionID = 6, CardID = 2 },
            new CollectionCard { CollectionID = 6, CardID = 4 },
            new CollectionCard { CollectionID = 6, CardID = 5 },

            new CollectionCard { CollectionID = 7, CardID = 3 },

            new CollectionCard { CollectionID = 8, CardID = 1 },
            new CollectionCard { CollectionID = 8, CardID = 5 },

            new CollectionCard { CollectionID = 9, CardID = 2 },
            new CollectionCard { CollectionID = 9, CardID = 3 },
            new CollectionCard { CollectionID = 9, CardID = 4 },

            new CollectionCard { CollectionID = 10, CardID = 5 },

            new CollectionCard { CollectionID = 11, CardID = 2 },
            new CollectionCard { CollectionID = 11, CardID = 4 },

            new CollectionCard { CollectionID = 12, CardID = 1 },
            new CollectionCard { CollectionID = 12, CardID = 3 },
            new CollectionCard { CollectionID = 12, CardID = 5 },

            new CollectionCard { CollectionID = 13, CardID = 4 },
            new CollectionCard { CollectionID = 13, CardID = 5 },

            new CollectionCard { CollectionID = 14, CardID = 1 },

            new CollectionCard { CollectionID = 15, CardID = 2 },
            new CollectionCard { CollectionID = 15, CardID = 5 },

            new CollectionCard { CollectionID = 16, CardID = 3 },
            new CollectionCard { CollectionID = 16, CardID = 4 },

            new CollectionCard { CollectionID = 17, CardID = 1 },

            new CollectionCard { CollectionID = 18, CardID = 3 },
            new CollectionCard { CollectionID = 18, CardID = 5 },

            new CollectionCard { CollectionID = 19, CardID = 2 },

            new CollectionCard { CollectionID = 20, CardID = 1 },
            new CollectionCard { CollectionID = 20, CardID = 4 },
            new CollectionCard { CollectionID = 20, CardID = 5 },

            new CollectionCard { CollectionID = 21, CardID = 3 },
            new CollectionCard { CollectionID = 21, CardID = 4 },

            new CollectionCard { CollectionID = 22, CardID = 2 },

            new CollectionCard { CollectionID = 23, CardID = 1 },
            new CollectionCard { CollectionID = 23, CardID = 3 },
            new CollectionCard { CollectionID = 23, CardID = 5 },

            new CollectionCard { CollectionID = 24, CardID = 2 },
            new CollectionCard { CollectionID = 24, CardID = 4 },

            new CollectionCard { CollectionID = 25, CardID = 3 },

            new CollectionCard { CollectionID = 26, CardID = 1 },
            new CollectionCard { CollectionID = 26, CardID = 5 },

            new CollectionCard { CollectionID = 27, CardID = 2 },
            new CollectionCard { CollectionID = 27, CardID = 3 },
            new CollectionCard { CollectionID = 27, CardID = 4 },

            new CollectionCard { CollectionID = 28, CardID = 5 },

            new CollectionCard { CollectionID = 29, CardID = 1 },
            new CollectionCard { CollectionID = 29, CardID = 2 },
            new CollectionCard { CollectionID = 29, CardID = 4 },

            new CollectionCard { CollectionID = 30, CardID = 3 },
            new CollectionCard { CollectionID = 30, CardID = 5 },

            new CollectionCard { CollectionID = 31, CardID = 4 },

            new CollectionCard { CollectionID = 32, CardID = 2 },
            new CollectionCard { CollectionID = 32, CardID = 3 },

            new CollectionCard { CollectionID = 33, CardID = 1 },
            new CollectionCard { CollectionID = 33, CardID = 4 },
            new CollectionCard { CollectionID = 33, CardID = 5 },

            new CollectionCard { CollectionID = 34, CardID = 3 },

            new CollectionCard { CollectionID = 35, CardID = 1 },
            new CollectionCard { CollectionID = 35, CardID = 5 },

            new CollectionCard { CollectionID = 36, CardID = 2 },

            new CollectionCard { CollectionID = 37, CardID = 3 },
            new CollectionCard { CollectionID = 37, CardID = 4 },
            new CollectionCard { CollectionID = 37, CardID = 5 },

            new CollectionCard { CollectionID = 38, CardID = 1 },

            new CollectionCard { CollectionID = 39, CardID = 2 },
            new CollectionCard { CollectionID = 39, CardID = 3 },

            new CollectionCard { CollectionID = 40, CardID = 4 },

            new CollectionCard { CollectionID = 41, CardID = 1 },
            new CollectionCard { CollectionID = 41, CardID = 5 },

            new CollectionCard { CollectionID = 42, CardID = 2 },
            new CollectionCard { CollectionID = 42, CardID = 3 },
            new CollectionCard { CollectionID = 42, CardID = 4 },

            new CollectionCard { CollectionID = 43, CardID = 5 },

            new CollectionCard { CollectionID = 44, CardID = 1 },
            new CollectionCard { CollectionID = 44, CardID = 4 },

            new CollectionCard { CollectionID = 45, CardID = 3 },

            new CollectionCard { CollectionID = 46, CardID = 2 },
            new CollectionCard { CollectionID = 46, CardID = 3 },
            new CollectionCard { CollectionID = 46, CardID = 5 },

            new CollectionCard { CollectionID = 47, CardID = 4 },

            new CollectionCard { CollectionID = 48, CardID = 1 },
            new CollectionCard { CollectionID = 48, CardID = 5 },

            new CollectionCard { CollectionID = 49, CardID = 2 },
            new CollectionCard { CollectionID = 49, CardID = 3 },
            new CollectionCard { CollectionID = 49, CardID = 4 },

            new CollectionCard { CollectionID = 50, CardID = 5 }
        };
        context.AddRange(collectionCards);
        context.SaveChanges();
    }
}