using System.Collections.Generic;

namespace Banco.Interface
{
    public interface IRepositorio<TEntidade> where TEntidade : class
    {
        void Atualizar(TEntidade entidade);

        void Deletar(TEntidade entidade);

        void Incluir(TEntidade entidade);

        IList<TEntidade> ListarTodos();

        TEntidade ObterPorId(int id);
    }
}
