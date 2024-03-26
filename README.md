# Forge.Services.Scryfall

Forge.Services.Scryfall is a .NET library for interacting with the Scryfall API. It provides a simple and intuitive way to access various Scryfall services such as Cards, Sets, Rulings, Symbology, Catalog, Bulk Data, and Migrations.

## Features

- **Cards API**: Search for cards, get card details by various identifiers, autocomplete card names, and more.
- **Sets API**: Get all sets, get set details by code or ID.
- **Rulings API**: Get rulings by various card identifiers.
- **Symbology API**: Get all card symbols, parse mana costs.
- **Catalog API**: Get various catalogs like card names, artist names, creature types, etc.
- **Bulk Data API**: Get all bulk data objects, get bulk data by type or ID.
- **Migrations API**: Get all card migrations, get migration by ID.

## Getting Started

To use the ReForge.Scryfall library, you need to create an instance of `ScryfallClient`. You can do this using the `ScryfallClientBuilder` class.

```csharp
var client = new ScryfallClientBuilder()
    .WithClient(new HttpClient())
    .WithLogger(new NullLogger())
    .Build();
```

Once you have an instance of `ScryfallClient`, you can use it to access various Scryfall services.

```csharp
var cards = await client.Cards.SearchAsync("Black Lotus");
```

## Documentation

For more detailed information about each API and how to use them, please refer to the Scryfall API documentation at https://scryfall.com/docs/api.

## Contributing

Contributions are welcome! Please feel free to submit a pull request.

## License

ReForge.Scryfall is licensed under the MIT License. See the LICENSE file for more information.