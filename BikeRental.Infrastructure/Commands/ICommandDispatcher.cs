﻿using System.Threading.Tasks;

namespace BikeRental.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}