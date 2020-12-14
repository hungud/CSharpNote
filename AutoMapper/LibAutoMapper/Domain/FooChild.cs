using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibAutoMapper.Domain
{
    public class FooChild
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FooChild2> ListFooChild2 { get; set; }

        public static Faker<FooChild> GenFooChild
        {
            get
            {
                return new Faker<FooChild>()
                .RuleFor(p => p.Id, f => f.UniqueIndex)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.ListFooChild2, f => FooChild2.GenFooChild2.Generate(3).ToList());
            }
        }
    }
}
