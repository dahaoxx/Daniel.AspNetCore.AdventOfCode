using Three.Rucksack.Extensions;

namespace Three.Rucksack.Models;

public class ElfTeam
{
    public ElfTeam(List<Backpack> backpacks)
    {
        Backpacks = backpacks;
    }
    public int Priority => Badge.ToPriority();

    private char Badge => CommonItem();

    private List<Backpack> Backpacks { get; }
    private Backpack ElfOne => Backpacks[0];
    private Backpack ElfTwo => Backpacks[1];
    private Backpack ElfThree => Backpacks[2];

    private char CommonItem()
    {
        return ElfOne.AllItems
            .Intersect(ElfTwo.AllItems)
            .Intersect(ElfThree.AllItems).First();
    }
}