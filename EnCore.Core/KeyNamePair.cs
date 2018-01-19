
namespace EnCore.Core
{
    public class KeyNamePair : KeyNamePair<int>
    {
        public KeyNamePair()
        {
        }

        public KeyNamePair(int id, string name) : base(id, name)
        {
        }
    }

    public class KeyNamePair<TKey>
    {
        public KeyNamePair()
        {

        }
        public TKey Key { get; set; }
        public string Name { get; set; }

        public KeyNamePair(TKey id, string name)
        {
            this.Key = id;
            this.Name = name;
        }
    }
}
