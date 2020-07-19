using System.Collections.Generic;
using NUnit.Framework;
using SAP_HotelReservations.Models;
using static SAP_HotelReservations.Test.HotelTestData;

namespace SAP_HotelReservations.Test
{
	/// <summary>
	/// Executes tests regarding Room reservation
	/// </summary>
	[TestFixtureSource(typeof(HotelTestData), "TestParameters")]
	public class HotelTest
	{
		private int NumberOfRooms;
		private List<ValueResult> ValueResults;
		
		public HotelTest(int numberOfRooms, List<ValueResult> valueResults)
		{
			NumberOfRooms = numberOfRooms;
			ValueResults = valueResults;
		}

		/// <summary>
		/// Provides testing capabilities.
		/// Test loops through data provided from HotelTestData.cs and asserts that hotel.ReserveRoom method result
		/// for passed data is equal to provided expected bool result
		/// </summary>
		[Test]
		public void Hotel_CanReserveDateRange()
		{
			Hotel hotel = new Hotel(NumberOfRooms);

			foreach (ValueResult valueResult in ValueResults)
			{
				Assert.AreEqual(hotel.ReserveRoom(valueResult.Value), valueResult.Result);
			}
		}
	}
}