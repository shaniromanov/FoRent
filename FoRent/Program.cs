using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoRent.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FoRent
{
    public class Program
    {
        public static void Main(string[] args)
        {

            
      
        var host = BuildWebHost(args);
          



            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                FoRentContext context = services.GetRequiredService<FoRentContext>();
                if (context.Availability.Count() > 0 && context.Availability.OrderBy(u => u.Id).FirstOrDefault().NotAvailable < DateTime.Now.Date)
                {
                    foreach (var remove in context.Availability)
                    {
                        if (remove.NotAvailable < DateTime.Now.Date)
                        {
                            context.Availability.Remove(remove);
                            
                            var lastDate = context.Availability.OrderByDescending(u => u.Id).FirstOrDefault();
                            DateTime dateTime = lastDate.NotAvailable.AddDays(1);
                            context.Availability.Add(new Availability() { NotAvailable = dateTime });
                           

                        }

                    }
                    context.SaveChanges();
                }
                if (context.Availability.Count() == 0)
                {
                    DateTime dateTime = DateTime.Now.Date;

                    for (int i = 1; i < 94; i++)
                    {
    
                        context.Availability.Add(new Availability() { NotAvailable = dateTime });
                        context.SaveChanges();
                        dateTime = dateTime.AddDays(1);
                    }

                }
                if (context.Apartment.Count() == 0)
                {
                    var root1 = System.IO.Directory.GetCurrentDirectory();
                    var amenities = new ApartmentAmenities() { Balcony = false, Wifi = false, Comment = "נא להחזיר דירה נקייה כמו שקבלתם", AirConditioning = true, NumOfPersons = 3, Accessibility = true, Description = "דירה מטופחת וחדשה", Parking = true, Plata = true, NumOfRooms = 5, HotWater = true };
                    context.ApartmentAmenities.Add(amenities);
                    var location = new Location() { Address = "רשי 1", City = "בני ברק", x = 184862, y = 665720 };
                    context.Location.Add(location);
                    var img = new Image() { DiningRoom = "/User_Files/Images/1.jpg", Ketchen = "/User_Files/Images/7.jpg", BedRoom = "/User_Files/Images/13.jpg", LivingRoom = "/User_Files/Images/19.jpg" };
                    context.Image.Add(img);
                    var rent = new Renter() { password = "1234", LastName = "לוי", FirstName = "אפרת", Phone = "0504142222", Mail = "efrat@gmail.com", Username = "efrat" };
                    context.Renter.Add(rent);
                    //var polic = new Policy() { Checkin = 20 / 10 / 19, Checkout = 23 / 10 / 19, Extrabeds = true, Cancellations = "עד 24 שעות לפני" };
                    //context.Policy.Add(polic);

                    context.Apartment.Add(new Apartment() { PriceAdult = 100, PriceChild = 50, Amenities = amenities, Location = location, Image = img/*,Policy=polic*/});


                    var amenities1 = new ApartmentAmenities() { Balcony = false, Wifi = false, Comment = "אין הערות מיוחדות", AirConditioning = true, NumOfPersons = 5, Accessibility = true, Description = "דירה במרכז העיר", HotWater = true, Plata = true, NumOfRooms = 2 };
                    context.ApartmentAmenities.Add(amenities1);
                    var location1 = new Location() { Address = "מאה שערים 2", City = "ירושלים", x = 221480, y = 632465 };
                    context.Location.Add(location1);
                    var img1 = new Image() { DiningRoom = "/User_Files/Images/2.jpg", Ketchen = "/User_Files/Images/8.jpg", BedRoom = "/User_Files/Images/14.jpg", LivingRoom = "/User_Files/Images/20.jpg" };
                    context.Image.Add(img1);
                    var rent1 = new Renter() { password = "5678", LastName = "כהן", FirstName = "יעל", Phone = "058666999", Mail = "yael@gmail.com", Username = "yael" };
                    context.Renter.Add(rent1);
                    //var polic1 = new Policy() { Checkin = 21/09/2019, Checkout = 23 / 09 /2019, Extrabeds = false, Cancellations = "אין" };
                    //context.Policy.Add(polic1);

                    context.Apartment.Add(new Apartment() { PriceAdult = 70, PriceChild = 30, Amenities = amenities1, Location = location1, Image = img1/*,Policy= polic1*/ });


                    var amenities2 = new ApartmentAmenities() { Wifi = false, Comment = "אין", AirConditioning = true, NumOfPersons = 15, Accessibility = true, Description = "דירה ענקית ויפה", HotWater = true, Plata = true, NumOfRooms = 8, Balcony = true, Parking = true };
                    context.ApartmentAmenities.Add(amenities2);
                    var location2 = new Location() { Address = "רוטשילד 3", City = "פתח תקווה", x = 189021, y = 666821 };
                    context.Location.Add(location2);
                    var img2 = new Image() { DiningRoom = "/User_Files/Images/5.jpg", Ketchen = "/User_Files/Images/11.jpg", BedRoom = "/User_Files/Images/17.jpg", LivingRoom = "/User_Files/Images/23.jpg" };

                    context.Image.Add(img2);
                    var rent2 = new Renter() { password = "996541", LastName = "חיון", FirstName = "הודיה", Phone = "056669874", Mail = "hodaia@gmail.com", Username = "hodaia" };
                    context.Renter.Add(rent2);
                    //var polic2 = new Policy() { Checkin = 21/09/2019, Checkout = 23 / 09 /2019, Extrabeds = false, Cancellations = "אין" };
                    //context.Policy.Add(polic2);

                    context.Apartment.Add(new Apartment() { PriceAdult = 150, PriceChild = 80, Amenities = amenities2, Location = location2, Image = img2/*,Policy=polic2 */});


                    var amenities3 = new ApartmentAmenities() { AirConditioning = true, NumOfPersons = 10, Accessibility = false, Description = "דירה במיקום שקט ונוח", HotWater = true, Plata = true, NumOfRooms = 4, Balcony = true, Parking = true, Wifi = false };
                    context.ApartmentAmenities.Add(amenities3);
                    var location3 = new Location() { Address = "נועם אלימלך 4", City = "בני ברק", x = 186070, y = 665593 };
                    context.Location.Add(location3);
                    var img3 = new Image() { DiningRoom = "/User_Files/Images/6.jpg", Ketchen = "/User_Files/Images/10.jpg", BedRoom = "/User_Files/Images/16.jpg", LivingRoom = "/User_Files/Images/22.jpg" };
              
                    context.Image.Add(img3);
                    var rent3 = new Renter() { password = "8948521", LastName = "בן שמעון", FirstName = "שמחה", Phone = "0504177788", Mail = "simcha@gmail.com", Username = "simcha" };
                    context.Renter.Add(rent3);
                    //var polic3 = new Policy() { Checkin = 21/09/2019, Checkout = 23 / 09 /2019, Extrabeds = false, Cancellations = "אין" };
                    //context.Policy.Add(polic3);

                    context.Apartment.Add(new Apartment() { PriceAdult = 120, PriceChild = 70, Amenities = amenities3, Location = location3, Image = img3/*, Policy = polic3 */});


                    var amenities4 = new ApartmentAmenities() { AirConditioning = true, NumOfPersons = 12, Accessibility = true, Description = "דירה מרווחת עם מרפסת", HotWater = true, Plata = true, NumOfRooms = 6, Balcony = true, Parking = true, Wifi = false };
                    context.ApartmentAmenities.Add(amenities4);
                    var location4 = new Location() { Address = "הגריפס 3", City = "ירושלים", x = 220804, y = 632118 };
                    context.Location.Add(location4);
                    var img4 = new Image() { DiningRoom = "/User_Files/Images/3.jpg", Ketchen = "/User_Files/Images/9.jpg", BedRoom = "/User_Files/Images/15.jpg", LivingRoom = "/User_Files/Images/21.jpg" };
                    context.Image.Add(img4);
                    var rent4 = new Renter() { password = "589641", LastName = "סילבר", FirstName = "אברהם", Phone = "052646542", Mail = "avram@gmail.com", Username = "avram" };
                    context.Renter.Add(rent4);
                    //var polic4 = new Policy() { Checkin = 21/09/2019, Checkout = 23 / 09 /2019, Extrabeds = false, Cancellations = "אין" };
                    //context.Policy.Add(polic4);

                    context.Apartment.Add(new Apartment() { PriceAdult = 140, PriceChild = 70, Amenities = amenities4, Location = location4, Image = img4/*, Policy = polic4 */});


                    var amenities5 = new ApartmentAmenities() { AirConditioning = true, NumOfPersons = 25, Accessibility = true, Description = "דירה למשפחות גדולות", HotWater = true, Plata = true, NumOfRooms = 12, Balcony = true, Parking = true, Wifi = true };
                    context.ApartmentAmenities.Add(amenities5);
                    var location5 = new Location() { Address = "סיני 1", City = "בית שמש", x = 200057, y = 628365 };
                    context.Location.Add(location5);
                    var img5 = new Image() { DiningRoom = "/User_Files/Images/4.jpg", Ketchen = "/User_Files/Images/10.jpg", BedRoom = "/User_Files/Images/16.jpg", LivingRoom = "/User_Files/Images/22.jpg" };
                    context.Image.Add(img5);
                    var rent5 = new Renter() { password = "986321", LastName = "בן דוב", FirstName = "יהודה", Phone = "0504189898", Mail = "yeuda@gmail.com", Username = "yeuda" };
                    context.Renter.Add(rent5);
                    //var polic5 = new Policy() { Checkin = 21/09/2019, Checkout = 23 / 09 /2019, Extrabeds = false, Cancellations = "אין" };
                    //context.Policy.Add(polic5);

                    context.Apartment.Add(new Apartment() { PriceAdult = 100, PriceChild = 40, Amenities = amenities5, Location = location5, Image = img5/*, Policy = polic5*/ });


                    context.SaveChanges();
                }

            }
            host.Run();
                BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();


    }
}
