using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CIDM_3312_Final_Project.Models;

public class Collection
{
    public int CollectionID {get; set;} // Primary Key

    [Display(Name = "First Name")]
    public string FirstName {get; set;} = string.Empty;
    
    [Display(Name = "Last Name")]
    public string LastName {get; set;} = string.Empty;

    [Display(Name = "Cards in Collection")]
    public List<CollectionCard>? CollectionCards {get; set;} = default!;
}