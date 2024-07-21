using SeztionParser;

var sections = SectionsFile.Load("Aim_Headshot.ini");

Console.WriteLine("[Alpha]");
foreach (var data in sections["Alpha"])
    Console.WriteLine(data);

Console.WriteLine();

Console.WriteLine("[Beta]");
foreach (var data in sections["Beta"])
    Console.WriteLine(data);

int interior = sections.GetFirstLineInt("Interior");
Console.WriteLine();
Console.WriteLine("[Interior]");
Console.WriteLine(interior);