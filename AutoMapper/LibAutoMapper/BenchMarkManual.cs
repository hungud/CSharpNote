using LibAutoMapper.Domain;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibAutoMapper
{
    public class BenchMarkManual
    {
        public int NumberObject { get; }
        public List<Foo> Foos { get; }

        public BenchMarkManual(int numberObject = 3)
        {
            NumberObject = numberObject;
            Foos = Foo.GenFoo.Generate(NumberObject);
        }

        public void RunWaitAll()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(RunAutomapper());
            tasks.Add(RunMapsterMapper());
            Task.WaitAll(tasks.ToArray());
        }

        public async Task<List<FooDto>> RunAutomapper()
        {
            return await Task.Run(()=> {


                using (var bench = new Benchmark($"AutoMapper {NumberObject} object:"))
                {

                    var configuration = new AutoMapper.MapperConfiguration(cfg =>
                    {

                        cfg.CreateMap<Foo, FooDto>();

                    });

                    // only during development, validate your mappings; remove it before release
                    // configuration.AssertConfigurationIsValid();

                    var mapper = configuration.CreateMapper();

                    var fooDtos = new List<FooDto>();

                    Foos.ForEach(foo =>
                    {
                        fooDtos.Add(mapper.Map<FooDto>(foo));
                    });

                    return fooDtos;
                }

            });
        }

        public async Task<List<FooDto>> RunMapsterMapper()
        {
            return await Task.Run(() => {


                using (var bench = new Benchmark($"MapsterMapper {NumberObject} object:"))
                {
                 
                    var fooDtos = new List<FooDto>();

                    Foos.ForEach(foo =>
                    {
                        fooDtos.Add(foo.Adapt<FooDto>());
                    });

                    return fooDtos;

                }

            });
        }
    }
}
