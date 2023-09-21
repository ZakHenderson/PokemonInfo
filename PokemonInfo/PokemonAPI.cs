using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonInfo
{
    public class PokemonAPI
    {
        //results list for the pokemon items
        public List<PokemonItem> results { get; set; }

        

    }
    public class PokemonItem
    {
        public string name { get; set; }
        public string url { get; set; }

        public double height { get; set; }

        public double weight { get; set; }

        //override to be able to list names inside the combo box
        public override string ToString()
        {
            return name;
        }
        // this class might be wrong might not be
        public PokemonItem()
        {
            string name = string.Empty;
            string url = string.Empty;
            double height = 0.0;
            double weight = 0.0;
        }
    }



}
