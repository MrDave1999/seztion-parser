[![seztion-parser](images/seztionparser-logo.png)](https://github.com/mrdave1999/seztion-parser)

[![seztion-parser](https://img.shields.io/badge/.NET%20Standard-2.0-red)](https://github.com/mrdave1999/seztion-parser)
[![seztion-parser](https://img.shields.io/badge/License-MIT-green)](https://raw.githubusercontent.com/MrDave1999/seztion-parser/master/LICENSE)
[![seztion-parser](https://img.shields.io/badge/Project-Class%20Library-yellow)](https://github.com/mrdave1999/seztion-parser)
[![Nuget-Badges](https://buildstats.info/nuget/seztion-parser)](https://www.nuget.org/packages/seztion-parser/)
[![PayPal-donate-button](https://img.shields.io/badge/paypal-donate-orange)](https://www.paypal.com/paypalme/DavidRomanAmariles)


**seztion-parser** is a class library used to read data from each section of a file (the file extension can be any, e.g. `.INI`).

There is a history behind why this library exists.

Some time ago I was creating a gamemode in [SA-MP](https://sa-mp.mp/) (San Andreas Multiplayer, a multiplayer mod for GTA San Andrea) that was based on two teams (Alpha and Beta), so I needed to somehow store the **spawn positions** (is the location where the player appears on the map) of a given map (the place where the player plays).

Then it occurred to me that I could save the spawn positions in a file in this way:
```ini
# Section(1).
[Alpha]
# Spawn positions - Alpha Team.
2548.7009,-1283.2224,1060.9844,230.3022
2565.8301,-1281.7773,1065.3672,238.1356
2575.7759,-1283.3206,1065.3672,177.9750
2580.8525,-1284.6443,1065.3579,88.0476
2568.5518,-1283.6564,1060.9844,181.0851

# Section(2).
[Beta]
# Spawn positions - Beta Team.
2532.1660,-1283.6971,1031.4219,270.0725
2532.5823,-1292.2178,1031.4219,275.7126
2532.9485,-1302.3477,1031.4219,269.4458
2541.2852,-1303.9135,1031.4219,269.4458
2542.1389,-1293.7726,1031.4219,262.8658
```
And this is where the **seztion-parzer** library comes into play, as it is simple to extract this data with this library. I didn't want to use a database for this, I wanted something very simple and this is what I came up with at the time.