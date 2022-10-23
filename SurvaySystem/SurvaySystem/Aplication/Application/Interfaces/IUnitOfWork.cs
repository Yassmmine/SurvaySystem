﻿using System.Threading.Tasks;

namespace SurvaySystem.ApplicationProject.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        void RollBack();
    }
}
