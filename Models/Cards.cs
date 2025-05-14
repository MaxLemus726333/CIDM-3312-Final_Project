namespace CIDM_3312_Final_Project.Models;

public class Card
{
    public int CardID {get; set;} // Primary Key
    public string Description {get; set;} = string.Empty;

    public List<CollectionCard>? CollectionCards {get; set;} = default!; // Navigation property.
}

public class CollectionCard
{
    public int CardID {get; set;} // Composite Primary Key, Foreign Key 1
    public int CollectionID {get; set;} // Composite Primary Key, Foreign Key 2
    public Collection Collection {get; set;} = default!; // Navigation Property
    public Card Card {get; set;} = default!; // Navigation Property
}