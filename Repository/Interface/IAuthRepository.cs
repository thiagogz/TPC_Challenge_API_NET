using TPC_Challenge_API_NET.DTOs;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<string> RegisterUserAsync(RegisterDTO registerDto); // Retorna o UID do novo usuário
        Task<string> LoginUserAsync(LoginDTO loginDto); // Retorna o token JWT
    }
}
