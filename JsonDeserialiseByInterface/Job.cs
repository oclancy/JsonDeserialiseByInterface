namespace JsonDeserialiseByInterface
{
    public abstract class Job
    {
        public string Type { get; set; }
        public string Name { get; set; }
    }

    public class SendMsg :Job
    {
        public string Message { get; set; }
    }

    public class Price : Job
    {
        public string Isin { get; set; }
        public string Side { get; set; }
        public double Px { get; set; }
    }
}