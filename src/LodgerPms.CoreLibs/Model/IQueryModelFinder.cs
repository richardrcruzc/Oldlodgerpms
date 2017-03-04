﻿using System;

namespace LodgerPms.CoreLibs.Model
{
    public interface IQueryModelFinder<out TDto> where TDto : DtoBase
    {
        IObservable<TDto> FindItemStream(Guid id);
        IObservable<TDto> QueryItemStream();
    }
}