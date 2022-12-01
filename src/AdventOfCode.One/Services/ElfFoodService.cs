using AdventOfCode.One.Contacts;
using AdventOfCode.One.Models;

namespace AdventOfCode.One.Services;

public class ElfFoodService : IElfFoodService
{
    private readonly IElfFoodScraperService _elfFoodScraper;
    
    public ElfFoodService(IElfFoodScraperService elfFoodScraper)
    {
        _elfFoodScraper = elfFoodScraper;
    }

    List<ElfFoodCollection> IElfFoodService.Get()
        => _elfFoodScraper.Scrape();
}