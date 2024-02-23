// See https://aka.ms/new-console-template for more information

using System.Text;
using Dumpify;
using Microsoft.Extensions.Logging;
using ReForge.Scryfall;
using ReForge.Scryfall.APIs;
using ReForge.Scryfall.Models;

Console.OutputEncoding = Encoding.UTF8;


Console.WriteLine("Scryfall Scratchpad - Basic Syntax");

var dumpConfig = DumpConfig.Default;
dumpConfig.AddCustomTypeHandler(typeof(Uri), (o, type, arg3, arg4) => o.ToString());

var consoleLogger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<ScryfallClient>();

var scryfallClient = ScryfallClient.Create()
    .WithClient(new HttpClient())
    .WithLogger(consoleLogger)
    .WithDefaultCache()
    .Build();


// var resultOr = await scryfallClient.Sets.AllAsync();
// var resultOr = await scryfallClient.Sets.ByCodeAsync("uma");
// var resultOr = await scryfallClient.Sets.ByCodeAsync("");
// var resultOr = await scryfallClient.Sets.ByTcgPlayerIdAsync(1909);
// var resultOr = await scryfallClient.Sets.ByIdAsync(Guid.Parse("2ec77b94-6d47-4891-a480-5d0b4e5c9372"));
// var resultOr = await scryfallClient.Cards.SearchAsync("t:creature o:draw");
// var resultOr = await scryfallClient.Cards.NamedExactAsync("Black Lotus");
// var resultOr = await scryfallClient.Cards.NamedFuzzyAsync("Tarmog");
// var resultOr = await scryfallClient.Cards.AutoCompleteAsync("Tarm");
// var resultOr = await scryfallClient.Cards.RandomAsync();
//var resultOr = await scryfallClient.Cards.RandomAsync("is:commander");

var collectionParameters = new CollectionParametersBuilder()
    .WithId(Guid.Parse("683a5707-cddb-494d-9b41-51b4584ded69"))
    .WithName("Ancient Tomb")
    .WithCollectorNumberAndSet("150", "mrd")
    .Build();

//var resultOr = await scryfallClient.Cards.CollectionAsync(collectionParameters);
//var resultOr = await scryfallClient.Cards.ByCollectorNumberAsync("khm", "1");
var resultOr = await scryfallClient.Cards.ByCollectorNumberAsync("khm", "1", Language.Japanese);

var result = resultOr.OrElseThrow();
result.Dump();