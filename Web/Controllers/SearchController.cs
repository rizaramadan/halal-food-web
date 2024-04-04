using System.Diagnostics;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;
public class SearchController(IRestoRepo restoRepo, RestoFinder Finder) : Controller
{
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Index()
    {
        var wilayah = await restoRepo.WilayahList();
        var categories = await restoRepo.CategoryList();
        var pageModel = new SearchPageModel(wilayah, categories);
        return View(pageModel);
    }

    [HttpPost]
    public async Task<IActionResult> Search([FromForm] CompleteSearchParam param)
    {
        var restos = await Finder.FindResto(param);
        return View(restos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
