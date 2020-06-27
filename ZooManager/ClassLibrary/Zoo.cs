using System;
using System.Collections;
using System.Collections.Generic;

namespace ZooManager
{
    /// <summary>
    /// A class representing the zoo, which animals inhabit.
    /// </summary>
    public class Zoo
    {
        public int Id { get; private set; }
        public String ZooName { get; private set; }
        public String ZooAddress { get; private set; }

        /// <summary>
        /// Constructor which creates instances of the zoos.
        /// </summary>
        /// <param name="name">The name of the zoo.</param>
        /// <param name="address">The address of the zoo.</param>
        public Zoo(String name, String address)
        {
            this.Id = 0;
            this.ZooName = name;
            this.ZooAddress = address;
        }

        /// <summary>
        /// Constructor which creates instances of the zoos.
        /// </summary>
        /// <param name="id">the unique identifer of the zoo.</param>
        /// <param name="name">The name of the zoo.</param>
        /// <param name="address">The address of the zoo.</param>
        public Zoo(int id, String name, String address)
        {
            this.Id = id;
            this.ZooName = name;
            this.ZooAddress = address;
        }

        /// <summary>
        /// Method which returns the properies of the zoo.
        /// </summary>
        /// <returns>Returns a string version of the zoo properties.</returns>
        public override String ToString()
        {
            String print = (Id + " " + ZooName + " " + ZooAddress);

            return print;
        }

        /// <summary>
        /// Method which checks if two zoos are the same.
        /// </summary>
        /// <param name="obj">Zoo to be compared.</param>
        /// <returns>returns Returns boolean result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Zoo zoo &&
                   ZooName == zoo.ZooName &&
                   ZooAddress == zoo.ZooAddress;
        }
        
        /// <summary>
        /// Method which creates a hascode for the zoo.
        /// </summary>
        /// <returns>Returns the hashcode.</returns>
        public override int GetHashCode()
        {
            int hashCode = 765756857;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ZooName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ZooAddress);
            return hashCode;
        }
    }
}
