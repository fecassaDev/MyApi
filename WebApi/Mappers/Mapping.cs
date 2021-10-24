using Domain.Security;
using WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Mappers
{
    public class Mapping: AutoMapper.Profile
    {
        public Mapping()
        {
            CreateMap<Login, CreateSessionPostResponseModel>();
            CreateMap<CreateSessionPostRequestModel, Login>();
        }
    }
}
