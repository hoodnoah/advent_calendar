namespace Day_04.Test;

public class CleaningRangeTest
{
    [Fact]
    public void AlwaysInstantiatesFromIntCorrectly()
    {
        // Arrange
        int start = 1;
        int end = 2;

        // Act
        var cleaningRange = new CleaningRange(start, end);

        // Assert
        Assert.Equal(start, cleaningRange.GetStart());
        Assert.Equal(end, cleaningRange.GetEnd());
    }

    [Fact]
    public void AlwaysInstantiatesFromStringCorrectly()
    {
        // Arrange
        string range = "1-2";

        // Act
        var cleaningRange = new CleaningRange(range);

        // Assert
        Assert.Equal(1, cleaningRange.GetStart());
        Assert.Equal(2, cleaningRange.GetEnd());
    }

    [Fact]
    public void AlwaysDetectsFullOverlap()
    {
        // Arrange
        var cleaningRange = new CleaningRange(1, 2);
        var other = new CleaningRange(1, 4);

        // Act
        bool result = cleaningRange.CompletelyOverlaps(other);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AlwaysDetectsFullOverlapReversed()
    {
        // Arrange
        var cleaningRange = new CleaningRange(1, 4);
        var other = new CleaningRange(1, 2);

        // Act
        bool result = cleaningRange.CompletelyOverlaps(other);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NeverDetectsFullOverlapForPartialOverlap()
    {
        // Arrange
        var cleaningRange = new CleaningRange(1, 3);
        var other = new CleaningRange(2, 4);

        // Act
        bool result = cleaningRange.CompletelyOverlaps(other);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void PartiallyOverlapsAlwaysDetectsPartialOverlap()
    {
        // Arrange
        var cleaningRange = new CleaningRange(1, 3);
        var other = new CleaningRange("2-4");

        // Act
        bool result = cleaningRange.PartiallyOverlaps(other);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void PartiallyOverlapsAlwaysDetectsPartialOverlapReversed()
    {
        // Arrange
        var cleaningRange = new CleaningRange(2, 4);
        var other = new CleaningRange("1-3");

        // Act
        bool result = cleaningRange.PartiallyOverlaps(other);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void PartiallyOverlapsAlwaysReturnsExampleCorrectly()
    {
        // Arrange
        var pairOne = new CleaningPair(new CleaningRange("2-4"), new CleaningRange("6-8"));
        var pairTwo = new CleaningPair(new CleaningRange("2-3"), new CleaningRange("4-5"));
        var pairThree = new CleaningPair(new CleaningRange("5-7"), new CleaningRange("7-9"));
        var pairFour = new CleaningPair(new CleaningRange("2-8"), new CleaningRange("3-7"));
        var pairFive = new CleaningPair(new CleaningRange("6-6"), new CleaningRange("4-6"));
        var pairSix = new CleaningPair(new CleaningRange("2-6"), new CleaningRange("4-8"));

        var pairs = new CleaningPair[] { pairOne, pairTwo, pairThree, pairFour, pairFive, pairSix };

        bool[] expectedResults = new bool[] { false, false, true, true, true, true };

        // Act
        bool[] results = pairs.Select(pair =>
        {
            return pair?.GetFirst()?.PartiallyOverlaps(pair.GetSecond()) ?? false;
        }).ToArray();
    }

    [Fact]
    public void PartiallyOverlapsAlwaysDetectsLaggingOverlap()
    {
        // Arrange
        var first = new CleaningRange("10-20");
        var second = new CleaningRange("16-17");

        // Act
        bool result = first.PartiallyOverlaps(second);

        // Assert
        Assert.True(result);
    }
}