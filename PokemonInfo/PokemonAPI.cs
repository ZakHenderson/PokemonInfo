using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonInfo
{
    public class PokemonAPI
    {
        public List<PokemonItem> results { get; set; }

        

    }
    public class PokemonItem
    {
        public string name { get; set; }
        public string url { get; set; }

        public string height { get; set; }

        public string weight { get; set; }
        public override string ToString()
        {
            return name;
        }
    }



}
