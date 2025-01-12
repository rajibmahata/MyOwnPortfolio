using AutoMapper;
using MyOwnPortfolio.ApiService.Entities;
using MyOwnPortfolio.ApiService.Models;

namespace MyOwnPortfolio.ApiService.Utility
{
    /// <summary>
    /// Configuration class for AutoMapper.
    /// </summary>
    public class MapperConfig : Profile
    {
        /// <summary>
        /// Initializes the AutoMapper configuration.
        /// </summary>
        /// <returns>An instance of the AutoMapper.</returns>
        public static IMapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AboutMeUIModel, AboutMe>()
                   .ForMember(dest => dest.ID, opt => opt.Ignore()); // Add necessary mappings

                cfg.CreateMap<AboutMe, AboutMeUIModel>();
                   
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
