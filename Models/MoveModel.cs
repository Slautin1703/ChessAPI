using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ChessApi.Models
{
    public class Move
    {
        public int Id { get; set; }
        
        [Required]
        public int GameId { get; set; }
        
        [Required]
        public int PlayerId { get; set; }
        
        [ForeignKey("GameId")]
        [JsonIgnore]
        public Game Game { get; set; }
        
        [ForeignKey("PlayerId")]
        [JsonIgnore]
        public User Player { get; set; }
        
        [Required]
        public string MoveText { get; set; }
        
        [Required]
        public DateTime Timestamp { get; set; }
    }

}




