using AdventOfCode.One.Models;

namespace AdventOfCode.One.Contacts;

public interface IElfFoodScraperService
{ 
    List<ElfFoodCollection> Scrape();
}