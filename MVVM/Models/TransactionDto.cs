using System.Text.Json.Serialization;

namespace ipgt_oop.MVVM.Models;

public class TransactionDto
{
    [JsonPropertyName("id")]
    public int TransactionId { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("destinyCard")]
    public CardDto DestinyCard { get; set; }

    [JsonPropertyName("sorceCard")]
    public CardDto SourceCard { get; set; }
}

