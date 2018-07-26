namespace VideoStore.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            
            return random.Next(min, max);
        }

        protected override void Seed(VideoStore.Models.ApplicationDbContext context)
        {
            string FirstName = "Customer";
            var rnd = new Random();
            //Random number generation through Linq. Random doesn't exclude duplicate.
            var randomNumbers = Enumerable.Range(1, 49).OrderBy(x => rnd.Next()).Take(18).ToList();
            var RandomStockNumbers = Enumerable.Range(1, 20).OrderBy(x => rnd.Next()).Take(4).ToList();
            var RandomGenreNumbers = Enumerable.Range(1, 8).OrderBy(x => rnd.Next()).Take(4).ToList();
            //How to seed a table. Membership types seeind done through a migration. Its under "SeedingMembership"
            context.Customers.AddOrUpdate(h => h.Id,new Customer() { Name = FirstName+" "+ randomNumbers[1], IsSubscribeToNewsLetter = false, MembershipTypeId = 1, BirthDate = new DateTime(1979, 12, 12) });
            context.Customers.AddOrUpdate(h => h.Id,new Customer() { Name = FirstName + " " + randomNumbers[2], IsSubscribeToNewsLetter = false, MembershipTypeId = 1, BirthDate = new DateTime(1980, 1, 1) });
            context.Customers.AddOrUpdate(h => h.Id,new Customer() { Name = FirstName + " " + randomNumbers[3], IsSubscribeToNewsLetter = true, MembershipTypeId = 2, BirthDate = new DateTime(1981, 2, 2) });
            context.Customers.AddOrUpdate(h => h.Id, new Customer() { Name = FirstName + " " + randomNumbers[4], IsSubscribeToNewsLetter = true, MembershipTypeId = 3, BirthDate = new DateTime(1982, 3, 3) });
            context.Genres.AddOrUpdate(new Genre() { Id = 1, Name = "Genre 1" });
            context.Genres.AddOrUpdate(new Genre() { Id = 2, Name = "Genre 2" });
            context.Genres.AddOrUpdate(new Genre() { Id = 3, Name = "Genre 3" });
            context.Genres.AddOrUpdate(new Genre() { Id = 4, Name = "Genre 4" });
            context.Genres.AddOrUpdate(new Genre() { Id = 5, Name = "Genre 5"});
            context.Genres.AddOrUpdate(new Genre() { Id = 6, Name = "Genre 6"});
            context.Genres.AddOrUpdate(new Genre() { Id = 7, Name = "Genre 7"});
            context.Genres.AddOrUpdate(new Genre() { Id = 8, Name = "Genre 8"});
            context.Movies.AddOrUpdate(new Movie() { Name = "Random Movie"+" " + randomNumbers[9], StockAmount = RandomStockNumbers[0], ReleaseDate = new DateTime(1979, 12, 12), GenreId = Convert.ToByte(RandomGenreNumbers[0]) });
            context.Movies.AddOrUpdate(new Movie() { Name = "Random Movie"+" " + randomNumbers[10], StockAmount = RandomStockNumbers[1], ReleaseDate = new DateTime(1980, 1, 1), GenreId = Convert.ToByte(RandomGenreNumbers[1]) });
            context.Movies.AddOrUpdate(new Movie() { Name = "Random Movie"+" " + randomNumbers[11], StockAmount = RandomStockNumbers[2], ReleaseDate = new DateTime(1981, 2, 2), GenreId = Convert.ToByte(RandomGenreNumbers[2]) });
            context.Movies.AddOrUpdate(new Movie() { Name = "Random Movie" + " " + randomNumbers[12], StockAmount = RandomStockNumbers[3], ReleaseDate = new DateTime(1982, 3, 3), GenreId = Convert.ToByte(RandomGenreNumbers[3]) });

            context.SaveChanges();

        }
    }
}
