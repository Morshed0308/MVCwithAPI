using AutoMapper;
using MVCwithApiapp.Data.Entities;
using MVCwithApiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCwithApiapp.Data
{
    public class ApiModelMappingProfile : Profile
    {
        public ApiModelMappingProfile()
        {
            CreateMap<Report, ReportModel>()
                .ForMember(R => R.Name, Ex => Ex.MapFrom(X => X.user.Name))
                .ForMember(R => R.Email, Ex => Ex.MapFrom(X => X.user.Email))
                .ReverseMap();
                

        }
        
    }
}
