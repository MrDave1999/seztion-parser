# Section data conversion

Given the following file:
```ini
#Section1
[Prices1]
12.4
45.2
5676.313
56.2


#Section2
[Prices2]
23.423
53.13
67.78
```

The data for each section can be gets in this way:
```cs
ISectionsData sections = SectionsFile.Load("prices.ini");
```
But the data in each section are by default of type `string`:
```cs
string price1 = sections["Prices1"][0]; //12.4
string price2 = sections["Prices2"][0]; //23.423
//....
```
To convert all the data in a section to a particular type (such as `int`, `double` or `float`), you must write the following:
```cs
//Import all types to use the extension methods.
using SeztionParser.Helpers;

IEnumerable<double> prices = sections.ToDouble("Prices1");
foreach (double data in prices)
    Console.WriteLine(data);
```
The methods `ToDouble`, `ToInt`, etc. do not return all the data in a collection and this is to avoid memory consumption, so it returns an instance that implements the `IEnumerable` interface and this way, you can retrieve a data every time you need it.

You can review all extension methods at this [link](https://mrdave1999.github.io/seztion-parser/api/SeztionParser.Helpers.SectionDataConversion.html).
