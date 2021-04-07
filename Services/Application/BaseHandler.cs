using AutoMapper;
using Core.Utilities;
using Microsoft.Extensions.Configuration;
using System;

namespace Services.Application
{
    public class BaseHandler
    {
        protected IConfiguration _appConfig { get; }
        protected IMapper _mapper { get; }
        public BaseHandler(IServiceInjector serviceInjector)
        {
            if (serviceInjector.Configuration.IsNull())
                throw new ArgumentException("configuration not be null");

            if (serviceInjector.Mapper.IsNull())
                throw new ArgumentException("mapper not be null");

            _appConfig = serviceInjector.Configuration;
            _mapper = serviceInjector.Mapper;
        }
    }
}
