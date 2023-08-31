namespace Day_05.Test;

public class StackTests
{
    [Fact]
    public void PushAlwaysAddsFirstItem()
    {
        // Arrange
        var stack = new Stack<char>(1);
        var expectedResult = new List<char> { 'a' };


        // Act
        stack.Push('a');

        // Assert
        Assert.Equal(expectedResult, stack.GetItems());
    }

    [Fact]
    public void PushMaintainsLIFOOrdering()
    {
        // Arrange
        var stack = new Stack<char>(1);
        var expectedResult = new List<char> { 'a', 'b' };

        // Act
        stack.Push('a');
        stack.Push('b');

        // Assert
        Assert.Equal(expectedResult, stack.GetItems());
    }

    [Fact]
    public void PopAlwaysReturnsLastItem()
    {
        // Arrange
        var stack = new Stack<char>(1);
        stack.Push('a');

        // Act
        char result = stack.Pop();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void PopAlwaysTakesLatestItem()
    {
        // Arrange
        var stack = new Stack<char>(1);
        stack.Push('a');
        stack.Push('b');

        // Act
        char result = stack.Pop();

        // Assert
        Assert.Equal('b', result);
    }

    [Fact]
    public void PopAlwaysThrowsOnEmptyStack()
    {
        // Arrange
        var stack = new Stack<char>(1);

        // Act
        Action act = () => stack.Pop();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Equals_Always_ReturnsTrueForEqualStacks()
    {
        // Arrange
        var stack1 = new Stack<int>(1);
        var stack2 = new Stack<int>(1);

        for (int i = 0; i < 10; i++)
        {
            stack1.Push(i);
            stack2.Push(i);
        };

        // Act
        bool result = stack1.Equals(stack2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_Always_ReturnsFalseForChangedOrder()
    {
        // Arrange
        var stack1 = new Stack<int>(1);
        var stack2 = new Stack<int>(1);
        var stack3 = new Stack<int>(1);

        for (int i = 0; i < 10; i++)
        {
            stack1.Push(i);
            stack3.Push(i);
        };

        for (int i = 0; i < 10; i++)
        {
            stack2.Push(stack3.Pop());
        }


        // Act
        bool result = stack1.Equals(stack2);

        // Assert
        Assert.False(result);
    }
}