using System;
using System.Collections.Generic;

namespace Lojinha.Models
{
    public class Itens
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
