// Hash Table Implementation
class HashTable
{
    private List<Tuple<string, string>>[] data;
    public HashTable(int size)
    {
        data = new List<Tuple<string, string>>[size];
    }

    private int Hash(string key)
    {
        var hash = 0;
        for (int i = 0; i < key.Length; i++)
        {
            hash = (hash + ((char)key[i]).GetHashCode() * i) % data.Length;
        }
        return hash;
    }

    public List<Tuple<string, string>>[] Set(dynamic key, dynamic value)
    {
        key = key as string;
        value = value as string;
        var address = Hash(key);
        var bucket = data[address];
        if (bucket == null)
        {
            bucket = new List<Tuple<string, string>>();
            data[address] = bucket;
        }

        bucket.Add(new Tuple<string, string>(key, value));
        return data;
    }

    public List<string> Keys()
    {
        var keys = new List<string>();
        foreach (var bucket in data)
        {
            if (bucket == null) continue;
            foreach (var pair in bucket)
                keys.Add(pair.Item1);
        }
        return keys;
    }

    public string Get(string key)
    {
        var address = Hash(key);
        var bucket = data[address];
        if (bucket != null)
        {
            foreach (var pair in bucket)
            {
                if (pair.Item1 as string == key as string) 
                    return pair.Item2 as string;
            }
        }
        return null;
    }
}

var myHashTable = new HashTable(50);
myHashTable.Set("grapes", 10000);
myHashTable.Get("grapes");
myHashTable.Set("apples", 9);
myHashTable.Get("apples");
myHashTable.Set("oranges", 2);
myHashTable.Get("apples");
var keys = myHashTable.Keys();
