using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace PokemonInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = "https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0";

            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url).Result;
                var pokemon = JsonConvert.DeserializeObject<PokemonAPI>(response);

                foreach (var item in pokemon.results)
                {
                    cboPokemon.Items.Add(item);
                }
            }




        }

        private void cboPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPokemon.SelectedItem is PokemonItem selectedPokemon)
            {
                // Create a list of selected Pokémon to display in the ListBox
                var selectedPokemonList = new List<PokemonItem> { selectedPokemon };

                // Set the ListBox's ItemsSource to the list of selected Pokémon
                lstPokemon.ItemsSource = selectedPokemonList;
            }
        }
    }
}
