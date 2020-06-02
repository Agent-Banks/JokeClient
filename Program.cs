﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JokeClient
{
    class Program
    {
        class Joke
        {
            public int id { get; set; }
            public string type { get; set; }
            public string setup { get; set; }
            public string punchline { get; set; }
        }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/programming/random");
            var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);

            foreach (var joke in jokes)
            {
                Console.WriteLine($"This is a {joke.type} joke! {joke.setup} {joke.punchline}");

            }
        }
    }
}
