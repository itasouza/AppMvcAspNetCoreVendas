using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProdutoRepository : IRepositoryGenerico<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();

        Task<IEnumerable<Produto>> BuscarProdutosFornecedores(Expression<Func<Produto, bool>> predicate = null);

        Task<Produto> ObterProdutoFornecedor(Guid id);

        Task<IEnumerable<Produto>> ObterTodosProdutosFornecedoresOrdenado(string Ordenacao);
    }
}
