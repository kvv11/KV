using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration.Conventions;

namespace Employees.Repository
{
    public interface IRepositoryMappingService
    {
        TDestination Map<TDestination>(object source);
    }
}
