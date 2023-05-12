using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AccountManagement.Domain.Models
{
    public class User
    {
        [JsonPropertyName("CustomerId")]
        public int CustomerId { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Surname")]
        public string Surname { get; set; }

        // Navigation property for Account
        public ICollection<Account> Accounts { get; set; }
    }
}
