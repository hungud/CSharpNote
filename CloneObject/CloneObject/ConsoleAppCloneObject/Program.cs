using ConsoleAppCloneObject.Domain;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ConsoleAppCloneObject
{
    class Program
    {
        public static T CloneJson<T>(T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }


        /// <summary>
        /// ket luan dung CloneJson la best clone
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            var listFooChild = new System.Collections.Generic.List<FooChild>() {
             new FooChild(){
              Name = "FooChild"
             }
            };

            var foo = new Foo();
            foo.Name = "Foo";
            foo.Id = 1;
            foo.ListFooChild = listFooChild;

            var fooClone = (Foo)foo.Clone();
            fooClone.Name = "Foo Clone";
            fooClone.Id = 2;

            var foo2Clone = CloneJson<Foo>(foo);
            foo2Clone.Name = "Foo2 Clone";
            foo2Clone.Id = 3;

            listFooChild.FirstOrDefault().Name = "FooChildNameSetAfterCloned";

            Console.WriteLine(

                $" Foo: {Newtonsoft.Json.JsonConvert.SerializeObject(foo)}" + Environment.NewLine +

                $" FooClone: {Newtonsoft.Json.JsonConvert.SerializeObject(fooClone)}" + Environment.NewLine +

                $" Foo2Clone: {Newtonsoft.Json.JsonConvert.SerializeObject(foo2Clone)}"

                );
        }
    }
}
