using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletWatchAPI.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    [Column("first_name")]
    public string FirstName { get; set; }
    [Required]
    [Column("last_name")]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    [Column("email")]
    public string Email { get; set; }
    [Required]
    [Column("password_hash")]
    public string PasswordHash { get; set; }
    [Required]
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}