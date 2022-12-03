using One.ElfCalories.Exceptions;
using Three.Rucksack.Extensions;

namespace Three.Rucksack.Models;

public record Backpack(string Items) 
{
    public int Priority => GetMisplacedItem().ToPriority();

    public char GetMisplacedItem()
    {
        foreach (var compartmentOneItem in Items.FistHalf())
        {
            if (Items.SecondHalf().Any(x => x == compartmentOneItem))
            {
                return compartmentOneItem;
            }
        }

        throw new ElfIsLyingException();
    }
};