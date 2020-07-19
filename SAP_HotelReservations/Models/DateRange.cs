namespace SAP_HotelReservations.Models
{
	/// <summary>
	/// DateRange's primary purpose is to provide convenient way of passing start-end day parameters,
	/// and CheckIntersect method, which checks if two DateRanges overlap.
	/// </summary>
	public struct DateRange
	{
		public int StartDay;
		public int EndDay;
		
		public DateRange(int startDate, int endDate)
		{
			StartDay = startDate;
			EndDay = endDate;
		}
		
		/// <summary>
		/// Checks if requested DateRange conflicts with DateRange already added to a Room
		/// </summary>
		/// <param name="second"> DateRange to be added </param>
		/// <returns>
		/// True, if there are conflicts and the second DateRange cannot be added
		/// False, if there are no conflicts present
		/// </returns>
		public bool CheckIntersect(DateRange second)
		{
			if (second.StartDay >= StartDay && second.StartDay <= EndDay)
			{
				return true;
			}

			if (second.EndDay >= StartDay && second.EndDay <= EndDay)
			{
				return true;
			}

			if (second.StartDay <= StartDay && second.EndDay >= EndDay)
			{
				return true;
			}

			return false;
		}
	}
}