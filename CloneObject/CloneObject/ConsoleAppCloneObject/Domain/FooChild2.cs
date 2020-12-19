using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCloneObject.Domain
{
    public class FooChild2
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Faker<FooChild2> GenFooChild2
        {
            get
            {
                return new Faker<FooChild2>()
                .RuleFor(p => p.Id, f => f.UniqueIndex)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName());
            }
        }
    }
}
