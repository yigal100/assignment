using assignment.Models;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
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
            var records = new List<Record>();
            var file = fileProvider.GetFileInfo(dataFileName);
            foreach (var line in File.ReadLines(file.PhysicalPath))
            {
                var values = line.Split(",");
                var industry = new Industry
                {
                    Id = values[(int)Fields.IndustryCode],
                    Name = values[(int)Fields.IndustryName]
                };
                var declaringCountry = new DeclaringCountry
                {
                    Id = values[(int)Fields.DeclaringCountryCode],
                    Name = values[(int)Fields.DeclaringCountryName]
                };
                var partnerCountry = new PartnerCountry
                {
                    Id = values[(int)Fields.PartnerCountryCode],
                    Name = values[(int)Fields.PartnerCountryName]
                };
                var economicVariable = new EconomicVariable
                {
                    Id = values[(int)Fields.VariableCode],
                    Name = values[(int)Fields.VariableName]
                };
                var powerCode = new PowerCode
                {
                    Id = int.Parse(values[(int)Fields.PowerCode]),
                    Description = values[(int)Fields.PowerCodeDescription]
                };
                var unit = new Unit
                {
                    Id = values[(int)Fields.UnitCode],
                    Name = values[(int)Fields.UnitName]
                };

                industries.Add(industry);
                declaringCountries.Add(declaringCountry);
                partnerCountries.Add(partnerCountry);
                economicVariables.Add(economicVariable);
                powerCodes.Add(powerCode);
                units.Add(unit);

                Record record = new Record
                {
                    DeclaringCountry = declaringCountry,
                    EconomicVariable = economicVariable,
                    Industry = industry,
                    PartnerCountry = partnerCountry,
                    PowerCode = powerCode,
                    Unit = unit,
                    Year = int.Parse(values[(int)Fields.Year]),
                };
                if (int.TryParse(values[(int)Fields.Value], out int value))
                {
                    record.Value = value;
                }
                records.Add(record);
            }
            context.Records.AddRange(records);
            context.SaveChanges();
            
        }
    }
}
