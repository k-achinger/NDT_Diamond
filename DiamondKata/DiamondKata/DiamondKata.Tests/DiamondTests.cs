using System;
using System.IO;
using Xunit;

namespace DiamondKata.Tests;

public class DiamondTests
{
    [Theory]
    [InlineData(' ')]
    [InlineData('\n')]
    [InlineData('\0')]
    [InlineData('ą')]
    [InlineData('Ą')]
    [InlineData('Ø')]
    public void WriteTo_WillThrowArgumentException_WhenCharacterIsNotLatinLetter(char c)
    {
        var exception = Assert.Throws<ArgumentException>(
            () => Diamond.WriteToString(c));

        Assert.Equal("letter", exception.ParamName);
    }

    [Theory]
    [InlineData(' ')]
    [InlineData('\n')]
    [InlineData('\0')]
    [InlineData('ą')]
    [InlineData('Ą')]
    [InlineData('Ø')]
    public void WriteToString_WillThrowArgumentException_WhenCharacterIsNotLatinLetter(char c)
    {
        var exception = Assert.Throws<ArgumentException>(
            () => Diamond.WriteTo(c, new StringWriter()));

        Assert.Equal("letter", exception.ParamName);

    }

    [Theory]
    [InlineData('a')]
    [InlineData('A')]
    public void WillWriteDiamond_ForA(char a)
    {
        var result = Diamond.WriteToString(a);
        Assert.Equal(
@"A
", result);
    }

    [Theory]
    [InlineData('b')]
    [InlineData('B')]
    public void WillWriteDiamond_ForB(char b)
    {
        var result = Diamond.WriteToString(b);
        Assert.Equal(
@" A 
B B
 A 
", result);
    }

    [Theory]
    [InlineData('c')]
    [InlineData('C')]
    public void WillWriteDiamond_ForC(char c)
    {
        var result = Diamond.WriteToString(c);
        Assert.Equal(
@"  A  
 B B 
C   C
 B B 
  A  
", result);
    }

    [Fact]
    public void WillWriteDiamond_ViaWriter()
    {
        using var writer = new StringWriter();
        Diamond.WriteTo('C', writer);
        
        Assert.Equal(
@"  A  
 B B 
C   C
 B B 
  A  
", writer.ToString());
    }
}