using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcBasica.Models
{
  public class Produto : Entity
  {
    public Guid FornecedorID { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    public string Imagem { get; set; }

    public decimal Valor { get; set; }

    public DateTime DataCadastro { get; set; }

    public bool Ativo { get; set; }

    /*EF Relations*/
    public Fornecedor Fornecedor { get; set; }

  }
}
