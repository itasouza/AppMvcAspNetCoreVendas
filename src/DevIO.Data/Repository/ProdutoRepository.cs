using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : RepositoryGenerico<Produto>, IProdutoRepository
    {

        public ProdutoRepository(MeuDbContext context) : base(context) { }



        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();

        }

        public async Task<IEnumerable<Produto>> BuscarProdutosFornecedores(Expression<Func<Produto, bool>> predicate = null)
        {
            var query = Db.Produtos.AsNoTracking().Include(f => f.Fornecedor).AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }


        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutosFornecedoresOrdenado(string Ordenacao)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                   .OrderBy(c => Ordenacao)
                   .ToListAsync();
        }




    }
}
