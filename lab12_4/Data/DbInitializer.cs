using lab12_4.Models;
namespace lab12_4.Data
{
    public class DbInitializer
    {
        public static void Initialize(ClientContext context)
        {
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var client = new Client
            {
                Surename = "Uhaha",
                Name = "LOL"
            };

            //var clients = new Client[]
            //{
            //    new Client{Surename = "Hahaha", Name = "1HAHAHA"}
            //};

            context.Clients.AddRange(client);
            context.SaveChanges();

            var visa = new Visa
            {
                VisaName = "DFDSFADF",
                VisaPrice = 0
            };
            //var visas = new Visa[]
            //{
            //    new Visa{VisaName = "visa1", VisaPrice = 1000}
            //};

            context.Visas.AddRange(visa);
            context.SaveChanges();

            var tour = new Tour
            {
                Client = client.ClientID,
                Visa_t = visa.VisaID,
                Price = 100000,
                Country = "dscsdcsdcas",
                Visas = visa,
                Clients = client
            };

//            var tours = new Tour[]
//{
//                new Tour{Price = 1000, Country = "Tourkey"}
//};

            context.Tours.AddRange(tour);
            context.SaveChanges();
        }
    }
}
