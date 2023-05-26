namespace Kulikov_V_Generalized_Types;

public class TestKeyValuePairs<T1, T2>
{
    private T1 key;

    public TestKeyValuePairs(T1 key, T2 value)
    {
        this.key = key;
        this.value = value;
    }

    public T1 Key
    {
        get
        {
            return key;
        }
    }

    private T2 value;

    public T2 Value
    {
        get
        {
            return value;
        }
    }
    
}