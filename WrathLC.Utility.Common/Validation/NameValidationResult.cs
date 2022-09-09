using JetBrains.Annotations;

namespace WrathLC.Utility.Common.Validation;

public class NameValidationResult
{
    public bool IsValid { get; set; }
    public List<string> InvalidReasons { get; set; } = new();
}