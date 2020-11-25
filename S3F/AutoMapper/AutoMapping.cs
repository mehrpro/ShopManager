using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SPS.Entities;
using SPS.ViewModels.Shop;

namespace SPS.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            CreateMap<UnitViewModel, Unit>();
            CreateMap<Unit, UnitViewModel>();

            CreateMap<SellerViewModel, Seller>();
            CreateMap<Seller, SellerViewModel>();
        }
    }
}
