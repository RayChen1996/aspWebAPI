namespace sideprjWebApi
{
    public class JwtService
    {
        private readonly string key;
        public JwtService(string key)
        {
            this.key = key;
        }
        public string GenerateToken(string username)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var tokenKey = System.Text.Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new System.IdentityModel.Tokens.Jwt.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(tokenKey),
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
