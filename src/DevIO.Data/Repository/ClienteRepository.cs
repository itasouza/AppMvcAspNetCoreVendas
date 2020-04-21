using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ClienteRepository : RepositoryGenerico<Cliente>, IClienteRepository
    {
        public ClienteRepository(MeuDbContext context) : base(context) { }

        public async Task<Cliente> ObterClienteEndereco(Guid id)
        {
            return await Db.Clientes.AsNoTracking()
                   .Include(c => c.Enderecos)
                   .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<IEnumerable<Cliente>> ObterTodosClienteEnderecoOrdenado(string Ordenacao)
        {
            return await Db.Clientes.AsNoTracking()
                   .Include(c => c.Enderecos)
                   .OrderBy(c => Ordenacao)
                   .ToListAsync();
        }

    }
}
