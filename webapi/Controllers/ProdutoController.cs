using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi.Data.Dtos;
using webapi.Model;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;

    public ProdutoController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um produto ao banco de dados
    /// </summary>
    /// <param name="produtoDto">Objeto com os campos necessários para criação de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaProduto([FromBody] CreateProdutoDto produtoDto)
    {
        Produto produto = _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProdutoPorId), new { id = produto.Id }, produto);
    }

    /// <summary>
    /// Busca todos os produtos
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso a busca tenha sucesso</response>
    [HttpGet]
    public IEnumerable<ReadProdutoDto> RecuperaProdutos
        ([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadProdutoDto>>(_context.Produtos.Skip(skip).Take(take)).ToList();
    }

    /// <summary>
    /// Busca produto por ID
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca tenha sucesso</response>
    [HttpGet("{id}")]
    public IActionResult RecuperaProdutoPorId(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
        return Ok(produtoDto);
    }

    /// <summary>
    /// Atualiza dados de um produto
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização tenha sido feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizaProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        _mapper.Map(produtoDto, produto);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta produto
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="202">Caso a deleção tenha sido feita com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeletaProduto(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();

        _context.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }
}