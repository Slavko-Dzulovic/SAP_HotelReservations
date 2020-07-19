using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using SAP_HotelReservations.Models;

namespace SAP_HotelReservations.Test
{
    /// <summary>
    /// Holds test data to be used in HotelTest.cs class for testing
    /// </summary>
	public class HotelTestData
	{
        /// <summary>
        /// Stores DateRange to be used in testing, and corresponding expected result, per given test cases
        /// </summary>
		public struct ValueResult
		{
			public DateRange Value;
			public bool Result;
		}
        
        /// <summary>
        /// TestParameters holds data to be injected into HotelTest.cs
        /// Data consists of an integer (stores number of rooms for a given test),
        /// ValueResult (which itself consists of DateRange and expected result (accepted or declined reservation)
        /// </summary>
        public static IEnumerable TestParameters
        {
            get
            {
                // Test data for test case "1a: Requests outside our planning period are declined (Size=1)"
                yield return new TestFixtureData(1, new List<ValueResult>()
                {
                    new ValueResult() { Value = new DateRange(-4, 2), Result = false },
                });

                //Test data for test case "1b: Requests outside our planning period are declined (Size=1)"
                yield return new TestFixtureData(1, new List<ValueResult>()
                {
                    new ValueResult() { Value = new DateRange(200, 400), Result = false },
                });
                
                //Test data for test case "2: Requests are accepted (Size=3)"
                yield return new TestFixtureData(3, new List<ValueResult>()
                {
                    new ValueResult() { Value = new DateRange(0, 5), Result = true },
                    new ValueResult() { Value = new DateRange(7, 13), Result = true },
                    new ValueResult() { Value = new DateRange(3, 9), Result = true },
                    new ValueResult() { Value = new DateRange(5, 7), Result = true },
                    new ValueResult() { Value = new DateRange(6, 6), Result = true },
                    new ValueResult() { Value = new DateRange(0, 4), Result = true }
                });
                
                //Test data for test case "3: Requests are declined (Size=3)"
                yield return new TestFixtureData(3, new List<ValueResult>()
                {
                    new ValueResult() { Value = new DateRange(1, 3), Result = true },
                    new ValueResult() { Value = new DateRange(2, 5), Result = true },
                    new ValueResult() { Value = new DateRange(1, 9), Result = true },
                    new ValueResult() { Value = new DateRange(0, 15), Result = false }
                });

                //Test data for test case "4: Requests can be accepted after a decline (Size=3)"
                yield return new TestFixtureData(3, new List<ValueResult>()
                {
                    new ValueResult() { Value = new DateRange(1, 3), Result = true },
                    new ValueResult() { Value = new DateRange(0, 15), Result = true },
                    new ValueResult() { Value = new DateRange(1, 9), Result = true },
                    new ValueResult() { Value = new DateRange(2, 5), Result = false },
                    new ValueResult() { Value = new DateRange(4, 9), Result = true }
                });

                //Test data for test case "5: Complex Requests (Size=2)"
                yield return new TestFixtureData(2, new List<ValueResult>()
                {
                    new ValueResult() { Value = new DateRange(1, 3), Result = true },
                    new ValueResult() { Value = new DateRange(0, 4), Result = true },
                    new ValueResult() { Value = new DateRange(2, 3), Result = false },
                    new ValueResult() { Value = new DateRange(5, 5), Result = true },
                    new ValueResult() { Value = new DateRange(4, 10), Result = true },
                    new ValueResult() { Value = new DateRange(10, 10), Result = true },
                    new ValueResult() { Value = new DateRange(6, 7), Result = true },
                    new ValueResult() { Value = new DateRange(8, 10), Result = false },
                    new ValueResult() { Value = new DateRange(8, 9), Result = true }
                });
            }
        }
	}
}