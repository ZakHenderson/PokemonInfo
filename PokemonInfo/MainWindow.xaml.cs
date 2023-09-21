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
//I want to be able to call information into my list box that relates to the pokemon desired. For instance if you click on the pokemon charizard
//it should tell you its name, and other desired information such as height weight, maybe abilities or evolutions or something. for now Im just trying to figure out like
// height and weight of the pokemon. currently it just displays the info "height: 0 and weight: 0" because i cant figure it out haha. 
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
            //pokemon api
            string url = "https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0";
            //json requrest for pokemon info
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url).Result;
                var pokemon = JsonConvert.DeserializeObject<PokemonAPI>(response);
                //put items into the combo box
                foreach (var item in pokemon.results)
                {
                    cboPokemon.Items.Add(item);
                }
            }




        }
        /// <summary>
        /// if you click a pokemon in the combo box it should bring up certain select information about the pokemon.IE name, height, weight, etc.
        /// I got it to list the name of the pokemon but can quite figure out how to get it to list other information. the box clears every new pokemon.
        /// it also brings up a picture of the desired pokemon in relation to its combo box index number.
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// this button checks if the pokemons front image is selected and if so and is clicked will change to its back image. and if clicked again will change back
        /// to the front image. Most pokemon have an image associated with it, if it doesnt it should break the program because I havent made the button not crash
        /// the program from a picture not being there yet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
