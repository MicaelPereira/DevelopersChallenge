using AutoMapper;
using entity = Domain.Championship.Entities;
using viewModel = Championship.Models;


namespace Championship.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<viewModel.Base, entity.Base>();
            CreateMap<viewModel.League, entity.League>();
            CreateMap<viewModel.Team, entity.Team>();
            CreateMap<viewModel.Result, entity.Result>();
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }        
    }
}