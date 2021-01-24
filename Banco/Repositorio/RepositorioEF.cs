using Banco.Content;
using Banco.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Repositorio
{
    public class RepositorioEF<TEntidade> : IRepositorio<TEntidade> where TEntidade : class
    {
        private readonly FilmeDBContext _context;

        public RepositorioEF(FilmeDBContext context)
        {
            _context = context;
        }

        public void Atualizar(TEntidade entidade)
        {
            _context.Set<TEntidade>().Update(entidade);
            _context.SaveChanges();
        }

        public void Deletar(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
            _context.SaveChanges();
        }

        public void Incluir(TEntidade entidade)
        {
            _context.Set<TEntidade>().Add(entidade);
            _context.SaveChanges();
        }

        public IList<TEntidade> ListarTodos() => _context.Set<TEntidade>().ToList();

        public TEntidade ObterPorId(int id)
        {
            return _context.Set<TEntidade>().Find(id);
        }
    }
}
