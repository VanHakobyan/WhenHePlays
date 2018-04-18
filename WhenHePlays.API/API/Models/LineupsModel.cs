using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LineupsModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public bool IsCaptain { get; set; } = false;
    }
}
