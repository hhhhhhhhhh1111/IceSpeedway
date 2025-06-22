using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceSpeedway.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string City { get; set; }
        public int Tour1 { get; set; }
        public int Tour2 { get; set; }
        public int Tour3 { get; set; }
        public int Tour4 { get; set; }
        public int Tour5 { get; set; }
    }
}