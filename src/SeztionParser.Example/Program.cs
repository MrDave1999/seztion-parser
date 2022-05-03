using SeztionParser.Helpers;
using SeztionParser.Providers;

string sectionsFile = @"
    # spawn-positions team Alpha    

    [Alpha]
    -129.5612,81.0056,3.1172,156.7189
    -127.6526,87.7695,3.1172,156.7189
    -134.9525,90.2646,3.1172,167.0590
    -138.4023,83.5352,3.1172,163.6123
    -145.3216,85.1476,3.1172,163.6123
    -152.4534,80.4830,3.1094,163.6123
    -161.3326,83.2152,3.1094,167.3724
    -159.6665,98.1220,3.1121,165.8291
    -173.8980,102.8791,3.1668,162.3824
    -186.4793,93.0401,3.1172,162.3824

                  

    # spawn-positions team Beta  
       
    [Beta]
    -277.0338,-85.0175,2.8617,345.0341
    -277.7510,-90.4126,2.7030,345.0341
    -270.0297,-92.0674,3.0969,345.0341
    -263.8904,-93.2464,3.1172,345.0341
    -262.2849,-87.2403,3.1172,345.0341
    -255.3565,-84.1217,3.1172,345.0341
    -245.9794,-86.1564,3.1172,345.0341
    -247.4499,-99.9677,3.1172,345.0341
    -235.9863,-102.5671,3.1094,345.3474
    -220.4884,-110.9102,3.1172,352.5542


      
    [Interior]
    23
   
    [Weather]
    31

    [WorldTime]
    20

    [MoneyTotal]
    2152
     
        
    [WorldVirtual]
    1

    [Angles]
    360.01
    565.34
    653.1
    212.4
";
var sections = new SectionsParser().Parse(sectionsFile);

Console.WriteLine("------------------- Process (1) -------------------");
Console.WriteLine("[Alpha]");
//This prints the data of the "Alpha" section.
foreach (var data in sections["Alpha"])
    Console.WriteLine(data);

Console.WriteLine();

Console.WriteLine("[Beta]");
//This prints the data of the "Beta" section.
foreach (var data in sections["Beta"])
    Console.WriteLine(data);
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("\n\n");

Console.WriteLine("------------------- Process (2) -------------------");
foreach (var sectionName in sections.GetNames())
    Console.WriteLine($"Section: {sectionName}");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("\n\n");

Console.WriteLine("------------------- Process (3) -------------------");
foreach (var data in sections.GetAll())
    Console.Write(data.ToString());
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("\n\n");

Console.WriteLine("------------------- Process (4) -------------------");
foreach (var section in sections)
    Console.Write(section.ToString());
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("\n\n");

Console.WriteLine("------------------- Process (5) -------------------");
Console.WriteLine(sections.ToString());
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("\n\n");

Console.WriteLine("------------------- Process (6) -------------------");
foreach (var (name, data) in sections)
    Console.WriteLine($"{name}, {data.Count}");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("\n\n");

Console.WriteLine("------------------- Process (7) -------------------");
foreach (double value in sections.ToDouble("Angles"))
    Console.WriteLine(value);
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("\n\n");

Console.WriteLine("------------------- Process (8) -------------------");
Console.WriteLine($"Interior: {sections.GetFirstLineInt("Interior")}");
Console.WriteLine($"Angle: {sections.GetFirstLineDouble("Angles")}");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("\n\n");