﻿namespace Infrastructure
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
