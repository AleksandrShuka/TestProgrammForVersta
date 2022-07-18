namespace TestProgrammForVersta.ServerData
{
    public class OrderWeb
    {
        public OrderWeb(int id, string? senderCity, string? senderAddress, string? recieverCity, string? recieverAddress, double weight, string date)
        {
            Id = id;
            SenderCity = senderCity;
            SenderAddress = senderAddress;
            RecieverCity = recieverCity;
            RecieverAddress = recieverAddress;
            Weight = weight;
            Date = date;
        }

        public int Id { get; set; }
        public string? SenderCity { get; set; }
        public string? SenderAddress { get; set; }
        public string? RecieverCity { get; set; }
        public string? RecieverAddress { get; set; }
        public double Weight { get; set; }
        public string Date { get; set; }
    }
}
