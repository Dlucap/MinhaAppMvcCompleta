using DevIO.Business.Models;
using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
  public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
  {
    public FornecedorRepository(MeuDbContext context) : base(context) { }

    public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
    {
      return await Db.Fornecedores.AsNoTracking()
                              .Include(e => e.Endereco)
                              .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
    {
      return await Db.Fornecedores.AsNoTracking()
                             .Include(c => c.Produtos)
                             .Include(c => c.Endereco)
                               .FirstOrDefaultAsync(f => f.Id == id);
    }
  }
}
