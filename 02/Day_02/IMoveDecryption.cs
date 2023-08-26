public record Row(Move Opponent, Move Me);

public interface IMoveDecryptor
{
  public Row Decrypt(string column1, string column2);
}