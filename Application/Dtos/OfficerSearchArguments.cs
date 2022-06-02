namespace Application;

public class OfficerSearchArguments
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly Birth { get; set; }
    public DateOnly Death { get; set; }
    public string Kingdom { get; set; }
    public string Bio { get; set; }
}