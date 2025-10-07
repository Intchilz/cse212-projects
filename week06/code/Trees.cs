public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();

        if (sortedNumbers.Length > 0)
        {
            InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        }

        return bst;
    }

    // 🟩 Problem 5: Create Tree from Sorted List
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return;

        int mid = (first + last) / 2;
        bst.Insert(sortedNumbers[mid]);

        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
