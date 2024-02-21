
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AvaloniaApplication.Views;
using AvaloniaApplication.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace AvaloniaApplication.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; }
        }

        private readonly HttpClient _httpClient;

        private string _jsonResponse;
        public string JsonResponse
        {
            get => _jsonResponse;
            set
            {
                _jsonResponse = value;
                OnPropertyChanged(nameof(JsonResponse));
            }
        }

        public MainViewModel()
        {
            _httpClient = new HttpClient();
        }

        public async Task MakeSearch()
        {
            try
            {
                string apiUrl = "https://www.anapioficeandfire.com/api";

                
                string charactersUrl = $"{apiUrl}/characters?name={Uri.EscapeDataString(SearchQuery)}";
                string charactersResponse = await _httpClient.GetStringAsync(charactersUrl);
                var charactersResult = JsonConvert.DeserializeObject<Character[]>(charactersResponse);

                
                string booksUrl = $"{apiUrl}/books?name={Uri.EscapeDataString(SearchQuery)}";
                string booksResponse = await _httpClient.GetStringAsync(booksUrl);
                var booksResult = JsonConvert.DeserializeObject<Book[]>(booksResponse);

                
                string housesUrl = $"{apiUrl}/houses?name={Uri.EscapeDataString(SearchQuery)}";
                string housesResponse = await _httpClient.GetStringAsync(housesUrl);
                var housesResult = JsonConvert.DeserializeObject<House[]>(housesResponse);

                var stringBuilder = new System.Text.StringBuilder();

                //stringBuilder.AppendLine("Character:");
                foreach (var result in charactersResult)
                {
                    stringBuilder.AppendLine($"Name: {result.name}\nCulture: {result.culture}\nBorn: {result.born}\nDied: {result.died}\nTitles: {string.Join(", ", result.titles)}\nAliases: {string.Join(", ", result.aliases)}\n");
                }

                //stringBuilder.AppendLine("Book:");
                foreach (var result in booksResult)
                {
                    stringBuilder.AppendLine($"Name: {result.name}\nISBN: {result.isbn}\nAuthors: {string.Join(", ", result.authors)}\nNumber of Pages: {result.numberofpages}\nPublisher: {result.publisher}\n");
                }

                //stringBuilder.AppendLine("House:");
                foreach (var result in housesResult)
                {
                    stringBuilder.AppendLine($"Name: {result.name}\nRegion: {result.region}\nCoat of Arms: {result.coatofarms}\nWords: {result.words}\nTitles: {string.Join(", ", result.titles)}\nAncestral Weapons: {string.Join(", ", result.ancestralweapons)}\n");
                }

                JsonResponse = stringBuilder.ToString();

                
                using (var context = new Database())
                {
                    
                    foreach (var result in charactersResult)
                    {
                        var existingCharacter = await context.Character.FirstOrDefaultAsync(c => c.name == result.name);
                        if (existingCharacter == null)
                        {
                            var newCharacter = new Character
                            {
                                url = result.url,
                                name = result.name,
                                gender = result.gender,
                                culture = result.culture,
                                born = result.born,
                                died = result.died,
                                titles = result.titles,
                                aliases = result.aliases,
                                father = result.father,
                                mother = result.mother,
                                spouse = result.spouse,
                                allegiances = result.allegiances,
                                books = result.books,
                                povbooks = result.povbooks,
                                tvseries = result.tvseries,
                                playedby = result.playedby
                            };

                            context.Character.Add(newCharacter);
                        }
                    }

                   
                    foreach (var result in booksResult)
                    {
                        var existingBook = await context.Book.FirstOrDefaultAsync(b => b.name == result.name);
                        if (existingBook == null)
                        {
                            var newBook = new Book
                            {
                                name = result.name,
                                isbn = result.isbn,
                                authors = result.authors,
                                numberofpages = result.numberofpages,
                                publisher = result.publisher,
                                country = result.country,
                                mediatype = result.mediatype,
                                released = result.released,
                                characters = result.characters,
                                povcharacters = result.povcharacters
                            };

                            context.Book.Add(newBook);
                        }

                    }

                    
                    foreach (var result in housesResult)
                    {
                        var existingHouse = await context.House.FirstOrDefaultAsync(h => h.name == result.name);
                        if (existingHouse == null)
                        {
                            var newHouse = new House
                            {
                                url = result.url,
                                name = result.name,
                                region = result.region,
                                coatofarms = result.coatofarms,
                                words = result.words,
                                titles = result.titles,
                                seats = result.seats,
                                currentlord = result.currentlord,
                                heir = result.heir,
                                overlord = result.overlord,
                                founded = result.founded,
                                founder = result.founder,
                                diedout = result.diedout,
                                ancestralweapons = result.ancestralweapons,
                                cadetbranches = result.cadetbranches,
                                swornmembers = result.swornmembers
                            };

                            context.House.Add(newHouse);
                        }
                    }
                    await context.SaveChangesAsync();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            finally
            {
                Console.WriteLine("Search Completed");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
