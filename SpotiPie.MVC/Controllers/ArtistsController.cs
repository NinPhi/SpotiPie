using Microsoft.AspNetCore.Mvc;
using SpotiPie.Application.Contracts;
using SpotiPie.Application.Services.Interfaces;

namespace SpotiPie.MVC.Controllers;

public class ArtistsController(IArtistService artistService) : Controller
{
    public async Task<IActionResult> Create()
    {
        return View();
    }

    public async Task<IActionResult> CreateForm(ArtistCreateDto artist)
    {
        await artistService.CreateAsync(artist);

        return RedirectToAction("List");
    }

    public async Task<IActionResult> List()
    {
        var artists = await artistService.GetAllAsync();

        return View(artists);
    }

    public async Task<IActionResult> DeleteForm(int id)
    {
        await artistService.DeleteAsync(id);

        return RedirectToAction("List");
    }
}
