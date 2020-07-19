using System;
using System.Collections.Generic;
using SAP_HotelReservations.Models;

namespace SAP_HotelReservations
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Assumptions made:
			 * As it isn't noted what kind of testing is requested, i assumed that unit tests are to be used to test
			 * the code, and added NUnit library for such purpose.
			 * DateRange struct is added so as to make passing start and end parameters easier.
			 */
			
			/*
			 * Simplified method calls to demonstrate program functionality;
			 * Actual test methods and data can be found in SAP_HotelReservations.Test
			 */
			Hotel hotel = new Hotel(2);

			List<DateRange> list = new List<DateRange>()
			{
				new DateRange(1, 3),
				new DateRange(0, 4),
				new DateRange(2, 3),
				new DateRange(5, 5),
				new DateRange(4, 10),
				new DateRange(10, 10),
				new DateRange(6, 7),
				new DateRange(8, 10),
				new DateRange(8, 9)
			};

			foreach (DateRange dateRange in list)
			{
				Console.WriteLine(
					hotel.ReserveRoom(dateRange)
						? "Reserved from {0} to {1}"
						: "Requested days ({0} to {1}) are already reserved in all rooms available.",
					dateRange.StartDay, dateRange.EndDay);
			}
		}
	}
}