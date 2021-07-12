using System.Collections.Generic;

namespace DevIO.Business.Models
{
  public class Fornecedor : Entity
  {
    public string Nome { get; set; }

    public string Documento { get; set; }

    public TipoFornecedorEnum TipoFornecedor { get; set; }

    public Endereco Endereco { get; set; }
    
    public bool Ativo { get; set; }

    /* Ef relations*/
    public IEnumerable<Produto> Produtos { get; set; }

  }
}
