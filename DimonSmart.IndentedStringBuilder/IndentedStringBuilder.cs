using System;
using System.Text;

namespace DimonSmart.IndentedStringBuilder
{

    public class IndentedStringBuilder : IDisposable
    {
        private readonly StringBuilder _sb;
        private int _indentLevel;
        private readonly int _indentSize;
        private readonly string _openingBracket;
        private readonly string _closingBracket;
        private readonly bool _indentMultiline;

        public IndentedStringBuilder()
          : this(new IndentedStringBuilderOptions()) { }

        public IndentedStringBuilder(int capacity)
            : this(new IndentedStringBuilderOptions(capacity)) { }

        public IndentedStringBuilder(IndentedStringBuilderOptions options)
        {
            _sb = new StringBuilder(options.Capacity);
            _indentLevel = options.InitialIndent;
            _indentSize = options.IndentSize;
            _openingBracket = options.OpeningBracket;
            _closingBracket = options.ClosingBracket;
            _indentMultiline = options.IndentMultiline;
        }

        public IDisposable Indent(string line, string? openingBracket = null, string? closingBracket = null)
        {
            AppendLine(line);
            AppendLine(openingBracket ?? _openingBracket);
            _indentLevel++;
            return new IndentBlock(this, closingBracket ?? _closingBracket);
        }

        public void AppendLine(string line = "")
        {
            if (_indentMultiline)
            {
                var lines = line.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var singleLine in lines)
                {
                    _sb.AppendLine(new string(' ', _indentLevel * _indentSize) + singleLine);
                }
            }
            else
            {
                _sb.AppendLine(new string(' ', _indentLevel * _indentSize) + line);
            }
        }

        public IndentedStringBuilder Append(string text)
        {
            _sb.Append(new string(' ', _indentLevel * _indentSize) + text);
            return this;
        }

        public override string ToString()
        {
            return _sb.ToString();
        }

        public void Dispose()
        {
            if (_indentLevel > 0)
            {
                _indentLevel--;
            }
        }

        private class IndentBlock : IDisposable
        {
            private readonly IndentedStringBuilder _builder;
            private readonly string _closingBracket;
            private bool _disposed;

            public IndentBlock(IndentedStringBuilder builder, string closingBracket)
            {
                _builder = builder;
                _closingBracket = closingBracket;
            }

            public void Dispose()
            {
                if (_disposed) return;
                _builder._indentLevel--;
                _builder.AppendLine(_closingBracket);
                _disposed = true;
            }
        }
    }
}
