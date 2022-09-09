namespace WrathLC.Utility.Common.Validation;

public static class WowValidationUtility
{
    
    public static NameValidationResult ValidateCharacterName(ref string candidate)
    {
        var validationResult = new NameValidationResult();
        if (string.IsNullOrWhiteSpace(candidate))
        {
            validationResult.InvalidReasons.Add("A value must be provided.");
            validationResult.IsValid = false;
            return validationResult;
        }
        candidate = candidate.Trim().ToLowerInvariant();
        if (candidate.Length < 2)
        {
            validationResult.InvalidReasons.Add("A character name must be at least two characters.");
        }
        if (candidate.Length > 12)
        {
            validationResult.InvalidReasons.Add("A character name may not exceed twelve characters.");
        }
        if (candidate.Any(char.IsWhiteSpace))
        {
            validationResult.InvalidReasons.Add("A character name may not contain any spaces.");
        }
        if (!candidate.All(char.IsLetter))
        {
            validationResult.InvalidReasons.Add("A character name may only contain letters.");
        }
        candidate = char.ToUpper(candidate[0]) + new string(candidate.Skip(1).ToArray());
        validationResult.IsValid = !validationResult.InvalidReasons.Any();
        return validationResult;
    }
}