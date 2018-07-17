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

        protected override void Seed(VideoStore.Models.ApplicationDbContext context)
        {
            //How to seed a table. Membership types seeind done through a migration. Its under "SeedingMembership"
            context.Customers.AddOrUpdate(new Customer() { Name = "Can One", IsSubscribeToNewsLetter = false, MembershipTypeId = 1, BirthDate = new DateTime(1979, 12, 12) });
            context.Customers.AddOrUpdate(new Customer() { Name = "Can Two", IsSubscribeToNewsLetter = false, MembershipTypeId = 1, BirthDate = new DateTime(1980, 1, 1) });
            context.Customers.AddOrUpdate(new Customer() { Name = "Can Three", IsSubscribeToNewsLetter = true, MembershipTypeId = 2, BirthDate = new DateTime(1981, 2, 2) });
            context.Customers.AddOrUpdate(new Customer() { Name = "Can Four", IsSubscribeToNewsLetter = true, MembershipTypeId = 3, BirthDate = new DateTime(1982, 3, 3) });
            context.Genres.AddOrUpdate(new Genre() { Id = 1, Name = "Genre 1" });
            context.Genres.AddOrUpdate(new Genre() { Id = 2, Name = "Genre 2" });
            context.Genres.AddOrUpdate(new Genre() { Id = 3, Name = "Genre 3" });
            context.Genres.AddOrUpdate(new Genre() { Id = 4, Name = "Genre 4" });
            context.Movies.AddOrUpdate(new Movie() { Name = "Random Movie 1", StockAmount = 1, ReleaseDate = new DateTime(1979, 12, 12), GenreId = 1 });
            context.Movies.AddOrUpdate(new Movie() { Name = "Random Movie 2", StockAmount = 2, ReleaseDate = new DateTime(1980, 1, 1), GenreId = 2 });
            context.Movies.AddOrUpdate(new Movie() { Name = "Random Movie 3", StockAmount = 3, ReleaseDate = new DateTime(1981, 2, 2), GenreId = 3 });
            context.Movies.AddOrUpdate(new Movie() { Name = "Random Movie 4", StockAmount = 4, ReleaseDate = new DateTime(1982, 3, 3), GenreId = 4 });

            context.SaveChanges();

        }
    }
}
