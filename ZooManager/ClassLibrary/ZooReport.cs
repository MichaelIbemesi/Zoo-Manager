using System;

namespace ZooManager
{
	/// <summary>
	/// Class representing the reports which can be made on specific zoos.
	/// </summary>
	public class ZooReport : Report
	{
		/// <summary>
		/// The ID of the zoo bring reported on.
		/// </summary>
		public int ZooId { get; private set; }

		/// <summary>
		/// Constructor used to make new reports.
		/// </summary>
		/// <param name="id">The ID of zoo.</param>
		/// <param name="description">The body of the report.</param>
		public ZooReport(int id, string description) : base(description)
		{
			this.ZooId = id;
		}

		/// <summary>
		/// Constructor used to make new reports.
		/// </summary>
		/// <param name="id">The ID of report.</param>
		/// ///<param name="zooId">The ID of zoo.</param>
		/// <param name="description">The body of the report.</param>
		public ZooReport(int id, int zooId, string description, DateTime time) : base(id, description, time)
		{
			this.ZooId = zooId;
		}
	}
}

