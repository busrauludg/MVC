namespace WebSitesi.Models
{
    public static class Repository
    {
      private static List<Candidate>applications=new();
      public static IEnumerable<Candidate>Applications=>applications;
      
      //formdan gelen verileri eklenicek
      public static void Add(Candidate candidate)
      {
        applications.Add(candidate);
      }
    }
}