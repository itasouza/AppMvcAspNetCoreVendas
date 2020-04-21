using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Repository
{
    public class CabPedidoRepository : RepositoryGenerico<CabPedido>, ICabPedidoRepository
    {
        public CabPedidoRepository(MeuDbContext context) : base(context) { }
    }
}
