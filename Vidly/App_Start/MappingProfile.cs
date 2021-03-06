using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Genre, GenreDto>();

            // Dto to Domain
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            /*CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(m => m.Id, opt => opt.Ignore());*/
        }
    }
}