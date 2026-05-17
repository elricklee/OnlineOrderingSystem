namespace OnlineOrdering.API.Models;

public class TableSession
{
    public int Id { get; set; }
    public int DiningTableId { get; set; }
    public DiningTable? DiningTable { get; set; }
    public string SessionNo { get; set; } = string.Empty;
    public int PartySize { get; set; }
    public string Status { get; set; } = TableSessionStatuses.Open;
    public DateTime OpenedAt { get; set; } = DateTime.Now;
    public DateTime? ClosedAt { get; set; }
    public int? OpenedByUserId { get; set; }
    public int? ClosedByUserId { get; set; }
    public string? Remark { get; set; }
    public List<Order> Orders { get; set; } = new();
}
