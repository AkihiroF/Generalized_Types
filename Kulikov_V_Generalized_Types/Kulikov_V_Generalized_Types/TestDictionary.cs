using System.Collections;

namespace Kulikov_V_Generalized_Types;

public class TestDictionary<T1, T2> : IEnumerable<TestKeyValuePairs<T1, T2>>, IEnumerator<TestKeyValuePairs<T1, T2>>
{
    private List<TestKeyValuePairs<T1, T2>> dictionary;
    private ElemetNotFoundException _foundException;
    private int _position = -1;

    public TestDictionary(List<TestKeyValuePairs<T1, T2>> dictionary, TestKeyValuePairs<T1, T2> current)
    {
        this.dictionary = dictionary;
        Current = current;
        _foundException = new ElemetNotFoundException();
    }

    public TestDictionary(TestKeyValuePairs<T1, T2> current)
    {
        Current = current;
        dictionary = new List<TestKeyValuePairs<T1, T2>>();
        _foundException = new ElemetNotFoundException();
    }

    public void Add(T1 key, T2 value)
    {
        if (CheckKeyInDictionary(key))
        {
            throw _foundException;
        }
        dictionary.Add(new TestKeyValuePairs<T1, T2>(key,value));
    }

    public void Remove(T1 key)
    {
        if (CheckKeyInDictionary(key))
        {
            dictionary.Remove(GetElement(key));
            return;
        }

        throw _foundException;
    }

    public void Remove(T2 value)
    {
        dictionary.Remove(GetElement(value));
    }

    private bool CheckKeyInDictionary(T1 key)
    {
        bool isIn = false;
        foreach (var element in dictionary)
        {
            if (key.Equals(element.Key))
                isIn = true;
        }
        return isIn;
    }

    public TestKeyValuePairs<T1, T2> GetElement(T1 key)
    {
        foreach (var element in dictionary)
        {
            if (key.Equals(element.Key))
            {
                return element;
            }
        }

        throw _foundException;
    }

    public TestKeyValuePairs<T1, T2> GetElement(T2 value)
    {
        foreach (var element in dictionary)
        {
            if (value.Equals(element.Value))
            {
                return element;
            }
        }

        throw _foundException;
    }

    public IEnumerator<TestKeyValuePairs<T1, T2>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool MoveNext()
    {
        if (_position < dictionary.Count - 1)
        {
            _position++;
            return true;
        }
        else
            return false;
    }

    public void Reset()
    {
        _position = -1;
    }

    public TestKeyValuePairs<T1, T2> Current { get; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        //хз что тут писать :)
    }
}