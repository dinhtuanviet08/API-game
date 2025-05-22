namespace BattleGameAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }

        public List<PlayerAsset> PlayerAssets { get; set; } = new List<PlayerAsset>();

    }
}
