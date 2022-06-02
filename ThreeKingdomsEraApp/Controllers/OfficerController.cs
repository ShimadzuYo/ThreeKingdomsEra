using Application;
using Application.Interfaces;
using Core;
using Microsoft.AspNetCore.Mvc;
using ThreeKingdomsEra.Models;

namespace ThreeKingdomsEra.Controllers;

[Route("[controller]/[action]")]
public class OfficerController : Controller
{
    private readonly IOfficerService _officerService;


    public OfficerController(IOfficerService officerService)
    {
        _officerService = officerService;
    }


    [HttpGet]
    public IActionResult List()
    {
        var officers = _officerService.GetOfficers();
        var viewModel = new OfficersListViewModel()
        {
            Officers = officers
        };
        return View(viewModel);
    }


    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Add(AddOfficerForm addOfficerForm)
    {
        var addOfficerDto = new AddOfficerDto()
        {
            Surname = addOfficerForm.Surname,
            Name = addOfficerForm.Name,
            Birth = addOfficerForm.Birth,
            Death = addOfficerForm.Death,
            Bio = addOfficerForm.Bio,
            Id = addOfficerForm.Id,
            Kingdom = addOfficerForm.Kingdom
        };
        var id = _officerService.AddOfficer(addOfficerDto);
        return RedirectToAction("List", new { id });
    }

    [HttpGet("{id:int}")]

    public IActionResult Edit(int id)
    {
        var officer = _officerService.GetOfficerById(id);
        var viewForm = new EditOfficerForm()
        {
            Name = officer.Name,
            Surname = officer.Surname,
            Birth = officer.Birth,
            Death = officer.Death,
            Kingdom = officer.Kingdom,
            Bio = officer.Bio,
        };
        return View(viewForm);
    }
    


    [HttpPost("{id:int}")]

    public IActionResult Edit(int id, EditOfficerForm editOfficerForm)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var editOfficerDto = new EditOfficerDto()
        {
            Surname = editOfficerForm.Surname,
            Name = editOfficerForm.Name,
            Birth = editOfficerForm.Birth,
            Death = editOfficerForm.Death,
            Kingdom = editOfficerForm.Kingdom,
            Bio = editOfficerForm.Bio
        };

        _officerService.EditOfficer(id, editOfficerDto);
        return RedirectToAction("List");

    }


    public IActionResult Details(int id)
    {
        var officer = _officerService.GetOfficerById(id);
        if (officer is null)
        {
            return RedirectToAction(nameof(List));
        }
        var viewModel = new OfficerDetailsViewModel()
        {
            Officer = officer
        };
        
        return View(viewModel);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _officerService.DeleteOfficer(id);
        return Ok();
    }
}