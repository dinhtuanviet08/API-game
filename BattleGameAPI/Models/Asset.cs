namespace BattleGameAPI.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public List<PlayerAsset> PlayerAssets { get; set; } = new List<PlayerAsset>();
    }
}
