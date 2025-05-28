using OOPsReview;

#region Setup

Employment? foundEmployment = null;
const string SEARCHTERM = "PG II";

List<Employment> employments = CreateCollection();

Console.WriteLine("Collection Queries");
#endregion

#region Loops

Console.WriteLine("\n--Loops Section--");

for (int i = 0;  i < employments.Count; i++)
{
    Console.WriteLine(employments[i]);
}

//Same thing with a foreach

foreach(var employment in employments)
{
    Console.WriteLine(employment);
}

//Does 2 comparisions (index 0 and 1) before returning.
for (int i = 0; i < employments.Count; i++)
{
    if (employments[i].Title.Equals(SEARCHTERM))
    {
        foundEmployment = employments[i];
        i = employments.Count; //this exits our for loop.
    }
}

TestForFoundItem(foundEmployment, SEARCHTERM);
foundEmployment = null;

//Same thing with a foreach

//This does 4 comparisons before returning.
foreach (var employment in employments)
{
    if (employment.Title.Equals(SEARCHTERM))
    {
        foundEmployment = employment;
    }
}

TestForFoundItem(foundEmployment, SEARCHTERM);
foundEmployment = null;

#endregion

#region Inbuilt

Console.WriteLine("\n--Inbuilt Collection Methods--");

//e works the same way as var employment in our foreach
//This will opperate like our for loop
foundEmployment = employments.Find(e => e.Title.Equals(SEARCHTERM));

TestForFoundItem(foundEmployment, SEARCHTERM);
foundEmployment = null;

//Doesn't work for partial search terms
//Can use .Contains to look for partial terms
foundEmployment = employments.Find(e => e.Title.Contains("PG"));

TestForFoundItem(foundEmployment, "PG");
foundEmployment = null;

//Finds the last instance
foundEmployment = employments.FindLast(e => e.Title.Contains("PG"));

TestForFoundItem(foundEmployment, "PG");
foundEmployment = null;

#endregion

#region LINQ

#endregion

#region Helper Functions

static List<Employment> CreateCollection()
{
    List<Employment> newCollection = new List<Employment>();

    newCollection.Add(new Employment("PG I", SupervisoryLevel.Entry,
                        DateTime.Parse("May 1, 2010"), 0.5));
    newCollection.Add(new Employment("PG II", SupervisoryLevel.TeamMember,
                    DateTime.Parse("Nov 1, 2010"), 3.2));
    newCollection.Add(new Employment("PG III", SupervisoryLevel.TeamLeader,
                    DateTime.Parse("Jan 6, 2014"), 8.6));
    newCollection.Add(new Employment("SP I", SupervisoryLevel.Supervisor,
                    DateTime.Parse("Jul 22, 2022"), 2.25));

    return newCollection;
}

static void TestForFoundItem(Employment? employment, string searchTerm)
{
    Console.WriteLine();

    if (employment == null)
    {
        Console.WriteLine($"Person had no {searchTerm} employment.");
    }
    else
    {
        Console.WriteLine($"Person had {searchTerm} employment: {employment}.");
    }
}

#endregion