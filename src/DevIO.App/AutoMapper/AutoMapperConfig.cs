using DevIO.Business.Models;
using AutoMapper;
using DevIO.App.ViewModels;

namespace DevIO.App.AutoMapper
{
  public class AutoMapperConfig : Profile
  {
    public AutoMapperConfig()
    {
      //ReserveMap serve para mapear tando de Fornecedor para FornecedorViewModel quanto o contrário;
      CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
      CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
      CreateMap<Produto, ProdutoViewModel>().ReverseMap();
    }
  }
}
