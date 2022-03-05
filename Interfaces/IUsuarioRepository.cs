using Chapter.WebApi.Models;

namespace Chapter.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}
