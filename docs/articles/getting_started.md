# Getting Started with `seztion parser`

## Installation

If you're an hardcore and want to do it manually, you must add the following to the `csproj` file:
```xml
<PackageReference Include="seztion-parser" Version="3.0.0" />
```
If you're want to install the package from Visual Studio, you must open the project/solution in Visual Studio, and open the console using the **Tools** > **NuGet Package Manager** > **Package Manager Console** command and run the install command:
```
Install-Package seztion-parser
```
If you are making use of the dotnet CLI, then run the following in your terminal:
```
dotnet add package seztion-parser
```

## Usage

Let's imagine that there is this file named `Aim_Headshot.ini`:
```ini
# Section(1).
[Positions1]
# Data:
-129.5612,81.0056,3.1172,156.7189
-127.6526,87.7695,3.1172,156.7189
-134.9525,90.2646,3.1172,167.0590
-138.4023,83.5352,3.1172,163.6123
-145.3216,85.1476,3.1172,163.6123

# Section(2).
[Positions2]
# Data:
-277.0338,-85.0175,2.8617,345.0341
-277.7510,-90.4126,2.7030,345.0341
-270.0297,-92.0674,3.0969,345.0341
-263.8904,-93.2464,3.1172,345.0341
-262.2849,-87.2403,3.1172,345.0341
```
This file has comments and sections. `Positions1` and `Positions2` are sections and each has a **data set**.

### Load
You must import all namespace types:
```cs
using SeztionParser;
```
You can then use the `Load` method of the `SectionsFile` class to load the **sections file** and it will return an instance of type `ISectionsData` that will allow you to access the **sections data**.
```cs
// Load the sections file.
ISectionsData sections = SectionsFile.Load("Aim_Headshot.ini");
```
You can then gets the data for a specific section:
```cs
ISectionData positions1 = sections["Positions1"];
ISectionData positions2 = sections["Positions2"];
```
You can then iterate over the data in a specified section:
```cs
Console.WriteLine("[Positions1]");
ISectionData positions1 = sections["Positions1"];
// This prints the data of the 'Positions1' section.
foreach (string data in positions1)
    Console.WriteLine(data);

Console.WriteLine();

Console.WriteLine("[Positions2]");
ISectionData positions2 = sections["Positions2"];
// This prints the data of the 'Positions2' section.
foreach (string data in positions2)
    Console.WriteLine(data);

/*
    The example displays the following output:
    [Positions1]
    -129.5612,81.0056,3.1172,156.7189
    -127.6526,87.7695,3.1172,156.7189
    -134.9525,90.2646,3.1172,167.0590
    -138.4023,83.5352,3.1172,163.6123
    -145.3216,85.1476,3.1172,163.6123

    [Positions2]
    -277.0338,-85.0175,2.8617,345.0341
    -277.7510,-90.4126,2.7030,345.0341
    -270.0297,-92.0674,3.0969,345.0341
    -263.8904,-93.2464,3.1172,345.0341
    -262.2849,-87.2403,3.1172,345.0341
*/
```
### GetNames
If you want to gets the names of all the sections, use the `GetNames` method of the `ISectionsData` interface:
```cs
ICollection<string> names = sections.GetNames();
foreach (string sectionName in names)
    Console.WriteLine($"Section: {sectionName}");
/*
    The example displays the following output:
    Section: Positions1
    Section: Positions2
*/
```
### GetAll
If you want to gets the data of all sections, use the `GetAll` method of the `ISectionsData` interface:
```cs
ICollection<ISectionData> dataSet = sections.GetAll();
foreach (ISectionData data in dataSet)
    Console.Write(data.ToString());
/*
    The example displays the following output:
    [
        -129.5612,81.0056,3.1172,156.7189
        -127.6526,87.7695,3.1172,156.7189
        -134.9525,90.2646,3.1172,167.0590
        -138.4023,83.5352,3.1172,163.6123
        -145.3216,85.1476,3.1172,163.6123
    ]
    [
        -277.0338,-85.0175,2.8617,345.0341
        -277.7510,-90.4126,2.7030,345.0341
        -270.0297,-92.0674,3.0969,345.0341
        -263.8904,-93.2464,3.1172,345.0341
        -262.2849,-87.2403,3.1172,345.0341
    ]
*/
```
### Iterate all sections
You can iterate over all sections using the `SectionModel` class:
```cs
foreach (SectionModel section in sections)
    Console.Write(section.ToString());
/*
    The example displays the following output:
    Section: Positions1 -> 
    [
        -129.5612,81.0056,3.1172,156.7189
        -127.6526,87.7695,3.1172,156.7189
        -134.9525,90.2646,3.1172,167.0590
        -138.4023,83.5352,3.1172,163.6123
        -145.3216,85.1476,3.1172,163.6123
    ]
    Section: Positions2 ->
    [
        -277.0338,-85.0175,2.8617,345.0341
        -277.7510,-90.4126,2.7030,345.0341
        -270.0297,-92.0674,3.0969,345.0341
        -263.8904,-93.2464,3.1172,345.0341
        -262.2849,-87.2403,3.1172,345.0341
    ]
*/
```
### SectionsData To String
You can also convert the instance of type `ISectionsData` into an object of type `String`:
```cs
Console.WriteLine(sections.ToString());
/*
    The example displays the following output:
    Section: Positions1 -> 
    [
        -129.5612,81.0056,3.1172,156.7189
        -127.6526,87.7695,3.1172,156.7189
        -134.9525,90.2646,3.1172,167.0590
        -138.4023,83.5352,3.1172,163.6123
        -145.3216,85.1476,3.1172,163.6123
    ]
    Section: Positions2 ->
    [
        -277.0338,-85.0175,2.8617,345.0341
        -277.7510,-90.4126,2.7030,345.0341
        -270.0297,-92.0674,3.0969,345.0341
        -263.8904,-93.2464,3.1172,345.0341
        -262.2849,-87.2403,3.1172,345.0341
    ]
*/
```
### Properties SectionModel class
You can also gets the **amount of data** and **name** for each section:
```cs
foreach (SectionModel section in sections)
    Console.WriteLine($"{section.Name}, {section.Data.Count}");
/*
    The example displays the following output:
    Positions1, 5
    Positions2, 5
*/
```
Or you can also [deconstruct](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct) the object:
```cs
foreach ((string name, ISectionData data) in sections)
    Console.WriteLine($"{name}, {data.Count}");
/*
    The example displays the following output:
    Positions1, 5
    Positions2, 5
*/
```

**Note:** If you don't know what each class does, don't forget to check the [API documentation](https://mrdave1999.github.io/seztion-parser/api/SeztionParser.html).