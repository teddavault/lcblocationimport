using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lcbLocationImport
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get db context
            var dblocations = new lcbLocationsContainer();
            
            //Parse and update countries
            using (var rd = new StreamReader("c:\\Locations27Sep130912.csv"))
            {
                var lastcountry = "";
                var counter = 0;
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    if (counter > 0)
                    {
                         if (lastcountry != splits[1])
                        {
                            var countrytofind = Convert.ToInt32(splits[0]);
                            var foundcountry=dblocations.lcbCountries.FirstOrDefault(a=> a.lcbcountry_id==countrytofind);

                            if (foundcountry == null)
                            {
                                var country = new lcbCountry();
                                country.lcbcountry_id = Convert.ToInt32(splits[0]);
                                country.lcbcountry_description = splits[1];
                                country.last_updated = DateTime.Now;
                                dblocations.lcbCountries.Add(country);
                                dblocations.SaveChanges();
                                Console.WriteLine(splits[1]);
                            }
                        }
                        lastcountry = splits[1];
                    }
                    counter++;
                }
            }
            //Parse and update regions
            using (var rd = new StreamReader("c:\\Locations27Sep130912.csv"))
            {
                var lastregion = "";
                var counter = 0;
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    if (counter > 0)
                    {
                        if (lastregion != splits[2])
                        {
                             var regiontofind = Convert.ToInt32(splits[2]);
                            var foundregion=dblocations.lcbRegions.FirstOrDefault(a=> a.lcbregion_id==regiontofind);

                            if (regiontofind == null)
                            {
                                var countrytofind = Convert.ToInt32(splits[0]);
                                var foundcountry = dblocations.lcbCountries.FirstOrDefault(a => a.lcbcountry_id == countrytofind);
                                var lcbregion = new lcbRegion();
                                lcbregion.CountryId = countrytofind;
                                lcbregion.lcbregion_id = Convert.ToInt32(splits[2]);
                                lcbregion.lcbregion_description = splits[3];
                                lcbregion.last_updated = DateTime.Now;
                                foundcountry.lcbRegions.Add(lcbregion);
                                dblocations.SaveChanges();
                                Console.WriteLine(splits[2] + " " + splits[3]);
                            }
                        }
                        lastregion = splits[2];
                    }
                    counter++;
                }
            }
            //Parse and update subregions
            using (var rd = new StreamReader("c:\\Locations27Sep130912.csv"))
            {
                var lastsubregion = "";
                var counter = 0; 
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    if (counter > 0)
                    {
                        if (lastsubregion != splits[4])
                        {
                            var subregiontofind = Convert.ToInt32(splits[4]);
                            var foundsubregion = dblocations.lcbSubRegions.FirstOrDefault(a => a.lcbsubregion_id == subregiontofind);
                            if (foundsubregion == null)
                            {
                                var regiontofind = Convert.ToInt32(splits[2]);
                                var foundregion = dblocations.lcbRegions.FirstOrDefault(a => a.lcbregion_id == regiontofind);
                                var lcbsubregion = new lcbSubRegion();
                                lcbsubregion.lcbRegionId = regiontofind;
                                lcbsubregion.lcbsubregion_id = Convert.ToInt32(splits[4]);
                                lcbsubregion.lcbsubregion_description = splits[5];
                                lcbsubregion.last_updated = DateTime.Now;
                                foundregion.lcbSubRegions.Add(lcbsubregion);
                                dblocations.SaveChanges();
                                Console.WriteLine(splits[4] + " " + splits[5]);
                            }

                        }
                        lastsubregion = splits[4];
                    }
                    counter++;
                }
            }
        }
    }
}
