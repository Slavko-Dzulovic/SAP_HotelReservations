namespace SAP_HotelReservations.Models
{
	/// <summary>
	/// Structure that defines a range of days by providing StartDay and EndDay, represented by integer values.
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
		/// Checks if requested DateRange conflicts with another DateRange, by comparing their StartDay and EndDay values.
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