namespace Infrastructure.Mapping
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
