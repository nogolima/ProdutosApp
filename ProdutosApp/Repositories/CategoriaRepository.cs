using Microsoft.EntityFrameworkCore;
using ProdutosApp.Contexts;
using ProdutosApp.Dtos;
using ProdutosApp.Entities;

namespace ProdutosApp.Repositories
{
    /// <summary>
    /// Classe de repositório de dados para categoria
    /// </summary>
    public class CategoriaRepository
    {
        //Método para consultar todas as categorias do banco de dados
        public List<Categoria> Consultar()
        {
            //abrindo conexão com o banco de dados através do EntityFramework
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Categoria>() //consultando dados da tabela de categoria
                        .OrderBy(p => p.Nome) //ordem alfabética de nome
                        .ToList(); //retornando uma listagem com todas as categorias
            }
        }
        //Método para retorno e somatório da quantidade de produtos 
        //por cada categoria, usando uma função GROUP BY do banco de dados 
        public List<CategoriaQtdProdutoResponseDto> GroupByQtdProdutos()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                .Set<Produto>() //Consultando a Entidade Produto
                .Include(p => p.Categoria) // Junção (JOIN) com entidade categoria 
                .GroupBy(c => c.Categoria.Nome) //agrupando pelo nome da categoria
                .Select(g => new CategoriaQtdProdutoResponseDto
                {
                    Categoria = g.Key, // chave do agrupament (nome da categoria)
                    QtdProdutos = g.Sum(p => p.Quantidade)

                })
                .OrderByDescending(dto => dto.QtdProdutos)
                .ToList();

            }
        }

        //Método para retorno e somatório da quantidade de produtos 
        //por cada categoria, usando uma função GROUP BY do banco de dados 
        public List<CategoriaMediaPrecoResponseDto> GroupByMediaPreco()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                .Set<Produto>() //Consultando a Entidade Produto
                .Include(p => p.Categoria) // Junção (JOIN) com entidade categoria 
                .GroupBy(c => c.Categoria.Nome) //agrupando pelo nome da categoria
                .Select(g => new CategoriaMediaPrecoResponseDto
                {
                    Categoria = g.Key, // chave do agrupament (nome da categoria)
                    MediaPreco = g.Average(p => p.Preco)

                })
                .OrderByDescending(dto => dto.MediaPreco) //ordem decrescente
                .ToList();//retornando a lista de resultados 

            }
        }
    }
}
