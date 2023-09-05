using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encrypting;

public static class SigninCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}
