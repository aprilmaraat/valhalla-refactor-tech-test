using System.ComponentModel;

namespace RefactorMe.Enum
{
    public enum EnumItemType
    {
        Lawnmower,
        [Description("Phone Case")]
        PhoneCase,
        [Description("T-Shirt")]
        TShirt
    }
}