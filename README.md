# IndentedStringBuilder

A lightweight and flexible utility for building strings with automatic indentation and customizable formatting. This NuGet package simplifies the generation of indented code blocks, configuration files, or any structured text output.

## Features

- **Automatic Indentation Management:** Easily manage indentation levels when generating multi-line strings.
- **Configurable Settings:** Customize initial indent, indent size, and capacity.
- **Customizable Brackets:** Define your own opening and closing brackets for indented blocks.
- **Multi-line Support:** Optionally indent each line in a multi-line string.
- **Scoped Indentation:** Utilize disposable indentation blocks to automatically handle indentation scopes.

## Installation

Install the package via the .NET CLI:

```bash
dotnet add package DimonSmart.IndentedStringBuilder
```

## Usage

Below is a minimal example of how to use the IndentedStringBuilder:

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
  Appends a new line with the current indentation. Supports multi-line strings when enabled.

- **`Append(string text)`**  
  Appends text with the current indentation.

- **`Indent(string line, string? openingBracket = null, string? closingBracket = null)`**  
  Starts an indented block by appending the given line and an opening bracket. Increases the indentation level until the returned `IDisposable` is disposed, at which point the closing bracket is appended and the indentation is decreased.

- **`ToString()`**  
  Returns the composed string with all applied indentations and formatting.

## License

This project is licensed under the [0BSD License](LICENSE).
