using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroScheme
{
	public class Station
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int? PrevStationId { get; set; }

		public int? NextStationId { get; set; }

		public int[] Changings { get; set; }
	}
}
