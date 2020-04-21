using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : RepositoryGenerico<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }


        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                   .Include(c => c.Produtos)
                   .Include(c => c.Enderecos)
                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Fornecedor>> ObterFornecedorParaAutocompleteTexto(string text)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Where(x => x.Nome.Contains(text))
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }


        public async Task<IEnumerable<Fornecedor>> ObterTodosFornecedorProdutosEnderecoOrdenado(string Ordenacao)
        {
            return await Db.Fornecedores.AsNoTracking()
                   .Include(c => c.Produtos)
                   .Include(c => c.Enderecos)
                   .OrderBy(c => Ordenacao)
                   .ToListAsync();
        }



        public async Task<Fornecedor> ObterFornecedorParaAutocompleteId(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedor(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }


    }
}
