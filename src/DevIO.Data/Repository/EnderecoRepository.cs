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
    public class EnderecoRepository : RepositoryGenerico<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId, Guid enderecoId)
        {
            return await Db.Cliente.AsNoTracking()
               .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId && f.Id == enderecoId);
        }

        public async Task<Endereco> ObterEnderecoPorID(Guid enderecoId)
        {
            return await Db.Cliente.AsNoTracking()
               .FirstOrDefaultAsync(f => f.Id == enderecoId);
        }


    }
}