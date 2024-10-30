namespace WMS.Application.DTOs.Requests.Activities
{
    public class MergeRequest
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string ManagerId { get; set; }
        public string Src { get; set; }
        public string Dest { get; set; }
    }
}
