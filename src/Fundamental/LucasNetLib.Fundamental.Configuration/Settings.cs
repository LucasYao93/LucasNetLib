
// Application code which might rely on the config could start here.

// This will output the following:
//   KeyOne = 1
//   KeyTwo = True
//   KeyThree:Message = Oh, that's nice...

public sealed class Settings
{
    public required int KeyOne { get; set; }
    public required bool KeyTwo { get; set; }
    public required NestedSettings KeyThree { get; set; } = null!;
}

public sealed class NestedSettings
{
    public required string Message { get; set; } = null!;
}