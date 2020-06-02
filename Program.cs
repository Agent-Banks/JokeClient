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
            var userWantsToQuit = true;
            while (userWantsToQuit)
            {
                Console.WriteLine("(1)- View one random programming joke");
                Console.WriteLine("(2)- View ten random programing jokes");
                Console.WriteLine("(3)- View one general joke");
                Console.WriteLine("(4)- View ten random general jokes");
                Console.WriteLine("(5)- Quit the application");

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
                    var client = new HttpClient();

                    var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/general/random");
                    var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);

                    foreach (var joke in jokes)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"This is a {joke.Type} joke! {joke.Setup} {joke.Punchline}");
                        Console.WriteLine("----------------------------");

                    }
                }

                if (option == 4)
                {
                    var client = new HttpClient();

                    var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/general/ten");
                    var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);

                    foreach (var joke in jokes)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"This is a {joke.Type} joke! {joke.Setup} {joke.Punchline}");
                        Console.WriteLine("----------------------------");

                    }
                }

                if (option == 5)
                {
                    userWantsToQuit = false;
                }
            }
        }
    }
}
