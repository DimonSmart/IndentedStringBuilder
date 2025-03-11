# IndentedStringBuilder

This package is a wrapper around `StringBuilder`, designed to simplify the creation of indented text (such as code).  
Check out the usage examples – it’s easy to understand!  

## Features

- **Automatic Indentation with `using`:** Simply wrap an indented block in a `using` statement.  
- **Configurable Settings:** Customize the initial indent, indent size, and `StringBuilder` capacity.  
- **Customizable Brackets:** Define your own bracket style for indented blocks.  
- **Multi-line Support:** Automatically indent each line of a multi-line string.  
- **Scoped Indentation:** Supports nested indentation blocks. 

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
