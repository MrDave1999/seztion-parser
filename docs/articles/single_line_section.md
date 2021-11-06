# Single line section

Given the following file:
```ini
#Section1
[WorldTime]
23

#Section2
[Weather]
45
```
The sections have only one data, so you can retrieve the data in this way:
```cs
ISectionsData sections = SectionsFile.Load("test.ini");

int worldTime = int.Parse(sections["WorldTime"][0]); //23
int weather = int.Parse(sections["Weather"][0]); //45
```
Or we can also do it this way:
```cs
//Import all types to use the extension methods.
using SeztionParser.Helpers;

int worldTime = sections.GetFirstLineInt("WorldTime"); //23
int weather = sections.GetFirstLineInt("Weather"); //45
```
If the `Weather` section has more than one piece of data, the `GetFirstLineInt` method will always return the data from the first line of `Weather`.

You can review all extension methods at this [link](https://mrdave1999.github.io/seztion-parser/api/SeztionParser.Helpers.SingleLineSection.html).