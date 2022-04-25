using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TesteWGlobal.Application.Dtos;
using TesteWGlobal.Domain.Models;

namespace TesteWGlobal.Application.Helpers
{
    public class TesteWGlobalProfile : Profile
    {
        public TesteWGlobalProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
