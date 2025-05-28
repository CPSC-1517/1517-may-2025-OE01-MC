using OOPsReview;

#region Setup

Employment? foundEmployment = null;
const string SEARCHTERM = "PG II";

List<Employment> employments = CreateCollection();

Console.WriteLine("Collection Queries");
#endregion

#region Loops

#endregion

#region Inbuilt

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

#endregion