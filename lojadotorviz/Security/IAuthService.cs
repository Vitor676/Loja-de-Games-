using lojadotorviz.Model;

namespace lojadotorviz.Security
{
    public interface IAuthService
    {
        Task<UserLogin?> Autenticar(UserLogin userLogin);
    }
}
