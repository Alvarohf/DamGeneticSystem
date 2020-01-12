using System.Collections;

namespace GeneticDams.BLL
{
    /// <summary>
    /// The 'Aggregate' interface
    /// </summary>
    public interface IAbstractAggregate

    {
        Iterator CreateIterator();
    }
    /// <summary>
    /// The 'MapAggregate' class
    /// </summary>
    public class MapAggregate : IAbstractAggregate
    {
        private ArrayList _items = new ArrayList();
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }
        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }
    /// <summary>
    /// The 'Iterator' interface
    /// </summary>
    public interface IAbstractIterator
    {
        Map First();
        Map Previous();
        Map Next();
        bool IsDone { get; }
        Map CurrentItem { get; }
    }
    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    public class Iterator : IAbstractIterator
    {
        private MapAggregate _aggregate;
        private int _current;
        // Constructor
        public Iterator(MapAggregate aggregate)
        {
            _current = 0;
            this._aggregate = aggregate;
        }
        // Gets first item
        public Map First()
        {
            _current = 0;
            return _aggregate[_current] as Map;
        }
        // Gets next item
        public Map Next()
        {
            _current +=1;
            if (!IsDone)
                return _aggregate[_current] as Map;
            else
                return null;
        }
        // Gets next item
        public Map Previous()
        {
            _current -= 1;
            if (_current>=0)
                return _aggregate[_current] as Map;
            else
                return null;
        }
        // Gets current iterator item
        public Map CurrentItem
        {
            get { return _aggregate[_current] as Map; }
        }
        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return _current >= _aggregate.Count; }
        }
        public int CurrentInt 
        {
            get { return _current; }
            set { _current = value; }
        }
    }
}