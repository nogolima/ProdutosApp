namespace ProdutosApp.Dtos
{/// <summary>
/// Modelo de dados da consulta de somatório 
/// da quantidade de produtos por categoria
/// </summary>
    public class CategoriaQtdProdutoResponseDto
    {
        public string? Categoria { get; set; }
        public int QtdProdutos { get; set; }
        public int MediaPreco { get; internal set; }
    }
}
