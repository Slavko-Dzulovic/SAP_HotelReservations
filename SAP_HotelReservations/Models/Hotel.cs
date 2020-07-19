using System.Collections.Generic;
using System.Linq;

namespace SAP_HotelReservations.Models
{
	/// <summary>
	/// Holds logic related to setting the number of Rooms in a hotel, and adding DataRanges to those rooms
	/// </summary>
	public class Hotel
	{
		/// <summary>
		/// Number of rooms (size) in a Hotel
		/// </summary>
		public List<Room> Rooms { get; set; }

		public Hotel(int rooms = 0)
		{
			Rooms = new List<Room>();
			
			if (rooms <= 1000)
			{
				for (int i = 0; i < rooms; i++)
				{
					Rooms.Add(new Room());
				}
			}
		}
		
		/// <summary>
		/// Loops through existing rooms, attempting to add a requested DateRange.
		/// </summary>
		/// <param name="requestedRange"> Represents start and end day </param>
		/// <returns>
		/// True, if the passed range is accepted
		/// False, if the passed range couldn't be added
		/// </returns>
		public bool ReserveRoom(DateRange requestedRange)
		{
			var startDay = requestedRange.StartDay;
			var endDay = requestedRange.EndDay;
			
			if (startDay < 0 || endDay > 365 || startDay > endDay) 
			{
				return false;
			}

			foreach (Room room in Rooms.OrderByDescending(r => r).ToArray())
			{
				if (!room.IsDateRangeReserved(requestedRange))
				{
					room.AddDateRange(requestedRange);
					return true;
				}
			}

			return false;
		}
	}
}