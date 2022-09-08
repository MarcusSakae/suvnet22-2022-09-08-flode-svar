class InputField
{
    public string Id
    { get; set; }

    public string Description
    { get; set; }

    public string? Input
    { get; set; }

    public int ParsedInt;    

    public InputField(string id, string description)
    {
        this.Id = id;
        this.Description = description;
    }
}
