namespace Infrastructure.Mapping
{
    public class Mapper : IMapper
    {
        private AutoMapper.IMapper _mapper;

        public Mapper(AutoMapper.IMapper mapper)
        {
            this._mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return this._mapper.Map<TDestination>(source);
        }
    }
}
