using System;

namespace ZooManager
{
    /// <summary>
    /// Parent class of the animal and zoo report classes.
    /// </summary>
    public abstract class Report
    {
        /// <summary>
        /// The unique identifier of the report.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The date the report was made.
        /// </summary>
        public DateTime DateCreated { get; private set;}
        /// <summary>
        /// The body of the report.
        /// </summary>
        public String Description { get; private set; }

        /// <summary>
        /// constructor of creating new reports.
        /// </summary>
        /// <param name="description">The body of the report.</param>
        public Report(String description)
        {
            this.Id = 0;
            this.Description = description;
            this.DateCreated = DateTime.Now;
        }

        /// <summary>
        /// constructor of creating new reports.
        /// </summary>
        /// <param name="description">The body of the report.</param>
        /// <param name="id"> The unique identifier of the report.</param>
        /// ///<param name="time">The time which the report was made.</param>
        public Report(int id, String description, DateTime time)
        {
            this.Id = id;
            this.Description = description;
            this.DateCreated = time;
        }
    }
}
