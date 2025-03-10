namespace DimonSmart.IndentedStringBuilder.Tests
{
    public class IndentedStringBuilderTests
    {
        [Fact]
        public void AppendLine_ShouldAppendTextWithIndent()
        {
            var builder = new IndentedStringBuilder();

            builder.AppendLine("Test");

            Assert.Equal("""
                         Test

                         """, builder.ToString());
        }

        [Fact]
        public void Indent_ShouldIncreaseIndentLevel()
        {
            var builder = new IndentedStringBuilder();
            using (builder.Indent("Block"))
            {
                builder.AppendLine("Inside");
            }

            Assert.Equal("""
             Block
             {
                 Inside
             }
             
             """, builder.ToString());
        }

        [Fact]
        public void Append_ShouldAppendTextWithoutNewline()
        {
            var builder = new IndentedStringBuilder();

            builder.Append("Hello ");
            builder.Append("World");

            Assert.Equal("Hello World", builder.ToString());
        }

        [Fact]
        public void AppendLine_ShouldRespectMultilineOption()
        {
            var builder = new IndentedStringBuilder();

            builder.AppendLine("Line1\nLine2");

            Assert.Equal("""
                Line1
                Line2
                
                """, builder.ToString());
        }

        [Fact]
        public void Dispose_ShouldCloseIndentBlock()
        {
            var builder = new IndentedStringBuilder();
            using (builder.Indent("Block"))
            {
                builder.AppendLine("Inside");
            }

            var expected = """
            Block
            {
                Inside
            }
            
            """;
            Assert.Equal(expected, builder.ToString());
        }

        [Fact]
        public void NestedIndents_ShouldHandleMultipleLevelsCorrectly()
        {
            var builder = new IndentedStringBuilder();
            using (builder.Indent("Level 1"))
            {
                builder.AppendLine("Inside Level 1");
                using (builder.Indent("Level 2"))
                {
                    builder.AppendLine("Inside Level 2");
                    using (builder.Indent("Level 3"))
                    {
                        builder.AppendLine("Inside Level 3");
                    }
                }
            }

            var expected = """
            Level 1
            {
                Inside Level 1
                Level 2
                {
                    Inside Level 2
                    Level 3
                    {
                        Inside Level 3
                    }
                }
            }
            
            """;
            Assert.Equal(expected, builder.ToString());
        }

    }
}
