using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Application.Commands
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse { Success = true };
        public static CommandResponse Fail = new CommandResponse { Success = false };

        public CommandResponse(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}
