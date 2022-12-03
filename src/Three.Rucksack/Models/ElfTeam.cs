using Three.Rucksack.Extensions;

namespace Three.Rucksack.Models;

public record ElfTeam(List<Backpack> Backpacks)
{
    public int Priority => Badge.ToPriority();
    private char Badge 
        => Backpacks[0].Items
            .Intersect(Backpacks[1].Items)
            .Intersect(Backpacks[2].Items).First();
}