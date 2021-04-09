using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetCsTheo.Models
{
    public class Restaurant
    {
        public Restaurant() { }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Commentary { get; set; }
        public String Email { get; set; }
        public String Street { get; set; }
        public int Zip { get; set; }
        public String City { get; set; }
        public String LastTimeVisited { get; set; }
        public int Note { get; set; }
        public String NoteCommentary { get; set; }
    }
}
