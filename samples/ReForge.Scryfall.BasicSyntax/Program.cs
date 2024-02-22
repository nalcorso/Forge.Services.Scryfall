// See https://aka.ms/new-console-template for more information

using Dumpify;
using Microsoft.Extensions.Logging;
using ReForge.Scryfall;

Console.WriteLine("Scryfall Scratchpad - Basic Syntax");

var dumpConfig = DumpConfig.Default;
dumpConfig.AddCustomTypeHandler(typeof(Uri), (o, type, arg3, arg4) => o.ToString());

var consoleLogger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<ScryfallClient>();

var scryfallClient = ScryfallClient.Create()
    .WithClient(new HttpClient())
    .WithLogger(consoleLogger)
    .WithDefaultCache()
    .Build();

//var randomCard = await scryfallClient.Cards.RandomAsync();
//randomCard.Dump();

//var setTest = await scryfallClient.Sets.AllAsync();
//var setTest = await scryfallClient.Sets.ByCodeAsync("uma");
//var setTest = await scryfallClient.Sets.ByTcgPlayerIdAsync(1909);
//var setTest = await scryfallClient.Sets.ByIdAsync(Guid.Parse("2ec77b94-6d47-4891-a480-5d0b4e5c9372"));
//setTest.Dump();

var cardSearch = await scryfallClient.Cards.NamedExactAsync("Black Potus");
cardSearch.Dump();