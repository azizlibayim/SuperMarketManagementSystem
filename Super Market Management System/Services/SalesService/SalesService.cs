using Super_Market_Management_System.Common.Enums;
using Super_Market_Management_System.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Services.SalesService
{
    public class SalesService
    {
        public List<Product> Products;
        public List<SalesItem> SalesItems;
        public List<Sale> Sales;

        public SalesService()
        {
            Products = new();
            SalesItems = new();
            Sales = new();
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        public int AddProduct(string name, string code, int quantity,
            string category, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FormatException("Name is empty!");

            if (string.IsNullOrWhiteSpace(code))
                throw new FormatException("Code is invalid!");

            if (quantity < 0)
                throw new FormatException("Quantity is invalid!");
            if (price < 0)
                throw new FormatException("Price is lower than 0!");

            if (string.IsNullOrWhiteSpace(category))
                throw new FormatException("Category field is empty!");


            bool isSuccessful
                = Enum.TryParse<Category>( category, true, out Category parsedCategory);

            if (!isSuccessful)
            {
                throw new InvalidDataException("Category not found!");
            }

            var newProduct = new Product
            {
                Name = name,
                Code = code,
                Quantity  = quantity,
                Category = parsedCategory,
                Price = price
            };

            Products.Add(newProduct);

            return newProduct.Id;
        }

        public void RemoveProductByName(string name )
        {
            var existingProduct = Products.FirstOrDefault(x => x.Name == name);

            if (existingProduct == null)
                throw new Exception($"{name} not found!");
            Products = Products.Where(x => x.Name != name).ToList();
        }
        public void RemoveProductByPrice (decimal price)
        {
            var existingProduct = Products.FirstOrDefault(x=>x.Price == price);
            if (existingProduct == null)
                throw new Exception($"{price} not found!");
            Products = Products.Where (x => x.Price != price).ToList();
        }

        //public void RemoveProductByCategory(Category)
        //{
        //    var existingProduct = Products.FirstOrDefault (x => x.Category == Category);
        //    if (existingProduct == null)
        //        throw new Exception($"{product.Id} not found!");
        //    Products = Products.Where (x => x.Category != category).ToList();
        //}

        public void RemoveProductById (int Id)
        {
            var existingProduct = Products.FirstOrDefault (x =>x.Id == Id);
            if (existingProduct == null)
                throw new Exception($"{Id} not found!");
            Products = Products.Where(x => x.Id != Id).ToList();
        }
        public void UpdateProductQuantity (int Id)
        {
            var existingProduct = Products.FirstOrDefault(x => x.Id == Id);
            if (existingProduct == null)
                throw new Exception($"{Id} not found!");



        }


        public List<Patient> GetPatients()
        {
            return Patients;
        }

        public int AddPatient(string name, string surname, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FormatException("Name is empty!");

            if (string.IsNullOrWhiteSpace(surname))
                throw new FormatException("Surname is empty!");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new FormatException("Phone number is empty!");

            var newPatient = new Patient
            {
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber
            };

            Patients.Add(newPatient);

            return newPatient.Id;
        }

        public void DeletePatinet(int patientId)
        {
            var existingPatient = Patients.FirstOrDefault(x => x.Id == patientId);

            if (existingPatient is null)
                throw new Exception($"Patient with ID {patientId} not found!");

            Patients = Patients.Where(x => x.Id != patientId).ToList();
        }

        public List<Meeting> GetMeetings()
        {
            return Meetings;
        }

        public int AddMeeting(int doctorId, int patientId, string purpose, DateTime date)
        {
            if (doctorId < 0)
                throw new FormatException("Doctor ID is invalid!");

            if (patientId < 0)
                throw new FormatException("Patient ID is invalid!");

            if (string.IsNullOrWhiteSpace(purpose))
                throw new FormatException("Purpose is empty!");

            //if (date.CompareTo(DateTime.Now) < 0)
            if (date <= DateTime.Now)
                throw new InvalidDataException("Can not book meetings earlier than now!");

            var existingDoctor = Doctors.FirstOrDefault(x => x.Id == doctorId);
            if (existingDoctor is null)
                throw new InvalidDataException("Doctor does not exist!");

            var existingPatient = Patients.FirstOrDefault(x => x.Id == patientId);
            if (existingPatient is null)
                throw new InvalidDataException("Patient does not exist!");

            var newMeeting = new Meeting
            {
                Doctor = existingDoctor,
                Patient = existingPatient,
                Purpose = purpose,
                Date = date
            };

            Meetings.Add(newMeeting);

            return newMeeting.Id;
        }

        public void DeleteMeeting(int meetingId)
        {
            var existingMeeting = Meetings.FirstOrDefault(x => x.Id == meetingId);

            if (existingMeeting is null)
                throw new Exception($"Meeting with ID {meetingId} not found!");

            Meetings = Meetings.Where(x => x.Id != meetingId).ToList();
        }

        public Report GetReport(DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1).AddSeconds(-1);

            if (startDate > endDate)
                throw new InvalidDataException("Start date can not be greater than end date!");

            var meetings = Meetings.Where(x => x.Date >= startDate && x.Date <= endDate);

            int count = meetings.Count();
            decimal income = meetings.Sum(x => x.Doctor.PricePerSession);

            return new Report(count, income);
        }
    }
}
