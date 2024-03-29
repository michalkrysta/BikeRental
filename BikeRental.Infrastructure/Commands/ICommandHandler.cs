﻿using System.Threading.Tasks;

namespace BikeRental.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}