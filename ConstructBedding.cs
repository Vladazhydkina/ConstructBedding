using System;

class Pillowcase
{
    public string Material { get; set; }
    public string Size { get; set; }
}

class Bedsheet
{
    public string Material { get; set; }
    public string Size { get; set; }
}

class DuvetCover
{
    public string Material { get; set; }
    public string Size { get; set; }
}

interface IBeddingBuilder
{
    void SetPillowcases(string material, string size);
    void SetBedsheet(string material, string size);
    void SetDuvetCover(string material, string size);
    (Pillowcase, Bedsheet, DuvetCover) GetBedding();
}

class BeddingBuilder : IBeddingBuilder
{
    private Pillowcase pillowcase;
    private Bedsheet bedsheet;
    private DuvetCover duvetCover;

    public BeddingBuilder()
    {
        pillowcase = new Pillowcase();
        bedsheet = new Bedsheet();
        duvetCover = new DuvetCover();
    }

    public void SetPillowcases(string material, string size)
    {
        pillowcase.Material = material;
        pillowcase.Size = size;
    }

    public void SetBedsheet(string material, string size)
    {
        bedsheet.Material = material;
        bedsheet.Size = size;
    }

    public void SetDuvetCover(string material, string size)
    {
        duvetCover.Material = material;
        duvetCover.Size = size;
    }

    public (Pillowcase, Bedsheet, DuvetCover) GetBedding()
    {
        return (pillowcase, bedsheet, duvetCover);
    }
}

class BeddingDirector
{
    private IBeddingBuilder beddingBuilder;

    public BeddingDirector(IBeddingBuilder builder)
    {
        beddingBuilder = builder;
    }

    public void ConstructBedding(string pillowcaseMaterial, string pillowcaseSize, string bedsheetMaterial, string bedsheetSize, string duvetCoverMaterial, string duvetCoverSize)
    {
        beddingBuilder.SetPillowcases(pillowcaseMaterial, pillowcaseSize);
        beddingBuilder.SetBedsheet(bedsheetMaterial, bedsheetSize);
        beddingBuilder.SetDuvetCover(duvetCoverMaterial, duvetCoverSize);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var beddingBuilder = new BeddingBuilder();
        var director = new BeddingDirector(beddingBuilder);

        director.ConstructBedding("cotton", "standard", "linen", "king", "silk", "queen");

        var (pillowcase, bedsheet, duvetCover) = beddingBuilder.GetBedding();

        Console.WriteLine("Pillowcase: Material - {0}, Size - {1}", pillowcase.Material, pillowcase.Size);
        Console.WriteLine("Bedsheet: Material - {0}, Size - {1}", bedsheet.Material, bedsheet.Size);
        Console.WriteLine("Duvet Cover: Material - {0}, Size - {1}", duvetCover.Material, duvetCover.Size);
    }
}

