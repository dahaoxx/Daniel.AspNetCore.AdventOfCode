using AdventOfCode.One.Contacts;
using AdventOfCode.One.Models;
using HtmlAgilityPack;

namespace AdventOfCode.One.Services;

public sealed class ElfFoodScraperService : IElfFoodScraperService
{
    List<ElfFoodCollection> IElfFoodScraperService.Scrape()
    {
        var document = new HtmlWeb().Load("https://adventofcode.com/2022/day/1/input");
        var nodes = document.DocumentNode.SelectNodes("//pre").Select(x => x.InnerText);

        return new List<ElfFoodCollection>();
    }
}