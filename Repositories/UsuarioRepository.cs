using Chapter.WebApi.Contexts;
using Chapter.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Chapter.WebApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ChapterContext _context;
        public UsuarioRepository(ChapterContext context)
        {
            _context = context;
        }
        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }
        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
        public Usuario BuscarporId(int id)
        {
            return _context.Usuarios.Find(id);

        }
        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);
            if(usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email; 
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Tipo = usuario.Tipo;
            }
            _context.Usuarios.Update(usuarioEncontrado);
            _context.SaveChanges();
        }
        public void Deletar(int id)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);
            if (usuarioEncontrado != null)
            {
                _context.Usuarios.Remove(usuarioEncontrado);
            };
            _context.SaveChanges();
        }
        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

        }
    }
}
