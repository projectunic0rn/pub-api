using System;
using AutoMapper;

namespace CommunicationAppDomain.MappingConfig
{
    public class InitializeMapper
    {
        public IMapper GetMapper { get; private set; }

        public InitializeMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            GetMapper = mapper;
        }
    }
}
