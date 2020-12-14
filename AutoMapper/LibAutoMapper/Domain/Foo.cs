using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibAutoMapper.Domain
{
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Idate { get; set; }


        public int Status { get; set; }
        
        public List<FooChild> ListFooChild { get; set; }

        public static Faker<Foo> GenFoo
        {
            get
            {
                return new Faker<Foo>()
                .RuleFor(p => p.Id, f => f.UniqueIndex)
                .RuleFor(p => p.Name, f => f.Person.Company.Name)
                .RuleFor(p => p.Idate, f => f.Date.Past(1))
                .RuleFor(p => p.Status, f => f.Random.Number(0,1))
                .RuleFor(p => p.ListFooChild, f => FooChild.GenFooChild.Generate(3).ToList());
            }
        }
    }
}
