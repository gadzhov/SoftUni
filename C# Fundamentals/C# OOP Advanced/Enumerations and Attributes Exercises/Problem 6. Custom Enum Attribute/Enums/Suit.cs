using Problem_6.Custom_Enum_Attribute.Attributes;

namespace Problem_6.Custom_Enum_Attribute.Enums
{
    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
}
