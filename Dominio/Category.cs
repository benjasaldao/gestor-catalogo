using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public int id {  get; set; }
        public string description { get; set; }

        public Category() { }

        public Category(int id, string description)
        {
            this.id = id;
            this.description = description;
        }   

        public override string ToString()
        {
            return description;
        }
    }
}
