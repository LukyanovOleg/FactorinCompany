namespace MetroScheme
{
	class Program
	{
		static void Main(string[] args)
		{
			var root = new Root
			{
				Stations = new Station[6] {
					new Station{ Id = 1, Name = "Алма-атинская", PrevStationId = null, NextStationId = 2},
					new Station{ Id = 2, Name = "Каширская", PrevStationId = 1, NextStationId = 3, Changings = new [] { 4 } },
					new Station{ Id = 3, Name = "Коломенская", PrevStationId = 2, NextStationId = 4},
					new Station{ Id = 4, Name = "Автозаводская", PrevStationId = 3, NextStationId = null},
					new Station{ Id = 5, Name = "Каширская", PrevStationId = null, NextStationId = 6},
					new Station{ Id = 6, Name = "Варшавская", PrevStationId = 5, NextStationId = null},
				}

			};

			Helpers.XmlHelper.SerializeObject(root, "MetroMap.xml");
		}
	}
}
