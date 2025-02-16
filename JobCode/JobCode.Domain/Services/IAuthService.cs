using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCode.Core.Services
{
    public interface IAuthService
    {
        string GenerateToken(string email, string role);
    }
}
