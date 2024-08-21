using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model.Repo
{
    internal class Repository<T>
    {
        List<T> _elements;


        // Somehow listen to all methods and check whether parameter is valid
        // instead of calling checkParam in all methods
        // Delegate add, remove, clear, update;

        public Repository(){
            _elements = new List<T>();
        }

        public Repository(List<T> elements)
        {
            _elements = elements;
        }


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
