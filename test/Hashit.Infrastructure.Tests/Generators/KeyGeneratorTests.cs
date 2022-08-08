public sealed class KeyGeneratorTests
{
    [Fact]
    public void ShouldGenerate256BitKey()
    {
        // arrange
        var generator = new KeyGenerator();

        // act
        var key = generator.Generate256BitKey();

        // assert
        key.Should().NotBeNullOrWhiteSpace();
        key.Length.Should().Be(44);
        var bytes = Convert.FromBase64String(key);
        bytes.Length.Should().Be(32);
    }

    [Fact]
    public void ShouldGenerateMultipleUnique256BitKey()
    {
        // arrange
        var generator = new KeyGenerator();
        var count = 500;

        // act
        var keys = Enumerable.Range(0, count).Select(i => generator.Generate256BitKey());

        // assert
        keys.Should().HaveCount(count);
        keys.Should().OnlyHaveUniqueItems();
    }
}
