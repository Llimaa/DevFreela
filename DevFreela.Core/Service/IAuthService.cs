using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Core.Service
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, List<UserRole> roles);
        string ComputeSha256Hash(string password);
    }
}
