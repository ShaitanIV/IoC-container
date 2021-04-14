using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_IoC_container
{
    class Container
    {
        private IDictionary<Type, Type> typesDictionary;

        public Container()
        {
            typesDictionary = new Dictionary<Type, Type>();
        }
        /// <summary>
        /// Method to register interface and it's implementation
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        public void Register<TInterface, TImplementation>() 
        {
            if (!typeof(TInterface).IsInterface)
            {
                throw new ArgumentException("Key value must be interface");
            }

            if (!typeof(TInterface).IsAssignableFrom(typeof(TImplementation)))
            {
                throw new ArgumentException("This is not right implementation");
            }

            if (typesDictionary.ContainsKey(typeof(TInterface)))
            {
                typesDictionary[typeof(TInterface)] = typeof(TImplementation);
            }
            else
            {
                typesDictionary.Add(typeof(TInterface), typeof(TImplementation));
            }

            foreach (var item in typesDictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
        }
        /// <summary>
        /// Method to create instance of assigned class for this interface
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns>Instance of assigned class</returns>
        public object Resolve<TInterface>()
        {
            if (!typesDictionary.ContainsKey(typeof(TInterface)))
            {
                throw new ArgumentException("There is no such interface in dictionary");
            }

            if (typesDictionary[typeof(TInterface)]==null)
            {
                throw new NullReferenceException("There is no class assigned to this interface");
            }

            return Activator.CreateInstance(typesDictionary[typeof(TInterface)]);
        }
    }
}
