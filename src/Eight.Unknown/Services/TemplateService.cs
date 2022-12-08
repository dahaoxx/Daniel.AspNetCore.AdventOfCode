namespace Template.Services;

public static class TemplateService
{
    #region Part 1

    public static int Part1(string inputFileName)
    {
        var lines = File.ReadAllLines(inputFileName);
        var treeMatrix = CreateTreeMatrix(lines);

        var visibleTrees = 0;
        for (var rowIndex = 0; rowIndex < treeMatrix.Count; rowIndex++)
        {
            var treeRow = treeMatrix[rowIndex];
            for (var columnIndex = 0; columnIndex < treeRow.Count; columnIndex++)
            {
                var isVisible = IsVisible(treeRow[columnIndex], rowIndex, columnIndex, treeMatrix);
                if (isVisible)
                {
                    visibleTrees++;
                }
            }
        }

        return visibleTrees;
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
        var lines = File.ReadAllLines(inputFileName);
        var treeMatrix = CreateTreeMatrix(lines);

        var highestScenicScore = 0;
        for (var rowIndex = 0; rowIndex < treeMatrix.Count; rowIndex++)
        {
            var treeRow = treeMatrix[rowIndex];
            for (var columnIndex = 0; columnIndex < treeRow.Count; columnIndex++)
            {
                var currentScenicScore = GetScenicScore(treeRow[columnIndex], rowIndex, columnIndex, treeMatrix);
                if (currentScenicScore > highestScenicScore)
                {
                    highestScenicScore = currentScenicScore;
                }
            }
        }

        return highestScenicScore;
    }

    private static int GetScenicScore(int currentTree, int rowIndex, int columnIndex, IReadOnlyList<List<int>> treeMatrix)
    {
        return ScenicScoreInNorth(currentTree, rowIndex, columnIndex, treeMatrix) *
               ScenicScoreInEast(currentTree, rowIndex, columnIndex, treeMatrix) *
               ScenicScoreInSouth(currentTree, rowIndex, columnIndex, treeMatrix) *
               ScenicScoreInWest(currentTree, rowIndex, columnIndex, treeMatrix);
    }


    private static int ScenicScoreInNorth(int tree, int targetRowIndex, int targetColumnIndex, IReadOnlyList<List<int>> treeMatrix)
    {
        var currentScenicScore = 0;
        for (var currentRowIndex = targetRowIndex - 1; currentRowIndex >= 0; currentRowIndex--)
        {
            currentScenicScore++;
            var currentTree = treeMatrix[currentRowIndex][targetColumnIndex];
            if (currentTree < tree) continue;
            
            return currentScenicScore;
        }
        return currentScenicScore;
    }
    
    private static int ScenicScoreInEast(int tree, int targetRowIndex, int targetColumnIndex, IReadOnlyList<List<int>> treeMatrix)
    {
        var currentScenicScore = 0;
        var targetRow = treeMatrix[targetRowIndex];
        for (var currentColumnIndex = targetColumnIndex + 1; currentColumnIndex < targetRow.Count; currentColumnIndex++)
        {
            currentScenicScore++;
            var currentTree = treeMatrix[targetRowIndex][currentColumnIndex];
            if (currentTree < tree) continue;
            
            return currentScenicScore;
        }
        return currentScenicScore;
    }
    
    private static int ScenicScoreInSouth(int tree, int targetRowIndex, int targetColumnIndex, IReadOnlyList<List<int>> treeMatrix)
    {
        var currentScenicScore = 0;
        for (var currentRowIndex = targetRowIndex + 1; currentRowIndex < treeMatrix.Count; currentRowIndex++)
        {
            currentScenicScore++;
            var currentTree = treeMatrix[currentRowIndex][targetColumnIndex];
            if (currentTree < tree) continue;
            
            return currentScenicScore;
        }
        return currentScenicScore;
    }
    
    private static int ScenicScoreInWest(int tree, int targetRowIndex, int targetColumnIndex, IReadOnlyList<List<int>> treeMatrix)
    {
        var currentScenicScore = 0;
        for (var currentColumnIndex = targetColumnIndex - 1; currentColumnIndex >= 0; currentColumnIndex--)
        {
            currentScenicScore++;
            var currentTree = treeMatrix[targetRowIndex][currentColumnIndex];
            if (currentTree < tree) continue;
            
            return currentScenicScore;
        }
        return currentScenicScore;
    }
    
    #endregion
}