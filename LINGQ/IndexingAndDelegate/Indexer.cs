namespace LINGQ.IndexingAndDelegate
{
    internal class Indexer
    {
        List<int> IntArray = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        public int this[int index]
        {
            get => IntArray[index];
            set => IntArray[index] = value;
        }
        public int Count => IntArray.Count;
        public void ShowInfo(object message) => Console.WriteLine(message);


    }
}
