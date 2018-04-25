using Biosphere.Common.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMe.DataAccess.Models
{
    public class Player : DbElementBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HumanCount { get; set; }
    }
}
