namespace BtkAkademi.Models
{
    public static class Repository
    {
        private static List<Candidate> applications=new(); 
        public static IEnumerable<Candidate>Applications=>applications;
        //sınıf dışından ulaşmak isteyenlere interface desteği ile 

        //formdan gelicek elemanları eklicek yapı
        public static void Add(Candidate candidate)
        {
            applications.Add(candidate);
        }


    }
}