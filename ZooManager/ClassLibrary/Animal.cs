using System;
using System.Collections;
using System.Collections.Generic;

namespace ZooManager
{
    /// <summary>
    /// A class represting the animals inhabiting the zoo.
    /// </summary>
    public class Animal
    {
        public int Id { get; private set; }
        public String AnimalName { get; private set; }
        public int Age { get; private set; }
        public String Species { get; private set; }
        public int Location { get; private set; }
        public DateTime DateAdded { get; private set; }

        /// <summary>
        /// Constructor which creates animals with provided properties.
        /// </summary>
        /// <param name="name"> The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="species">The species of the animal.</param>
        /// <param name="location">The ID of the zoo which the animal is inhabiting.</param>
        public Animal(String name, int age, String species, int location)
        {
            this.Id = 0;
            this.AnimalName = name;
            this.Age = age;
            this.Species = species;
            this.Location = location;
            this.DateAdded = DateTime.Now;
        }

        /// <summary>
        /// Constructor which creates animals with provided properties.
        /// </summary>
        /// <param name="id">The unique identifier of the animal.</param>
        /// <param name="name"> The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="species">The species of the animal.</param>
        /// <param name="location">The ID of the zoo which the animal is inhabiting.</param>
        /// <param name="date">The date which the animal wass added to the database.</param>
        public Animal(int id, String name, int age, String species, int location, DateTime date)
        {
            this.Id = id;
            this.AnimalName = name;
            this.Age = age;
            this.Species = species;
            this.Location = location;
            this.DateAdded = date;
        }

        /// <summary>
        /// A method which returns the properties if the animal object.
        /// </summary>
        /// <returns> A string version of the animal properties.</returns>
        public override String ToString()
        {
            String print = (Id + " " + AnimalName + " " + Age + " " + Species + " " + Location);

            return print;
        }

        /// <summary>
        /// A method used to check whether to instances of an animal are the same.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns a boolean as a result of the comparison.</returns>
        public override bool Equals(object obj)
        {
            return obj is Animal animal &&
                   AnimalName == animal.AnimalName &&
                   Age == animal.Age &&
                   Species == animal.Species &&
                   Location == animal.Location;
        }

        public override int GetHashCode()
        {
            int hashCode = -667022927;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AnimalName);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Species);
            hashCode = hashCode * -1521134295 + Location.GetHashCode();
            return hashCode;
        }
    }
}
