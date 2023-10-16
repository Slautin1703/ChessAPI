using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ChessApi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Name { get; set; }

        public int RatingAmount { get; set; }
        
        [JsonIgnore]
        public ICollection<Game> WhiteGames { get; set; } = new HashSet<Game>();
        
        [JsonIgnore]
        public ICollection<Game> BlackGames { get; set; } = new HashSet<Game>();
        
        [NotMapped]
        public ICollection<Game> AllGames
        {
            get
            {
                IEnumerable<Game> result = WhiteGames.Concat(BlackGames);
        
                return new List<Game>(result);
            }
        }
    }
};