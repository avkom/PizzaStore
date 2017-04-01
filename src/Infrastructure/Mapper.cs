namespace Infrastructure
{
    public class Mapper : IMapper
    {
        AutoMapper.IMapper _mapper;

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
