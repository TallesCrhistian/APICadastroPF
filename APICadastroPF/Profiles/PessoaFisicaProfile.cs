using APICadastroPF.Data.Dtos;
using APICadastroPF.Models;
using AutoMapper;

namespace APICadastroPF.Profiles
{
    public class PessoaFisicaProfile : Profile
    {
        public PessoaFisicaProfile()
        {
            CreateMap<CreatePessoaDto, PessoaFisica>();
            CreateMap<PessoaFisica, ReadPessoaDto>();
            CreateMap<UpdatePessoaDto, PessoaFisica>();
        }
    }
}
