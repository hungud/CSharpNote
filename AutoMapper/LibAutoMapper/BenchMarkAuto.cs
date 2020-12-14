using BenchmarkDotNet.Attributes;
using LibAutoMapper.Domain;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibAutoMapper
{
    public class BenchMarkAuto
    {
        public List<Foo> Foos { get; }
        public BenchMarkAuto(int numberObject = 100)
        {
            Foos = Foo.GenFoo.Generate(numberObject);
        }

        [Benchmark]
        public List<FooDto> RunAutomapper()
        {

            var configuration = new AutoMapper.MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Foo, FooDto>();

            });

            // only during development, validate your mappings; remove it before release
            configuration.AssertConfigurationIsValid();

            var mapper = configuration.CreateMapper();

            var fooDtos = new List<FooDto>();


            Foos.ForEach(foo =>
            {
                fooDtos.Add(mapper.Map<FooDto>(foo));
            });

            return fooDtos;
        }

        [Benchmark]
        public List<FooDto> RunMapsterMapper()
        {
            var fooDtos = new List<FooDto>();
            Foos.ForEach(foo =>
            {
                fooDtos.Add(foo.Adapt<FooDto>());
            });

            return fooDtos;
        }

        [Benchmark]
        public List<FooDto> RunJsonMapper()
        {
            var fooDtos = new List<FooDto>();
            Foos.ForEach(foo =>
            {
                fooDtos.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<FooDto>(Newtonsoft.Json.JsonConvert.SerializeObject(foo)));
            });

            return fooDtos;
        }
    }
}
