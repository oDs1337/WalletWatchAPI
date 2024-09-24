namespace WalletWatchAPI.Models;

public class Category
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CategoryName { get; set; }
    public DateTime created_at { get; set; }
    
    public User User { get; set; }
}