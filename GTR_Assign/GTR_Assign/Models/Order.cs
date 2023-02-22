namespace GTR_Assign.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int? Uid { get; set; }

        public int? Pid { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public virtual Product? PidNavigation { get; set; }

        public virtual User? UidNavigation { get; set; }
    }
}
