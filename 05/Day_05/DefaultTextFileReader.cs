public class TextFileReader : ITextFileReader
{
  public string ReadAllText(string path)
  {
    return File.ReadAllText(path);
  }
}