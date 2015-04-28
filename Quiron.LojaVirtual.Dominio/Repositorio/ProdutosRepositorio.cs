using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();


        //É a clase onde faz todas as operações

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        //Salvar produto - Alterar produto
        public void Salvar(Produto produto)
        {
            if (produto.ProdutoId == 0)
            {
                //Salvando
                _context.Produtos.Add(produto);
            }
            else
            {
                //Alteração
                Produto prod = _context.Produtos.Find(produto.ProdutoId);
                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Categoria = produto.Categoria;
                    prod.Preco = produto.Preco;
                }
            }
            _context.SaveChanges();
        }

        //Excluir
        public Produto Excluir(int produtoId)
        {
            Produto prod = _context.Produtos.Find(produtoId);

            if (prod != null)
            {
                _context.Produtos.Remove(prod);
                _context.SaveChanges();
            }
            return prod;
        }
    }
}
