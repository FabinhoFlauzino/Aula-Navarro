using System;
using System.Collections.Generic;

namespace Lojinha.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int QtdeItens { get; set; }
        public decimal ValorTotal { get; set; }

        public ICollection<Itens> PedidosItens { get; set; }
    }
}
