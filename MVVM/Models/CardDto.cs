using System.Text.Json.Serialization;

namespace ipgt_oop.MVVM.Models;

public class CardDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }
}