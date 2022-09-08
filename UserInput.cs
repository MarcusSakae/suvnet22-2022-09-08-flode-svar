class UserInput
{
    private List<InputField> Fields = new List<InputField>();


    /// <summary>
    /// Initiate the fields
    /// </summary>
    public UserInput()
    {
        Fields.Add(new InputField("kwh", "antalet kWh förbrukade"));
        Fields.Add(new InputField("priceArea", "prisområde"));
        Fields.Add(new InputField("customerNumber", "kundnummer"));
    }

    /// <summary>
    /// Gets a single field by id.
    /// </summary>
    public InputField Get(string field_id)
    {
        InputField? field = Fields.Find(x => x.Id == field_id);
        if (field == null)
        {
            throw new Exception("Field not found");
        }
        return field;
    }



    /// <summary>
    /// Read in the input from the user
    /// </summary>
    public void CollectUserInput()
    {
        foreach (InputField field in Fields)
        {
            if (field.Id == "priceArea")
            {
                // Oh how we want to iterate over the enum values here, but it gets messy.
                Console.WriteLine("\t1: Luleå");
                Console.WriteLine("\t2: Sundsvall");
                Console.WriteLine("\t3: Stockholm");
                Console.WriteLine("\t4: Malmö");
            }
            Console.Write("Ange " + field.Description + ": ");
            field.Input = Console.ReadLine();
        }
    }


    /// <summary>
    /// Parses user input to ints
    /// Returns true if all values are parsable
    /// </summary>
    public bool IsValid()
    {
        bool isAllValid = true;
        foreach (InputField field in Fields)
        {
            if (field.Input == null)
            {
                Console.WriteLine("Du måste ange " + field.Description);
                isAllValid = false;
            }
            else if (!int.TryParse(field.Input, out field.ParsedInt))
            {
                Console.WriteLine("Du måste ange ett heltal för " + field.Description);
                isAllValid = false;
            }

        }
        return isAllValid;

    }

}