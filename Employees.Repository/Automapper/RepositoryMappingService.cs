using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EMPLOYEES.DATA.DataModel;
using EMPLOYEES.Model;

namespace Employees.Repository
{
    public class RepositoryMappingService : IRepositoryMappingService
    {
        public Mapper mapper;

        public RepositoryMappingService()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<EmployeesKveletic, EmployeesDomain>();
                    cfg.CreateMap<EmployeesDomain, EmployeesDomain>();
                });

            mapper = new Mapper(config);
                
        }
        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
