using LibAutoMapper.Domain;
using Mapster;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibAutoMapper
{
    public class BenchMarkMapObjectToDictionary
    {
        public int NumberObject { get; }
        public List<Foo> Foos { get; }

        public BenchMarkMapObjectToDictionary(int numberObject = 3)
        {
            NumberObject = numberObject;
            Foos = Foo.GenFoo.Generate(NumberObject);
        }

        public void RunWaitAll()
        {
            List<Task> tasks = new List<Task>();            
            tasks.Add(RunMapsterMapper());
            Task.WaitAll(tasks.ToArray());
        }

        public async Task<Dictionary<string, object>> RunMapsterMapper()
        {
            return await Task.Run(() =>
            {


                using (var bench = new Benchmark($"MapsterMapper {NumberObject} object:"))
                {

                    var fooDtos = new List<KeyValuePair<string, object>>();

                    Foos.ForEach(foo =>
                    {
                        fooDtos.Add(foo.Adapt<KeyValuePair<string, object>>());
                    });

                    return fooDtos.ToDictionary(x => x.Key, x => x.Value);

                }

            });
        }

    }
}
