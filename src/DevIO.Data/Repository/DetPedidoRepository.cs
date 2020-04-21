using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;

namespace DevIO.Data.Repository
{
    public class DetPedidoRepository : RepositoryGenerico<DetPedido>, IDetPedidoRepository
    {
        public DetPedidoRepository(MeuDbContext context) : base(context) { }
    }
}