using System.Text.Json.Serialization;

namespace WrathLC.Utility.Common.DataContracts.Models;

public class ExceptionModel
{
    public string Status { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string StackTrace { get; set; }
}