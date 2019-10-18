using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FinalExams.Models{
public class User
{
    [Key]
    public int UserId {get;set;}
    [Required]
    public string FirstName {get;set;}
    [Required (ErrorMessage="Please enter a real name MF")]
    public string LastName {get;set;}
    [EmailAddress]
    [Required]
    public string Email {get;set;}

    [DataType(DataType.Password)]
    [Required]
    [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
    public string Password {get;set;}

    public List<Association> peopleWhoLiked{get;set;}
    public List<Idea> createdIdeas{get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    // Will not be mapped to your users table!
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string Confirm {get;set;}
}

public class LoginUser
{
    // No other fields!
    [EmailAddress]
    [Required]
    public string Email {get; set;}


    [DataType(DataType.Password)]
    [Required]
    [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
    public string Password { get; set; }
}

public class Idea{
    [Key]
    public int IdeaId{get;set;}

    [Required]
    [MinLength(5)]
    public string Description{get;set;}

    [Required]
    public int UserId{get;set;}

    public User creator{get;set;}
    public List<Association> people{get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}

public class Association{
    public int AssociationId{get;set;}
    public int IdeaId{get;set;}

    public int UserId{get;set;}

    public Idea Idea{get;set;}
    public User User{get;set;}

    public int inside{get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}


}