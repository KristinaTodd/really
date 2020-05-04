namespace Really.Models
{
  public class Home
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PrimaryImg { get; set; }
    public string SecondaryImg { get; set; }
    public int Views { get; set; }
    public int Favorites { get; set; }

  }
  public class FavoriteHomeViewModel : Home
  {
    public int FavoriteHomeId { get; set; }
  }
}