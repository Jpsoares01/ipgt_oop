namespace ipgt_oop.MVVM.Models;

public class TransactionRecord
{
    public int Id { get; set; } 
    public string Descricao { get; set; } 
    public string Type { get; set; } 
    public DateTime Data { get; set; } 
    public decimal Amount { get; set; } 

}