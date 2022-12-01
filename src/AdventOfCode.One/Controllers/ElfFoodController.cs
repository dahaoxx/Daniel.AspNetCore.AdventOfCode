using AdventOfCode.One.Contacts;
using AdventOfCode.One.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdventOfCode.One.Controllers;

[Route("ElfFood")]
public class ElfFoodController : ControllerBase
{
    private readonly IElfFoodService _elfFoodService;
    
    public ElfFoodController(IElfFoodService elfFoodService)
    {
        _elfFoodService = elfFoodService;
    }
    
    [HttpGet("Get")]
    public List<ElfFoodCollection> Get()
    {
        return _elfFoodService.Get();
    }
}