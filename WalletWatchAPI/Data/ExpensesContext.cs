using Microsoft.EntityFrameworkCore;
using WalletWatchAPI.Models;

namespace WalletWatchAPI.Data;

public class ExpensesContext : DbContext
{
    public ExpensesContext(DbContextOptions<ExpensesContext> options) : base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserExpense> UserExpenses { get; set; }
}