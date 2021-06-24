using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDto, Supplier>();
            this.CreateMap<CarDto, Car>();
            this.CreateMap<CustomerDto, Customer>();
            this.CreateMap<PartsDto, Part>();
            this.CreateMap<SaleDto, Sale>();
        }
    }
}
