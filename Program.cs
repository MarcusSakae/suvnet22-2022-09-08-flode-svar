

using System.Globalization;

class Program
{


    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    private static void Main(string[] args)
    {
        UserInput userInput = new UserInput();

        userInput.CollectUserInput();

        if (userInput.IsValid())
        {
            GenerateOutput(userInput);
        }
    }



    /// <summary>
    /// Get's the current price by area
    /// </summary>
    /// <remarks>
    /// Todo: Get live data from "the API". o_O
    /// </remarks>
    private static float GetPriceByArea(PriceArea priceArea)
    {
        switch (priceArea)
        {
            case PriceArea.Luleå:
                return 1.1133f;
            case PriceArea.Sundsvall:
                return 1.1133f;
            case PriceArea.Stockholm:
                return 3.0576f;
            case PriceArea.Malmö:
                return 3.0576f;
            default:
                return 0;
        }
    }

    /// <summary>
    /// Generates output based on the user input
    /// </summary>
    private static void GenerateOutput(UserInput userInput)
    {
        // Make sure we are using swedish currency format
        Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE"); 

        // Those variable names should be self explanatory... yes?
        int kwh = userInput.Get("kwh").ParsedInt;
        PriceArea area = (PriceArea)userInput.Get("priceArea").ParsedInt;
        float areaPrice = GetPriceByArea(area);
        float excessPrice = (kwh > 10000) ? (areaPrice * 1.25f * (kwh - 10000)) : 0;
        float extemeExcess = (kwh > 15000) ? (areaPrice * 1.5f * (kwh - 15000)) : 0;
        float basePrice = areaPrice * Math.Min(10000, kwh);
        float excessTotal = excessPrice + extemeExcess;
        float total = basePrice + excessTotal;

        // Print the output!
        Console.WriteLine("\n\n-----------------------------");
        Console.WriteLine("\tKundnummer: " + userInput.Get("customerNumber").ParsedInt);
        Console.WriteLine("\tTotalpris: {0:C2}", total);
        if (excessPrice > 0)
        {
            Console.WriteLine("\tRansoneringsavgift: {0:C2}", excessTotal);
        }
        Console.WriteLine("-----------------------------");
    }
}

