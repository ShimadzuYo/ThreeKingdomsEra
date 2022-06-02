using Core;

namespace Application.Interfaces;

public interface IOfficerService
{
    public List<Officer> GetOfficers();

    public int AddOfficer(AddOfficerDto addOfficerDto);

    public void EditOfficer(int id, EditOfficerDto editOfficerDto);

    public Officer GetOfficerById(int id);

    public void DeleteOfficer(int id);
}