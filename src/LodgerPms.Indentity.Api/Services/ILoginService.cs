﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Indentity.Api.Services
{
    public interface ILoginService<T>
    {
        Task<bool> ValidateCredentials(T user, string password);
        Task<T> FindByUsername(string user);
        Task SignIn(T user);
    }
}
