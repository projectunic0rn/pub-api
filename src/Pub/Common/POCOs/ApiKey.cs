using System;

namespace Common.POCOs
{
    public class ApiKey
    {
        public ApiKey(int id, string name, string key)
        {
            Id = id;
            Name = name;
            Key = key;
        }

        public int Id { get; }
        public string Name { get; }
        public string Key { get; }
    }
}
