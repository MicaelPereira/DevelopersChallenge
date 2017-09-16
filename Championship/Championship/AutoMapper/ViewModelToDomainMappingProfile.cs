using AutoMapper;
using entity = Domain.Championship.Entities;
using viewModel = Championship.Models;

namespace Championship.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<entity.Base, viewModel.Base>();
            CreateMap<entity.League, viewModel.League>();
            CreateMap<entity.Team, viewModel.Team>();
            CreateMap<entity.Result, viewModel.Result>();
        }

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

    }
}