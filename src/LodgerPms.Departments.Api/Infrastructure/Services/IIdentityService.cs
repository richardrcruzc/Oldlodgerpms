﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Infrastructure.Services
{
    public interface IIdentityService
    {
        string GetUserIdentity();
    }
}
