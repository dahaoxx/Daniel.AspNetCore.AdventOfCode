using Three.Rucksack.Utils;
using Three.Rucksack.Extensions;

namespace Three.Rucksack.Models;

public class Backpack
{
    private readonly string _inputString;

    public Backpack(string input)
    {
        _inputString = input;
    }

    public IEnumerable<char> AllItems => _inputString;
    private IEnumerable<char> CompartmentOne => StringUtils.GetFistHalf(_inputString);
    private IEnumerable<char> CompartmentTwo => StringUtils.GetSecondHalf(_inputString);
   
    public int Priority => CompartmentsDiff().ToPriority();

    public char CompartmentsDiff()
    {
        foreach (var compartmentOneItem in CompartmentOne)
        {
            if (CompartmentTwo.Any(x => x == compartmentOneItem))
            {
                return compartmentOneItem;
            }
        }

        throw new ArgumentException();
    }
};