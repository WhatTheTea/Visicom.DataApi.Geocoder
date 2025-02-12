# Visicom.DataApi.Geocoder

[![unit tests](https://github.com/WhatTheTea/Visicom.DataApi.Geocoder/actions/workflows/unit-tests.yml/badge.svg)](https://github.com/WhatTheTea/Visicom.DataApi.Geocoder/actions/workflows/unit-tests.yml)
[![NuGet Version](https://img.shields.io/nuget/v/Visicom.DataApi.Geocoder)](https://www.nuget.org/packages/Visicom.DataApi.Geocoder/)
[![Made in Ukraine](https://img.shields.io/badge/made_in-Ukraine-ffd700.svg?labelColor=0057b7)](https://stand-with-ukraine.pp.ua)

Simple wrapper for Visicom geocoding APIs for .NET ecosystem

## How to get coordinates from address
```csharp
var address = "м. Київ, вул. Хрещатик, 26";
var apikey = "your-visicom-dapi-key"

var options = new RequestOptions(Languages.Ukrainian, apikey ?? string.Empty);
Geocoder = new BasicGeocoder(new HttpClient(), options);

var result = await Geocoder.GetCoordinatesAsync(address);
```
