using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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
            int numIndex = cboPokemon.SelectedIndex;

            string fronturl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{numIndex + 1}.png";

            string url = "https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0";

            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url).Result;
                var pokemon = JsonConvert.DeserializeObject<PokemonAPI>(response);

                lstPokemon.Items.Clear();

                if (cboPokemon.SelectedIndex == numIndex)
                {
                    imgPokemon.Source = new BitmapImage(new Uri(fronturl));
                    lstPokemon.Items.Add("Name: " + pokemon.results[numIndex].name + " Height: " + pokemon.results[numIndex].height + " Weight: " + pokemon.results[numIndex].weight);
                }
            }

        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {
            
            int numIndex = cboPokemon.SelectedIndex;
            string backurl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/{numIndex + 1}.png";
            string fronturl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{numIndex + 1}.png";

            string url = "https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0";

            bool isBackImageDisplayed = false;

            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url).Result;
                var pokemon = JsonConvert.DeserializeObject<PokemonAPI>(response);

                if (imgPokemon.Source.ToString() == fronturl)
            {
                    isBackImageDisplayed = false;
                }
                else
                {
                    isBackImageDisplayed = true;
                }

                
                if (!isBackImageDisplayed)
                {
                    imgPokemon.Source = new BitmapImage(new Uri(backurl));
                }
                else
                {
                    imgPokemon.Source = new BitmapImage(new Uri(fronturl));
                }

                


            }
        }
    }

}
