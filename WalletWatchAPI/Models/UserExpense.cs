namespace WalletWatchAPI.Models;

public class UserExpense
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public bool IsDeleted { get; set; }
        
    public User User { get; set; }
    public Category Category { get; set; }
}