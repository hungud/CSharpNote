using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibAutoMapper.Domain
{
    public class Factory
    {
        

        public static Faker<FooChild> GenFooChild1()
        {
            return new Faker<FooChild>()
                .RuleFor(p => p.Id, f => f.UniqueIndex)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName());
        }
    }
}
