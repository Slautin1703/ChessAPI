using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessApi.Models
{
    public class Move
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public int PlayerId { get; set; }
        
        [ForeignKey("PlayerId")]
        public User Player { get; set; }

        [Required]
        public string MoveText { get; set; }
        
        [Required]
        public DateTime Timestamp { get; set; }
    }

}




