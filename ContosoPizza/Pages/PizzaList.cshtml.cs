using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;
using ContosoPizza.Models;
using ContosoPizza.Services;
namespace ContosoPizza.Pages;
public class PizzaListModel : PageModel
{
    [BindProperty]
    public Pizza NewPizza { get; set; } = default!;
    private readonly PizzaService _service;
    public IList<Pizza> PizzaList { get;set; } = default!;

    public PizzaListModel(PizzaService service)
    {
        _service = service;
    }

//get a pizza
    public void OnGet()
    {
        PizzaList = _service.GetPizzas();
    }

//add a new pizza
    public IActionResult OnPost()
{
    if (!ModelState.IsValid || NewPizza == null)
    {
        return Page();
    }

    _service.AddPizza(NewPizza);

    return RedirectToAction("Get");
}

//delete a pizza using id
public IActionResult OnPostDelete(int id)
{
    _service.DeletePizza(id);

    return RedirectToAction("Get");
}



}

