using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_RealEstate
{
    // WHERE TO START?
    // 1. Complete the RealEstateType enumeration
    // 2. Complete the RealEstateSale object.  Fill in all properties, then create the constructor.
    // 3. Complete the GetRealEstateSaleList() function.  This is the function that actually reads in the .csv document and extracts a single row from the document and passes it into the RealEstateSale constructor to create a list of RealEstateSale Objects.
    // 4. Start by displaying the the information in the Main() function by creating lambda expressions.  After you have acheived your desired output, then translate your logic into the function for testing.
    class Program
    {
        static void Main(string[] args)
        {
            List<RealEstateSale> realEstateSaleList = GetRealEstateSaleList();
            
            //Display the average square footage of a Condo sold in the city of Sacramento, 
            //Use the GetAverageSquareFootageByRealEstateTypeAndCity() function.
            Console.WriteLine(GetAverageSquareFootageByRealEstateTypeAndCity(realEstateSaleList,RealEstateType.Condo , "Sacramento" ));
            //Display the total sales of all residential homes in Elk Grove.  Use the GetTotalSalesByRealEstateTypeAndCity() function for testing.

            //Display the total number of residential homes sold in the zip code 95842.  Use the GetNumberOfSalesByRealEstateTypeAndZip() function for testing.

            //Display the average sale price of a lot in Sacramento.  Use the GetAverageSalePriceByRealEstateTypeAndCity() function for testing.

            //Display the average price per square foot for a condo in Sacramento. Round to 2 decimal places. Use the GetAveragePricePerSquareFootByRealEstateTypeAndCity() function for testing.

            //Display the number of all sales that were completed on a Wednesday.  Use the GetNumberOfSalesByDayOfWeek() function for testing.


            //Display the average number of bedrooms for a residential home in Sacramento when the 
            // price is greater than 300000.  Round to 2 decimal places.  Use the GetAverageBedsByRealEstateTypeAndCityHigherThanPrice() function for testing.

            //Extra Credit:
            //Display top 5 cities by the number of homes sold (using the GroupBy extension)
            // Use the GetTop5CitiesByNumberOfHomesSold() function for testing.

        }

        public static List<RealEstateSale> GetRealEstateSaleList()
        {
            //make temp list
            List<RealEstateSale> tempList = new List<RealEstateSale> { }; 
            //read in the realestatedata.csv file.  As you process each row, you'll add a new 
            // RealEstateData object to the list for each row of the document, excluding the first.  bool skipFirstLine = true;
            using (System.IO.StreamReader reader = new System.IO.StreamReader("realestatedata.csv"))
            {
                //skips first line
                string firstline = reader.ReadLine();


                //loop all to temp list
                while (!reader.EndOfStream)
                {
                    tempList.Add(new RealEstateSale(reader.ReadLine()));
                }
            }
            
            return tempList;
        }

        public static double GetAverageSquareFootageByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city) 
        {
            return realEstateDataList.Where(x => x.Type == realEstateType && x.City.ToLower() == city.ToLower()).Average(y => y.SqFeet);
        }

        public static decimal GetTotalSalesByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return realEstateDataList.Where(x => x.Type == realEstateType && x.City.ToLower() == city.ToLower()).Sum(y => y.Price);
        }

        public static int GetNumberOfSalesByRealEstateTypeAndZip(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string zipcode)
        {
            return realEstateDataList.Where(x => x.Type == realEstateType && x.Zip == int.Parse(zipcode)).Count() ;
        }

        
        public static decimal GetAverageSalePriceByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            //Must round to 2 decimal points
            return Math.Round(Convert.ToDecimal(realEstateDataList.Where(x => x.Type == realEstateType && x.City.ToLower() == city.ToLower()).Average(y => y.Price)),2);
        }
        public static decimal GetAveragePricePerSquareFootByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            //Must round to 2 decimal points
            return Math.Round(Convert.ToDecimal(realEstateDataList.Where(x => x.Type == realEstateType && x.City.ToLower() == city.ToLower()).Average(y => y.SqFeet/y.Price)) , 2);
        }

        public static int GetNumberOfSalesByDayOfWeek(List<RealEstateSale> realEstateDataList, DayOfWeek dayOfWeek)
        {
            return realEstateDataList.Where(x => x.SaleDate.DayOfWeek == dayOfWeek).Count();
        }

        public static double GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city, decimal price)
        {
            //Must round to 2 decimal points
            return Math.Round(realEstateDataList.Where(x => x.Type == realEstateType && x.City.ToLower() == city.ToLower() && x.Price > price).Average(y => y.Bed), 2);
        }

        public static List<string> GetTop5CitiesByNumberOfHomesSold(List<RealEstateSale> realEstateDataList)
        {
            return realEstateDataList.GroupBy(x => x.City).OrderByDescending(y => y.Count()).First().Select(z => z.City).Take(5).ToList();
        }
    }

    public enum RealEstateType
    {
        //fill in with enum types: Residential, MultiFamily, Condo, Lot
        Residential,
        MultiFamily,
        Condo,
        Lot
    }
    class RealEstateSale
    {
        //Create properties, using the correct data types (not all are strings) for all columns of the CSV
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public int Bed { get; set; }
        public int Bath { get; set; }
        public int SqFeet { get; set; }
        public RealEstateType Type { get; set; }
        public DateTime SaleDate { get; set; }
        public int Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        

        //The constructor will take a single string arguement.  This string will be one line of the real estate data.
        // Inside the constructor, you will seperate the values into their corrosponding properties, and do the necessary conversions
        public RealEstateSale(string List)
        {
            //split by new line
            string[] ListData = List.Split(',');
            //set all properties to their index in ListData
            this.Street = ListData[0];
            this.City = ListData[1];
            this.Zip = int.Parse(ListData[2]);
            this.State = ListData[3];
            this.Bed = int.Parse(ListData[4]);
            this.Bath = int.Parse(ListData[5]);
            this.SqFeet = int.Parse(ListData[6]);
            //convert string to enum by switch
            switch (ListData[7])
            {
                case "Residential":
                   this.Type = RealEstateType.Residential;
                    break;
                case "Condo":
                    this.Type = RealEstateType.Condo;
                    break;
                case "Multi-Family":
                    this.Type = RealEstateType.MultiFamily;
                    break;
            }
            if (SqFeet == 0)
            {
                this.Type = RealEstateType.Lot;
            }
            this.SaleDate = DateTime.Parse(ListData[8]);
            this.Price = int.Parse(ListData[9]);
            this.Latitude = double.Parse(ListData[10]);
            this.Longitude = double.Parse(ListData[11]);
        }

        //When computing the RealEstateType, if the square footage is 0, then it is of the Lot type, otherwise, use the string
        // value of the "Type" column to determine its corresponding enumeration type.
    }
}
