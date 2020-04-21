using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IClienteRepository : IRepositoryGenerico<Cliente>
    {
        Task<Cliente> ObterClienteEndereco(Guid id);
        Task<IEnumerable<Cliente>> ObterTodosClienteEnderecoOrdenado(string Ordenacao);
    }
}
