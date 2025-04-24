using MissingNumberApp.Services;
using MissingNumberApp.Finders;

namespace MissingNumberApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter numbers separated by commas (e.g. 3,0,1):");
            string input = Console.ReadLine();
            
            if(input.Trim().Equals("")){
                Console.WriteLine("Invalid Input. Enter values");
                return;
            }

            int[] nums;
            try {
                nums = input.Split(',')
                            .Select(s => int.Parse(s.Trim()))
                            .ToArray();
            }
            catch {
                Console.WriteLine("Invalid input. Please enter only integers separated by commas.");
                return;
            }
            if (nums.Length != nums.Distinct().Count() || nums.Any(n => n < 0 || n > nums.Length)) {
                Console.WriteLine("Invalid input. Make there are no duplicates, within the range 0 to n and only one value is missing");
                return;
            }
            if(nums.Length == 1){
                Console.WriteLine("Only one number entered. No missing number detected");
                return;
            }
            IMissingNumberFinder finder = new MissingNumberFinder();
            int missingNumber = finder.FindMissingNumber(nums);
            var missingNumberService = new MissingNumberService();
            missingNumberService.PrintMissingNumber(missingNumber);
        }
    }
}
