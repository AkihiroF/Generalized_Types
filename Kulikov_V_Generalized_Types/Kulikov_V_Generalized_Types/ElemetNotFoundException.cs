namespace Kulikov_V_Generalized_Types;

public class ElemetNotFoundException : Exception
{
    public override string Message
    {
        get
        {
            return "ElementNotFound";
        }
    }
}