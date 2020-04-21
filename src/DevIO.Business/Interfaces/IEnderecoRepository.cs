using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IEnderecoRepository : IRepositoryGenerico<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId, Guid enderecoId);
        Task<Endereco> ObterEnderecoPorID(Guid enderecoId);

        

    }
}
