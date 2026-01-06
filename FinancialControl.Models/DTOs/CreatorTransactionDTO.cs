namespace FinancialControl.Models.DTOs
{
    public class CreatorTransactionDTO
    {
        public required string Description { get; set; }
        public required double Amount  { get; set; }
        public required string Type { get; set; }
    }
}
