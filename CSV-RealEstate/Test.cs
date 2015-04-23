using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CSV_RealEstate
{
    [TestFixture]
    class Test
    {
        public List<RealEstateSale> testData = Program.GetRealEstateSaleList();
            //Display the average square footage of a Condo sold in the city of Sacramento, 
            //Use the GetAverageSquareFootageByRealEstateTypeAndCity() function.
        [Test]
        public void GetAverageSquareFootageByRealEstateTypeAndCityTest()
        {
            var result = Program.GetAverageSquareFootageByRealEstateTypeAndCity(testData, RealEstateType.Condo, "sacramento");
            Assert.IsTrue(result == 941.36, "Incorrect value");
        }
            //Display the total sales of all residential homes in Elk Grove.  Use the GetTotalSalesByRealEstateTypeAndCity() function.
        [Test]
        public void GetTotalSalesByRealEstateTypeAndCityTest()
        {
            var result = Program.GetTotalSalesByRealEstateTypeAndCity(testData, RealEstateType.Residential, "elk grove");
            Assert.IsTrue(result == 28372477, "Incorrect value");
        }

        //Display the total number of residential homes sold in the zip code 95842.  Use the GetNumberOfSalesByRealEstateTypeAndZip() function.
        [Test]
        public void GetNumberOfSalesByRealEstateTypeAndZipTest()
        {
            var result = Program.GetNumberOfSalesByRealEstateTypeAndZip(testData, RealEstateType.Residential, "95842");
            Assert.IsTrue(result == 16, "Incorrect value");
        }

        //Display the average sale price of a lot in Sacramento.  Use the GetAverageSalePriceByRealEstateTypeAndCity() function.
        [Test]
        public void GetAverageSalePriceByRealEstateTypeAndCityTest()
        {
            var result = Program.GetAverageSalePriceByRealEstateTypeAndCity(testData, RealEstateType.Lot, "sacramento");
            Assert.IsTrue(result == 287483.67m, "Incorrect value");
        }
            //Display the average price per square foot for a condo in Sacramento.  Use the GetPricePerSquareFootByRealEstateTypeAndCity() function.
        [Test]
        public void GetAveragePricePerSquareFootByRealEstateTypeAndCityTest()
        {
            var result = Program.GetAveragePricePerSquareFootByRealEstateTypeAndCity(testData, RealEstateType.Condo, "sacramento");
            Assert.IsTrue(result == 132.90m, "Incorrect value");
        }

        //Display the number of all sales that were completed on a Wednesday.  Use the GetNumberOfSalesByDayOfWeek() function.
        [Test]
        public void GetNumberOfSalesByDayOfWeekTest()
        {
            var result = Program.GetNumberOfSalesByDayOfWeek(testData, DayOfWeek.Wednesday);
            Assert.IsTrue(result == 158, "Incorrect value");
        }

        //Display the average number of bedrooms for a residential home in Sacramento when the 
        // price is greater than 300000.  Use the GetAverageBedsByRealEstateTypeAndCityHigherThanPrice() function.
        [Test]
        public void GetAverageBedsByRealEstateTypeAndCityHigherThanPriceTest()
        {
            var result = Program.GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(testData, RealEstateType.Residential, "sacramento", 300000m);
            Assert.IsTrue(result == 3.62, "Incorrect value");
        }

        //Extra Credit:
        //Display top 5 cities and the number of homes sold (using the GroupBy extension)
        // Use the GetTop5CitiesByNumberOfHomesSold() function.
        [Test]
        public void GetTop5CitiesByNumberOfHomesSoldTest()
        {
            List<string> results = Program.GetTop5CitiesByNumberOfHomesSold(testData);
            Assert.IsTrue(results.Count == 5, "Incorrect number of results, should be 5");
            Assert.IsTrue(results[0].ToLower() == "sacramento", "Top city incorrect");
            Assert.IsTrue(results[2].ToLower() == "lincoln", "3rd city incorrect");
            Assert.IsTrue(results[4].ToLower() == "citrus heights", "5th city incorrect");

        }
    }
}
