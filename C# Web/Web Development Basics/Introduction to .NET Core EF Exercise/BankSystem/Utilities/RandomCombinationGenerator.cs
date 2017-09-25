namespace BankSystem.Utilities
{
    using System;

    public static class RandomCombinationGenerator
    {
        private const int Length = 10;
        private const int AscciStartPositionOfNumbers = 48;
        private const int AsciiEndPostionOfNumbers = 58;
        private const int AsciiStartPositionOfLetters = 65;
        private const int AsciiEndPositionOfLetters = 91;

        /// <summary>
        /// Generate string with random combination of 10 uppercase letters and digits.
        /// </summary>
        /// <returns></returns>
        public static string Generate()
        {
            string randomCombination = null;
            Random rnd = new Random();
            for (int i = 0; i < Length; i++)
            {
                if (rnd.Next(0, 10) % 2 == 0)
                {
                    randomCombination += (char)rnd.Next(AscciStartPositionOfNumbers, AsciiEndPostionOfNumbers);
                }
                else
                {
                    randomCombination += (char)rnd.Next(AsciiStartPositionOfLetters, AsciiEndPositionOfLetters);
                }
            }

            return randomCombination;
        }
    }
}
