using Lojinha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Data
{
    public class DbInitializer
    {
        public static void Initialize(LojinhaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Usuarios.Any())
            {
                return;   
            }

            var usuario = new Usuario[]
            {
                new Usuario{Nome="Fabio Flauzino",Cpf="123456",Email="fabioteste@teste.com"},
                new Usuario{Nome="Otoniel",Cpf="654321",Email="tototeste@teste.com"},
                new Usuario{Nome="Napoleão",Cpf="012345",Email="napo@teste.com"},
                
            };
            foreach (Usuario u in usuario)
            {
                context.Usuarios.Add(u);
            }
            context.SaveChanges();

            var produto = new Produto[]
            {
                new Produto{Nome="Tenis Esportivos",PrecoUnitario=200},
                new Produto{Nome="Camisas de Times",PrecoUnitario=250},
                new Produto{Nome="Bolas Nike",PrecoUnitario=120},
            };
            foreach (Produto p in produto)
            {
                context.Produtos.Add(p);
            }
            context.SaveChanges();

            var pedido = new Pedido[]
            {
                new Pedido{UsuarioId=1,QtdeItens =1,ValorTotal=100 ,Data=DateTime.Parse("2003-09-01")},
                new Pedido{UsuarioId=2,QtdeItens =1,ValorTotal=200,Data=DateTime.Parse("2005-12-14")},
                new Pedido{UsuarioId=3,QtdeItens =1,ValorTotal=150,Data=DateTime.Parse("2007-01-1")},
            };
            foreach (Pedido p in pedido)
            {
                context.Pedidos.Add(p);
            }
            context.SaveChanges();

            var itens = new Itens[]
            {
                
                new Itens{PedidoId=1,ProdutoId=2},
                new Itens{PedidoId=2,ProdutoId=2},
                new Itens{PedidoId=3,ProdutoId=2},
            };
            foreach (Itens i in itens)
            {
                context.Itens.Add(i);
            }
            context.SaveChanges();


        }
    }
}
