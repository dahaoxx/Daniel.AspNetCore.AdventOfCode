namespace Template.Services;

public static class TemplateService
{
    #region Part 1

    public static int Part1(string inputFileName)
    {
        var lines = File.ReadAllLines(inputFileName);
        var treeMatrix = CreateTreeMatrix(lines);

        return treeMatrix
            .Select((treeRow, rowIndex) 
                => treeRow
                    .Select((tree, columnIndex) 
                        => IsVisible(tree, rowIndex, columnIndex, treeMatrix))
                    .Count(isVisible => isVisible))
            .Sum();
    }
    
    private static List<List<int>> CreateTreeMatrix(IEnumerable<string> lines) 
        => lines.Select(line => line.Select(tree => int.Parse(tree.ToString())).ToList()).ToList();

    private static bool IsVisible(int currentTree, int rowIndex, int columnIndex, IReadOnlyList<List<int>> treeMatrix) 
        => IsVisibleFromNorth(currentTree, rowIndex, columnIndex, treeMatrix) ||
           IsVisibleFromEast(currentTree, rowIndex, columnIndex, treeMatrix)  ||
           IsVisibleFromSouth(currentTree, rowIndex, columnIndex, treeMatrix) ||
           IsVisibleFromWest(currentTree, rowIndex, columnIndex, treeMatrix);

    private static bool IsVisibleFromNorth(int tree, int targetRowIndex, int targetColumnIndex, IReadOnlyList<List<int>> treeMatrix)
    {
        for (var currentRowIndex = 0; currentRowIndex < targetRowIndex; currentRowIndex++)
        {
            var currentTree = treeMatrix[currentRowIndex][targetColumnIndex];
            if (currentTree >= tree)
            {
                return false;
            }
        }

        return true;
    }
    
    private static bool IsVisibleFromEast(int tree, int targetRowIndex, int targetColumnIndex, IReadOnlyList<List<int>> treeMatrix)
    {
        var targetRow = treeMatrix[targetRowIndex];
        for (var currentColumnIndex = targetColumnIndex + 1; currentColumnIndex < targetRow.Count; currentColumnIndex++)
        {
            var currentTree = treeMatrix[targetRowIndex][currentColumnIndex];
            if (currentTree >= tree)
            {
                return false;
            }
        }

        return true;
    }
    
    private static bool IsVisibleFromSouth(int tree, int targetRowIndex, int targetColumnIndex, IReadOnlyList<List<int>> treeMatrix)
    {
        for (var currentRowIndex = treeMatrix.Count - 1; currentRowIndex > targetRowIndex; currentRowIndex--)
        {
            var currentTree = treeMatrix[currentRowIndex][targetColumnIndex];
            if (currentTree >= tree)
            {
                return false;
            }
        }

        return true; 
    }
    
    private static bool IsVisibleFromWest(int tree, int targetRowIndex, int targetColumnIndex, IReadOnlyList<List<int>> treeMatrix)
    {
        for (var currentColumnIndex = targetColumnIndex - 1; currentColumnIndex >= 0; currentColumnIndex--)
        {
            var currentTree = treeMatrix[targetRowIndex][currentColumnIndex];
            if (currentTree >= tree)
            {
                return false;
            }
        }

        return true;
    }

    #endregion
    
    #region Part 2
    
    public static int Part2(string inputFileName)
    {
        return 2;
    }
    
    #endregion
}