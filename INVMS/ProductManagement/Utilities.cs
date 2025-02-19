namespace INVMS.ProductManagement
{
    internal class Utilities <T>
    {

        public delegate bool TryParseHandler(string? input, out T result);

        public static T GetNumber(string message, TryParseHandler tph)
        {
            bool isValid = false;
            T value ;
            do
            {
                Console.WriteLine(message);
                string? inputValue = Console.ReadLine();
                isValid = tph(inputValue, out value);
                if (! isValid)
                {
                    Console.WriteLine("!!! Invalid number value !!!");
                }

            } while (!isValid);
            return value;

        }
    }
}
