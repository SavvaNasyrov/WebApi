namespace WebApi.Models
{
    public class OccurrencesData
    {
        public OccurrencesData()
        {
            Data = new Dictionary<char, int>[5];
            Data[0] = new Dictionary<char, int>(33);
            Data[1] = new Dictionary<char, int>(33);
            Data[2] = new Dictionary<char, int>(33);
            Data[3] = new Dictionary<char, int>(33);
            Data[4] = new Dictionary<char, int>(33);

        }

        public Dictionary<char, int>[] Data { get; set; }
    }
}
