namespace ManagementService.Services.Mapper
{
    using AutoMapper;

    using ManagementService.Data.Models;
    using ManagementService.DTOs.Category;
    using ManagementService.DTOs.Item;

    public class MapperManager
    {
        private MapperConfiguration mapperConfig;

        public MapperManager()
        {
            this.SetMapConfigs();
        }

        public IMapper GetMapper()
        {
            return this.mapperConfig.CreateMapper();
        }

        private void SetMapConfigs()
        {
            this.mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, AddCategoryInputModel>();
                cfg.CreateMap<Item, AddItemInputModel>();
            });
        }
    }
}
