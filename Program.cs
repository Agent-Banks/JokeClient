using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JokeClient
{
    class Program
    {
        class Joke
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("setup")]
            public string Setup { get; set; }

            [JsonPropertyName("punchline")]
            public string Punchline { get; set; }
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int inputFromUser;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out inputFromUser);

            if (isThisGoodInput)
            {
                return inputFromUser;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }

        }
        static async Task Main(string[] args)
        {
            var userWantsToQuit = false;
            while (userWantsToQuit == false)
            {
                Console.WriteLine("(1)- View one random programming joke");
                Console.WriteLine("(2)- View 10 random programing jokes");
                Console.WriteLine("(3)- Quit the application");
                var option = PromptForInteger("Option: ");

                if (option == 1)
                {
                    var client = new HttpClient();

                    var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/programming/random");
                    var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);

                    foreach (var joke in jokes)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"This is a {joke.Type} joke! {joke.Setup} {joke.Punchline}");
                        Console.WriteLine("----------------------------");

                    }
                }

                if (option == 2)
                {
                    var client = new HttpClient();

                    var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/programming/ten");
                    var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);

                    foreach (var joke in jokes)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"This is a {joke.Type} joke! {joke.Setup} {joke.Punchline}");
                        Console.WriteLine("----------------------------");

                    }
                }

                if (option == 3)
                {
                    userWantsToQuit = true;
                }
            }
        }
    }
}
