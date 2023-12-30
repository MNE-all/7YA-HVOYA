﻿using _7YA_HVOYA.Context.Contracts.Emuns;
using _7YA_HVOYA.Context.Contracts.Models;
using FluentAssertions.Execution;
using System.Diagnostics;

namespace _7YA_HVOYA.Services.Tests
{
    static internal class TestDataGenerator
    {
        static internal Storage Storage(Action<Storage>? settings = null)
        {
            var result = new Storage
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Address = $"Address{Guid.NewGuid():N}",
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = $"CreatedBy{Guid.NewGuid():N}",
                UpdatedAt = DateTimeOffset.UtcNow,
                UpdatedBy = $"UpdatedBy{Guid.NewGuid():N}",
            };

            settings?.Invoke(result);
            return result;
        }

        static internal Client Client(Action<Client>? settings = null)
        {
            var result = new Client
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Surname = $"Surname{Guid.NewGuid():N}",
                Patronymic = $"Patronymic{Guid.NewGuid():N}",
                Phone = $"Phone{Guid.NewGuid():N}",
                Email = $"Email{Guid.NewGuid():N}",
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = $"CreatedBy{Guid.NewGuid():N}",
                UpdatedAt = DateTimeOffset.UtcNow,
                UpdatedBy = $"UpdatedBy{Guid.NewGuid():N}",
                
            };

            settings?.Invoke(result);
            return result;
        }

        static internal Thing Thing(Action<Thing>? action = null)
        {
            Random rnd = new Random();

            var item = new Thing
            {
                Id = Guid.NewGuid(),
                Season = (Seasons)rnd.Next(4),
                Size = (Sizes)rnd.Next(6),
                Name = $"Name{Guid.NewGuid():N}",
                Price = rnd.Next(10000),
                ImgURL = $"ImgURL{Guid.NewGuid():N}",
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = $"CreatedBy{Guid.NewGuid():N}",
                UpdatedAt = DateTimeOffset.UtcNow,
                UpdatedBy = $"UpdatedBy{Guid.NewGuid():N}",
            };

            action?.Invoke(item);
            return item;
        }
        static internal Cart Cart(Client client, Action<Cart>? action = null)
        {
            var item = new Cart
            {
                Id = Guid.NewGuid(),
                Amount = new Random().Next(4),
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = $"CreatedBy{Guid.NewGuid():N}",
                UpdatedAt = DateTimeOffset.UtcNow,
                UpdatedBy = $"UpdatedBy{Guid.NewGuid():N}",
            };

            action?.Invoke(item);
            return item;
        }

        static internal Accommodation Accommodation(Action<Accommodation>? action = null)
        {
            var item = new Accommodation
            {
                Id = Guid.NewGuid(),
                Amount = new Random().Next(100),

                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = $"CreatedBy{Guid.NewGuid():N}",
                UpdatedAt = DateTimeOffset.UtcNow,
                UpdatedBy = $"UpdatedBy{Guid.NewGuid():N}",
            };

            action?.Invoke(item);
            return item;
        }

        static internal Order Order(Action<Order>? action = null)
        {
            var item = new Order
            {
                Id = Guid.NewGuid(),
                Number = new Random().Next(1024),

                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = $"CreatedBy{Guid.NewGuid():N}",
                UpdatedAt = DateTimeOffset.UtcNow,
                UpdatedBy = $"UpdatedBy{Guid.NewGuid():N}",
            };

            action?.Invoke(item);
            return item;
        }

    }
}
