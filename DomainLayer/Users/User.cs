﻿namespace DomainLayer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Users")]
public class User
{
    public User() => Id = Guid.NewGuid();

    [Key, Column("UserId")]
    public Guid Id { get; init; }

    [MaxLength(100)]
    public string UserName { get; set; }

    [MaxLength(250)]
    public string Password { get; set; }

    [MaxLength(100)]
    public string NameIdentifier { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    public bool ForcePasswordChange { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool IsEnabled { get; set; } = true;

    public bool IsDeleted { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}
