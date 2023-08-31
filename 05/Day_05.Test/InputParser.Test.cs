public class MockTextFileReader : ITextFileReader
{
  readonly string _returnText;
  public MockTextFileReader(string returnText)
  {
    _returnText = returnText;
  }
  public string ReadAllText(string _)
  {
    return _returnText;
  }
}

public class InputParserTests
{
  [Fact]
  public void ParseInput_Always_ParsesExampleStacksCorrectly()
  {
    // Arrange
    var input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

    var mockReader = new MockTextFileReader(input);
    var parser = new InputParser(mockReader);

    // Setup stacks
    var stack1 = new Stack<char>(1);
    var stack2 = new Stack<char>(2);
    var stack3 = new Stack<char>(3);

    stack1.Push('Z');
    stack1.Push('N');

    stack2.Push('M');
    stack2.Push('C');
    stack2.Push('D');

    stack3.Push('P');

    // Act
    Ship result = parser.ParseInput("dummy path");
    Stack<char> resultStack1 = result.GetStack(1);
    Stack<char> resultStack2 = result.GetStack(2);
    Stack<char> resultStack3 = result.GetStack(3);

    // Assert
    Assert.True(stack1.Equals(resultStack1));
    Assert.True(stack2.Equals(resultStack2));
    Assert.True(stack3.Equals(resultStack3));
  }
}