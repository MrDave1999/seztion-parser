# Getting Started with `seztion parser`

## Installation

If you're an hardcore and want to do it manually, you must add the following to the `csproj` file:
```xml
<PackageReference Include="seztion-parser" Version="1.0.0" />
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
#Section1
[Positions1]
#data:
-129.5612,81.0056,3.1172,156.7189
-127.6526,87.7695,3.1172,156.7189
-134.9525,90.2646,3.1172,167.0590
-138.4023,83.5352,3.1172,163.6123
-145.3216,85.1476,3.1172,163.6123

#Section2
[Positions2]
#data:
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
using SeztionParser.Facades;
```
You can then use the `Load` method of the `SectionsFile` class to load the **sections file** and it will return an instance of type `ISectionsData` that will allow you to access the **sections data**.
```cs
//Load the sections file.
var sections = SectionsFile.Load("Aim_Headshot.ini");
```
You can then gets the data for a specific section:
```cs
ISectionData positions1 = sections["Positions1"];
ISectionData positions2 = sections["Positions2"];
```
You can then iterate over the data in a specified section:
```cs
Console.WriteLine("[Positions1]");
//This prints the data of the "Positions1" section.
foreach (string data in sections["Positions1"])
    Console.WriteLine(data);

Console.WriteLine();

Console.WriteLine("[Positions2]");
//This prints the data of the "Positions2" section.
foreach (string data in sections["Positions2"])
    Console.WriteLine(data);

/*
    -> Output:
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
foreach (string sectionName in sections.GetNames())
    Console.WriteLine($"Section: {sectionName}");
/*
    -> Output:
    Section: Positions1
    Section: Positions2
*/
```
### GetAll
If you want to gets the data of all sections, use the `GetAll` method of the `ISectionsData` interface:
```cs
foreach (ISectionData data in sections.GetAll())
    Console.Write(data.ToString());
/*
    -> Output:
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
    -> Output:
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
**Note:** Do not forget to import all namespace types:
```cs
using SeztionParser.Models;
```
### SectionsData To String
You can also convert the instance of type `ISectionsData` into an object of type `String`:
```cs
Console.WriteLine(sections.ToString());
/*
    Output:
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
//You must import all the types:
using SeztionParser.Models;
//...

foreach (SectionModel section in sections)
    Console.WriteLine($"{section.Name}, {section.Data.Count}");
/*
    -> Output:
    Positions1, 5
    Positions2, 5
*/
```
Or you can also [deconstruct](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct) the object:
```cs
foreach (var(name, data) in sections)
    Console.WriteLine($"{name}, {data.Count}");
/*
    -> Output:
    Positions1, 5
    Positions2, 5
*/
```

**Note:** If you don't know what each class does, don't forget to check the [API documentation](https://mrdave1999.github.io/seztion-parser/api/SeztionParser.Exceptions.html).

