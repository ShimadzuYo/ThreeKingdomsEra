using Application;
using Application.Interfaces;
using Core;
using Infrastructure.EntityFramework;

namespace Infrastructure.Services;

public class OfficerService: IOfficerService
{
    private readonly ApplicationDbContext _dbContext;


    public OfficerService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public List<Officer> GetOfficers()
    {
        var officers = _dbContext.Officers;
        var result = officers.ToList();
        return result;
    }

    public Officer GetOfficerById(int id)
    {
        var officer = _dbContext.Officers.FirstOrDefault(x => x.Id == id);
        return officer;
    }


    public int AddOfficer(AddOfficerDto addOfficerDto)
    {
        if (addOfficerDto is null)
            throw new ArgumentNullException(nameof(addOfficerDto));
        var officer = new Officer()
        {
            Id = addOfficerDto.Id,
            Name = addOfficerDto.Name,
            Surname = addOfficerDto.Surname,
            Birth = addOfficerDto.Birth,
            Death = addOfficerDto.Death,
            Bio = addOfficerDto.Bio,
            Kingdom = addOfficerDto.Kingdom
        };
        _dbContext.Officers.Add(officer);
        _dbContext.SaveChanges();
        return officer.Id;
    }

    public void EditOfficer(int id, EditOfficerDto editOfficerDto)
    {
        var officer = _dbContext.Officers.FirstOrDefault(x => x.Id == id);
        if (officer == null) 
            throw new ArgumentException("Officer not found!");
        officer.Name = editOfficerDto.Name;
        officer.Surname = editOfficerDto.Surname;
        officer.Birth = editOfficerDto.Birth;
        officer.Death = editOfficerDto.Death;
        officer.Kingdom = editOfficerDto.Kingdom;
        officer.Bio = editOfficerDto.Bio;

        _dbContext.SaveChanges();

    }


    public void DeleteOfficer(int id)
    {
        var officer = _dbContext.Officers.FirstOrDefault(x => x.Id == id);
        _dbContext.Officers.Remove(officer);
        _dbContext.SaveChanges();
    }
    
    
}