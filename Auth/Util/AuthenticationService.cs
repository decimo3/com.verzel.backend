using Teste.Domain;
using Teste.Servicies.Interfaces;

namespace Teste.Auth.Util
{
    public class AuthenticationService
    {
        private readonly JwtAuthenticationService _jwtAuthenticationService;
        private readonly IUserService _userService;

        public AuthenticationService(JwtAuthenticationService jwtAuthenticationService, IUserService userService)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
            _userService = userService;
        }

        public async Task<AuthResponse> AuthenticateUser(string username, string password)
        {
            // Lógica para autenticar o usuário e verificar suas credenciais
            // Aqui você pode implementar a verificação de nome de usuário e senha em seu banco de dados ou onde quer que você armazene as credenciais

            // Exemplo simples: se o usuário e a senha forem válidos, geramos um token JWT
            var user = await IsValidUser(username, password);
            if (user != null)
            {
                var role = user.Role; // Papéis atribuídos ao usuário autenticado
                var token = _jwtAuthenticationService.GenerateJwtToken(username, role);
                var response = new AuthResponse(user.Name, token, role);
                return response;
            }

            return null; // Retorna null se as credenciais forem inválidas
        }

        private async Task<User> IsValidUser(string username, string password)
        {
            // Implemente sua lógica de validação de usuário aqui
            // Por exemplo, você pode verificar no banco de dados se o usuário e a senha são válidos
            // Retorna true se as credenciais forem válidas; caso contrário, retorna false.
            var result = await _userService.GetByName(username);
            if (result != null && result.Password == password)
            {
                return result;
            }
            return null;
        }
    }
}
