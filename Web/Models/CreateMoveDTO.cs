namespace ChessApi.DTO;

public class CreateMoveDTO
{
    public int GameId { get; set; }
    
    public int PlayerId { get; set; }

    public string MoveText { get; set; }
    
    public DateTime timestamp { get; set; }
}