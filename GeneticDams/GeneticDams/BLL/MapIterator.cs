using System.Collections;

namespace GeneticDams.BLL
{
    /// <summary>
    /// Interface for aggregate
    /// </summary>
    public interface IAbstractAggregate

    {
        MapIterator CreateIterator();
    }
    /// <summary>
    /// Implementation of the aggregate interface
    /// </summary>
    public class MapAggregate : IAbstractAggregate
    {
        private ArrayList _items = new ArrayList();
        /// <summary>
        /// Creates a new iterator
        /// </summary>
        /// <returns>Iterator for the collection</returns>
        public MapIterator CreateIterator()
        {
            return new MapIterator(this);
        }
        /// <summary>
        /// Counts the items in the aggregate
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }
        /// <summary>
        /// Let access to the maps through indexes
        /// </summary>
        /// <param name="index">Index of the map</param>
        /// <returns>Map of the index</returns>
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }
    /// <summary>
    /// Interface of the abstract iterator for their operations
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
    /// Map iterator to go through all the maps
    /// </summary>
    public class MapIterator : IAbstractIterator
    {

        private MapAggregate _aggregate;
        private int _current;
        /// <summary>
        /// Constructor of the iterator that sets current to 0
        /// </summary>
        /// <param name="aggregate">Aggregate that creates it</param>
        public MapIterator(MapAggregate aggregate)
        {
            _current = 0;
            this._aggregate = aggregate;
        }
        /// <summary>
        /// Gets the first map
        /// </summary>
        /// <returns>First map</returns>
        public Map First()
        {
            _current = 0;
            return _aggregate[_current] as Map;
        }
        /// <summary>
        /// Gets the next map
        /// </summary>
        /// <returns>Next map</returns>
        public Map Next()
        {
            _current +=1;
            if (!IsDone)
                return _aggregate[_current] as Map;
            else
                return null;
        }
        /// <summary>
        /// Gets the previous map
        /// </summary>
        /// <returns>Previous map</returns>
        public Map Previous()
        {
            _current -= 1;
            if (_current>=0)
                return _aggregate[_current] as Map;
            else
                return null;
        }
        /// <summary>
        /// Gets the current map
        /// </summary>
        /// <returns>Current map</returns>
        public Map CurrentItem
        {
            get { return _aggregate[_current] as Map; }
        }

        /// <summary>
        /// Gets whether iteration is complete
        /// </summary>
        /// <returns>Bool that says if completed</returns>
        public bool IsDone
        {
            get { return _current >= _aggregate.Count; }
        }
        /// <summary>
        /// Returns current item index.
        /// </summary>
        public int CurrentInt 
        {
            get { return _current; }
            set { _current = value; }
        }
    }
}