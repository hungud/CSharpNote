using System;
using System.Collections.Generic;
using System.Text;

namespace LibAutoMapper.Domain
{
    public class FooDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Idate { get; set; }


        public int Status { get; set; }

        public List<FooChild> ListFooChild { get; set; }
    }
}
