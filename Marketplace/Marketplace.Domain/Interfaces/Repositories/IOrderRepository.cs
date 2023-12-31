﻿using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task CommitAsync();
        Task ProcessNewOrderAsync(OrderEntity newOrder);
    }
}
