﻿using core.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Infrastructure
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDBContext>>()))
            {
                // Look for any board games.
                if (context.BoardGames.Any())
                {
                    return;   // Data was already seeded
                }

                context.BoardGames.AddRange(
                    new BoardGame
                    {
                        ID = 1,
                        Title = "Candy Land",
                        PublishingCompany = "Hasbro",
                        MinPlayers = 2,
                        MaxPlayers = 4
                    },
                    new BoardGame
                    {
                        ID = 2,
                        Title = "Sorry!",
                        PublishingCompany = "Hasbro",
                        MinPlayers = 2,
                        MaxPlayers = 4
                    },
                    new BoardGame
                    {
                        ID = 3,
                        Title = "Ticket to Ride",
                        PublishingCompany = "Days of Wonder",
                        MinPlayers = 2,
                        MaxPlayers = 5
                    },
                    new BoardGame
                    {
                        ID = 4,
                        Title = "The Settlers of Catan (Expanded)",
                        PublishingCompany = "Catan Studio",
                        MinPlayers = 2,
                        MaxPlayers = 6
                    },
                    new BoardGame
                    {
                        ID = 5,
                        Title = "Carcasonne",
                        PublishingCompany = "Z-Man Games",
                        MinPlayers = 2,
                        MaxPlayers = 5
                    },
                    new BoardGame
                    {
                        ID = 6,
                        Title = "Sequence",
                        PublishingCompany = "Jax Games",
                        MinPlayers = 2,
                        MaxPlayers = 6
                    });

                context.SaveChanges();
            }
        }
    }
}
