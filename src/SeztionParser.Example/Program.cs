using SeztionParser;

ISectionsData sections = SectionsFile.Load("Aim_Headshot.ini");

Console.WriteLine("[Alpha]");
ISectionData alphaSection = sections["Alpha"];
foreach (string data in alphaSection)
    Console.WriteLine(data);

Console.WriteLine();

Console.WriteLine("[Beta]");
ISectionData betaSection = sections["Beta"];
foreach (string data in betaSection)
    Console.WriteLine(data);

int interior = sections.GetFirstLineInt("Interior");
Console.WriteLine();
Console.WriteLine("[Interior]");
Console.WriteLine(interior);