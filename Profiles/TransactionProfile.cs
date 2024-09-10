using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMANAGEMENT.Data.Dtos;
using AutoMapper;
using Management.Models;

namespace APIMANAGEMENT.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<CreateTransactionDto, ModelTransaction>();
            CreateMap<ModelTransaction, GetTransactionDto>();
            CreateMap<UpdateTransactionDto, ModelTransaction>();
        }
        
    }
}