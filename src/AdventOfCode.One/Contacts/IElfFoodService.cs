using AdventOfCode.One.Models;

namespace AdventOfCode.One.Contacts;

public interface IElfFoodService
{
    List<ElfFoodCollection> Get();
}