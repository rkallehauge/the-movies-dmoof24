using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model.Repo
{
    public class Repository<T>
    {
        List<T> _elements;


        // technically not threadsafe code, but it works
        private static Repository<T> _instance;
        public static Repository<T> GetInstance()
        {
            if(_instance is null)
            {
                _instance = new Repository<T>();
            }
            return _instance;
        }

        // Somehow listen to all methods and check whether parameter is valid
        // instead of calling checkParam in all methods
        // Delegate add, remove, clear, update;

        protected Repository(){
            _elements = new List<T>();
        }

        //private Repository(List<T> elements)
        //{
        //    _elements = elements;
        //}


        public void Add(T element)
        {
            checkParam(element);

            _elements.Add(element);
        }

        public void AddIfNotExists(T element)
        {
            checkParam(element);

            if( !_elements.Contains(element))
            {
                _elements.Add(element);
            }
        }

        public void Remove(T element)
        {
            checkParam(element);

            if (_elements.Contains(element)) {
                _elements.Remove(element);
            }
            else
            {
                // Error handling?
            }
        }

        public List<T> GetAll()
        {
            return _elements;
        }

        //public bool Contains(T elem)
        //{
        //    foreach(T curr in _elements)
        //    {
                
        //    }
        //}

        public void Clear()
        {
            _elements.Clear();
        }

        private void checkParam(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Null element given.");
            }

            if (element.GetType() != typeof(T))
            {
                throw new ArgumentException("Invalid datatype given.");
            }
        }
    }
}
