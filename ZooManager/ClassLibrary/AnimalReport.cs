using System;

namespace ZooManager
{
    /// <summary>
    /// Class representing the reports which can be made on specific animals.
    /// </summary>
    class AnimalReport : Report
    {
        /// <summary>
        /// The ID of the animal bring reported on.
        /// </summary>
        public int AnimalId { get; private set;}

        /// <summary>
        /// Constructor used to make new reports.
        /// </summary>
        /// <param name="id">The ID of animal.</param>
        /// <param name="description">The body of the report.</param>
        public AnimalReport(int id, string description) : base(description)
        {
            this.AnimalId = id;
        }

        /// <summary>
        /// Constructor used to make new reports.
        /// </summary>
        /// <param name="id">The ID of the report.</param>
        /// <param name="animalId">The ID of animal.</param>
        /// <param name="description">The body of the report.</param>
        public AnimalReport(int id, int animalId, string description, DateTime time) : base(id, description, time)
        {
            this.AnimalId = animalId;
        }
    }
}
