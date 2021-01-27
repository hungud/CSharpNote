using AutoMapper;
using LibAutoMapper.Domain;
using Mapster;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibAutoMapper
{
    public class BenchMarkJsonSerializeDeserializeManual
    {
        public int NumberObject { get; }
        public List<Foo> Foos { get; }
        public List<dynamic> DynFoos { get; private set; }

        public BenchMarkJsonSerializeDeserializeManual(int numberObject = 3)
        {
            NumberObject = numberObject;
            Foos = Foo.GenFoo.Generate(NumberObject);
            SerializeDeserialize();
        }

        private void SerializeDeserialize()
        {
            using (var bench = new Benchmark($"DynJsons {NumberObject} object:"))
            {
                var jsonFoos = Newtonsoft.Json.JsonConvert.SerializeObject(Foos);
                DynFoos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(jsonFoos);
            }
        }

        public void RunWaitAll()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(RunAutomapper());
            tasks.Add(RunMapsterMapper());
            tasks.Add(RunMapsterMapperStyleList());
            tasks.Add(RunSerializeDeserialize());
            Task.WaitAll(tasks.ToArray());
        }

        public async Task<List<FooDto>> RunAutomapper()
        {

            return await Task.Run(() =>
            {


                using (var bench = new Benchmark($"AutoMapper {NumberObject} object:"))
                {

                    var configuration = new AutoMapper.MapperConfiguration(cfg =>
                    {

                        cfg.CreateMap<JObject, FooDto>();

                    });

                    // only during development, validate your mappings; remove it before release
                    // configuration.AssertConfigurationIsValid();

                    var mapper = configuration.CreateMapper();

                    var fooDtos = new List<FooDto>();

                    DynFoos.ForEach(foo =>
                    {
                        fooDtos.Add(mapper.Map<FooDto>(foo as JObject));
                    });

                    return fooDtos;
                }

            });
        }

        public async Task<List<FooDto>> RunMapsterMapper()
        {
            TypeAdapterConfig.GlobalSettings.EnableJsonMapping();

            return await Task.Run(() =>
            {


                using (var bench = new Benchmark($"MapsterMapper {NumberObject} object:"))
                {

                    var fooDtos = new List<FooDto>();

                    DynFoos.ForEach(foo =>
                    {
                        fooDtos.Add((foo as JObject).Adapt<FooDto>());
                    });

                    return fooDtos;

                }

            });
        }

        public async Task<List<FooDto>> RunMapsterMapperStyleList()
        {
            TypeAdapterConfig.GlobalSettings.EnableJsonMapping();

            return await Task.Run(() =>
            {
                using (var bench = new Benchmark($"MapsterMapper {NumberObject} object:"))
                {

                    var fooDtos = new List<FooDto>();

                    fooDtos = new MapsterMapper.Mapper().Map<List<FooDto>>(DynFoos);

                    return fooDtos;
                }

            });
        }

        public async Task<List<FooDto>> RunSerializeDeserialize()
        {
            TypeAdapterConfig.GlobalSettings.EnableJsonMapping();

            return await Task.Run(() =>
            {


                using (var bench = new Benchmark($"SerializeDeserialize {NumberObject} object:"))
                {

                    var fooDtos = new List<FooDto>();

                    DynFoos.ForEach(foo =>
                    {
                        fooDtos.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<FooDto>(Newtonsoft.Json.JsonConvert.SerializeObject(foo)));
                    });

                    return fooDtos;

                }

            });
        }
    }
}
