# IndentedStringBuilder

This package is a StringBuilder wrapper.
Main purpose is to automate indented texts (code) creation.
Look at the ussage exampples - it's easy to understand.

## Features

- **Automatic (with using) Indentation:** Just wrap indented block into using statement.
- **Configurable Settings:** Customize initial indent, indent size, and initial StingBuilder capacity.
- **Customizable Brackets:** Define your own brackets style for indented blocks.
- **Multi-line Support:** Option to indent each line in a multi-line string.
- **Scoped Indentation:** It's possible to use folded indention blocks.

## Installation

Install the package via the .NET CLI:

```bash
dotnet add package DimonSmart.IndentedStringBuilder
```

## Usage

Minimal example of the IndentedStringBuilder usage:

```csharp
using DimonSmart.IndentedStringBuilder;
var builder = new IndentedStringBuilder();

using (builder.Indent("Block"))
{
    builder.AppendLine("Inside");
}

Console.WriteLine(builder.ToString());
```

This produces the following output:

```plaintext
Block
{
    Inside
}
```

## API Overview

- **`AppendLine(string line = "")`**  
  Appends a new line with the current indentation. Supports multi-line strings when option enabled.

- **`Append(string text)`**  
  Appends text with the current indentation.

- **`Indent(string line, string? openingBracket = null, string? closingBracket = null)`**  
  Starts an indented block by appending the given line and an opening bracket.
  Increases the indentation level until the returned `IDisposable` is disposed (end of using block),
  at which point the closing bracket is appended and the indentation is decreased.

- **`ToString()`**  
  Underling StringBuidler ToString().

## Important note about Source Generators
As source generators nugets are very specific you can face some issues while using indenter-package with
your source generator nuget. The problem is that the source generator nuget is not able to find the indenter-package
Please check the [BuilderGenerator](https://github.com/DimonSmart/BuilderGenerator) project which is using IndentedStringBuilder internally for
generated code formatting.

## License

This project is licensed under the [0BSD License](LICENSE).
Feel free to use code in your projects.
