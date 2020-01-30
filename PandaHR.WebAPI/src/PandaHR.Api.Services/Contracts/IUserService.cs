﻿using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IUserService : IAsyncService<User>
    {
        Task<UserServiceModel> GetUserInfo(Guid id);
    }
}
