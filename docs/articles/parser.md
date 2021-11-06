# Parser

You can also gets the section data using the parser.

You must import all namespace types:
```cs
using SeztionParser.Providers;
```

You must use the `Parse` method of the `SectionsParser` class to return an instance of type `ISectionsData`:
```cs
var parser = new SectionsParser();
var sections = parser.Parse(File.ReadAllText("test.ini"));
```
You can also customize the parser by inheriting from `SectionsParser` and override methods such as: `IsComment`, `IsSection` and `ExtractSection`.

**Example:**
```cs
class CustomParser : SectionsParser
{
    public override string ExtractSection(string text)
    {
        //You can propose your own implementation..
    }
}
```

## Parser rules

**1.** If the line begins with the `#` character, it is considered a **comment**. The line may have spaces at the starts, the parser will ignore it.

**Example:**
```ini
# comment
   # comment
```

**2.** Any line with whitespace will be ignored by the parser.

**3.** The name of a section cannot be empty or have only blanks.

**Example:**
```ini
[]
[    ]
```

**4.** There can be no lines that are not part of any section, unless they are comments.

**Example:**

*Bad:*
```ini
foofoo
[mysection]
1
2
```

*Good:*
```ini
# foofoo
[mysection]
1
2
```

**5.** If the section has spaces at the beginning and at the end, the parser ignores it.

**Example:**
```ini
    [section]      
1
2  
```

**6.** A section cannot be without data, the parser will throw an error.

**Example:**
```ini
[section]
#empty
[section2]
#empty
```

**7.** The name of the section can have spaces at the beginning and at the end.

**Example:**
```ini
[  section1  ]
1
[section2  ]
2
```

**8.** A repeated section is not allowed.

**Example:**

*Bad:*
```ini
[section1]
1
[section1]
2
```
*Good:*
```ini
[section1]
1
[section2]
2
```
**9.** If the **data source** (such as a **file**) is empty or has only blanks, the parser will throw an error.