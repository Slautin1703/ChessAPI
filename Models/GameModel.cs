using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ChessApi.Models
{
    public class Game: BaseModel
    {
        public int WhiteUserId { get; set; }
        
        public int BlackUserId { get; set; }
        
        [ForeignKey("WhiteUserId")]
        [JsonIgnore]
        public User? WhiteUser { get; set; }
        
        [ForeignKey("BlackUserId")]
        [JsonIgnore]

        public User? BlackUser { get; set; }
    }
};