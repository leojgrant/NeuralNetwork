namespace NeuralNetwork.ConsoleApp.Utilities
{
    public static class HelperFunctions
    {
        public static List<double> ExtractNumbersFromString(String userInput)
        {
            userInput = userInput + "-end";
            string number = "";
            List<double> numbers = new List<double>();
            foreach (char c in userInput)
            {
                if (Char.IsDigit(c))
                {
                    number = number + c;
                }
                else if (number != "")
                {
                    numbers.Add(Convert.ToDouble(number));
                    number = "";
                }
            }
            return numbers;
        }
    }
}
