namespace MissingNumberApp.Finders {
    public class MissingNumberFinder : IMissingNumberFinder {
        public int FindMissingNumber(int[] numbers) {
            int n = numbers.Length;
            int expectedMax = numbers.Length;
            int expectedSum = expectedMax * (expectedMax + 1) / 2;
            int actualSum = numbers.Sum();
            return expectedSum - actualSum;
        }
    }
}
