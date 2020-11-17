using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroupManagement.Contracts
{
    public interface IActionResultService
    {
        ObjectResult InternalError(string message);
        ObjectResult InternalError(Exception e);
    }
}
