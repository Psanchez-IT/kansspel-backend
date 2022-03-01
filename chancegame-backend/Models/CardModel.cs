using System.ComponentModel.DataAnnotations;

namespace chancegame_backend.Models
{
    public class CardModel
    {
        [Key]
        public int cardId { get; set; }
        public int cardValue { get; set; }
        public bool isClicked { get; set; }
    }
}
