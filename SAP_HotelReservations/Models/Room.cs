using System;
using System.Collections.Generic;

namespace SAP_HotelReservations.Models
{
	/// <summary>
	/// Holds NumberOfReservedDays to help sort Rooms by their filled capacity,
	/// and ReservedRanges, which stores data about days that have been previously registered, which is defaulted to zero
	/// </summary>
	public class Room : IComparable<Room>
	{
		public int NumberOfReservedDays { get; set; }
		public List<DateRange> ReservedRanges { get; set; }
		
		public Room()
		{
			NumberOfReservedDays = 0;
			ReservedRanges = new List<DateRange>();
		}

		public int CompareTo(Room other)
		{
			if (ReferenceEquals(this, other))
			{
				return 0;
			}

			if (ReferenceEquals(null, other))
			{
				return 1;
			}

			return NumberOfReservedDays.CompareTo(other.NumberOfReservedDays);
		}
		
		/// <summary>
		/// Adds requested days to the list of reserved days,
		/// and increases the number of registered days for the room that the days are registered into
		/// </summary>
		/// <param name="range"> New date range to be inserted </param>
		public void AddDateRange(DateRange range)
		{
			ReservedRanges.Add(range);
			NumberOfReservedDays += (range.EndDay - range.StartDay) + 1;
		}

		/// <summary>
		/// Check if there are overlaps between already added days and new range to be added
		/// </summary>
		/// <param name="range"> Days that are being compared against the existing days for overlap </param>
		/// <returns>
		/// True, if there were overlaps
		/// False, if there were no overlaps
		/// </returns>
		public bool IsDateRangeReserved(DateRange range)
		{
			List<DateRange> foundRanges = ReservedRanges.FindAll(reservedRange => reservedRange.CheckIntersect(range));

			if (foundRanges.Count > 0)
			{
				return true;
			}

			return false;
		}
	}
}