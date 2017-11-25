using assignment.Models;
using CsvHelper;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Data
{
    public static class DbInitializer
    {
        enum Fields
        {
            VariableCode = 0,
            VariableName = 1,
            IndustryCode = 2, 
            IndustryName = 3,
            PartnerCountryCode = 4,
            PartnerCountryName = 5,
            DeclaringCountryCode = 6,
            DeclaringCountryName = 7,
            Year = 8,
            UnitCode = 10,
            UnitName = 11,
            PowerCode = 12,
            PowerCodeDescription = 13,
            Value = 16,
        }

        private const string dataFileName = "AMNE_IN_25112017114257839.csv";

        public static void Initialize(Dataset context, IFileProvider fileProvider)
        {
            context.Database.EnsureCreated();

            // Look for any records
            if (context.Records.Any())
            {
                return;   // DB has been seeded
            }


            var declaringCountries = new HashSet<DeclaringCountry>();
            var economicVariables = new HashSet<EconomicVariable>();
            var industries = new HashSet<Industry>();
            var partnerCountries = new HashSet<PartnerCountry>();
            var powerCodes = new HashSet<PowerCode>();
            var units = new HashSet<Unit>();
            var file = fileProvider.GetFileInfo(dataFileName);


            using (var csv = new CsvReader(File.OpenText(file.PhysicalPath)))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var industry = new Industry
                    {
                        Id = csv[(int)Fields.IndustryCode],
                        Name = csv[(int)Fields.IndustryName]
                    };
                    var declaringCountry = new DeclaringCountry
                    {
                        Id = csv[(int)Fields.DeclaringCountryCode],
                        Name = csv[(int)Fields.DeclaringCountryName]
                    };
                    var partnerCountry = new PartnerCountry
                    {
                        Id = csv[(int)Fields.PartnerCountryCode],
                        Name = csv[(int)Fields.PartnerCountryName]
                    };
                    var economicVariable = new EconomicVariable
                    {
                        Id = csv[(int)Fields.VariableCode],
                        Name = csv[(int)Fields.VariableName]
                    };
                    var powerCodeString = csv[(int)Fields.PowerCode].Replace("\"", string.Empty);
                    var powerCode = new PowerCode
                    {
                        Id = int.Parse(powerCodeString),
                        Description = csv[(int)Fields.PowerCodeDescription]
                    };

                    var unit = new Unit
                    {
                        Id = csv[(int)Fields.UnitCode],
                        Name = csv[(int)Fields.UnitName]
                    };

                    industries.Add(industry);
                    declaringCountries.Add(declaringCountry);
                    partnerCountries.Add(partnerCountry);
                    economicVariables.Add(economicVariable);
                    powerCodes.Add(powerCode);
                    units.Add(unit);

                    var yearString = csv[(int)Fields.Year].Replace("\"", string.Empty);

                    var record = new Record
                    {
                        DeclaringCountry = declaringCountry,
                        EconomicVariable = economicVariable,
                        Industry = industry,
                        PartnerCountry = partnerCountry,
                        Year = int.Parse(yearString),
                        PowerCode = powerCode,
                        Unit = unit,
                    };
                    if (int.TryParse(csv[(int)Fields.Value], out int value))
                    {
                        record.Value = value;
                    }
                    context.Records.Add(record);
                }
                context.SaveChanges();
            }
        }
    }
}
