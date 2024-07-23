# Single line section

Given the following file:
```ini
# Section(1).
[WorldTime]
23

# Section(2).
[Weather]
45
```
The sections have only one data, so you can retrieve the data in this way:
```cs
ISectionsData sections = SectionsFile.Load("test.ini");

Console.WriteLine(int.Parse(sections["WorldTime"][0]));
Console.WriteLine(int.Parse(sections["Weather"][0]));
/*
    The example displays the following output:
    23
    45
*/
```
Or we can also do it this way:
```cs
// Import all types to use the extension methods.
using SeztionParser;

Console.WriteLine(sections.GetFirstLineInt("WorldTime"));
Console.WriteLine(sections.GetFirstLineInt("Weather"));
/*
    The example displays the following output:
    23
    45
*/
```
If the `Weather` section has more than one piece of data, the `GetFirstLineInt` method will always return the data from the first line of `Weather`.

You can review all extension methods at this [link](https://mrdave1999.github.io/seztion-parser/api/SeztionParser.SingleLineSection.html).