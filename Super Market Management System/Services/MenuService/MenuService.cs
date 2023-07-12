using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Services.MenuService
{
    public class MenuService
    {
        private static HospitalService hospitalService = new();

        #region Doctor

        public static void MenuDoctors()
        {
            try
            {
                var doctors = hospitalService.GetDoctors();

                var table = new ConsoleTable("Id", "Name", "Surname",
                    "Price per session", "Department");

                if (doctors.Count == 0)
                {
                    Console.WriteLine("No doctor's yet.");
                    return;
                }

                foreach (var doctor in doctors)
                {
                    table.AddRow(doctor.Id, doctor.Name, doctor.Surname,
                        doctor.PricePerSession, doctor.Department);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuAddDoctor()
        {
            try
            {
                Console.WriteLine("Enter doctor's name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter doctor's surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter doctor's department:");
                string department = Console.ReadLine();

                Console.WriteLine("Enter doctor's session price:");
                decimal pricePerSession = decimal.Parse(Console.ReadLine());

                int doctorId = hospitalService.AddDoctor(name, surname, department, pricePerSession);

                Console.WriteLine($"Added doctor with ID: {doctorId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuDeleteDoctor()
        {
            try
            {
                Console.WriteLine("Enter doctor's ID:");
                int doctorId = int.Parse(Console.ReadLine());

                hospitalService.DeleteDoctor(doctorId);

                Console.WriteLine($"Successfully deleted doctor with ID: {doctorId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        #endregion


        #region Patient

        public static void MenuPatients()
        {
            try
            {
                var patients = hospitalService.GetPatients();

                var table = new ConsoleTable("Id", "Name", "Surname", "Phone Number");

                if (patients.Count == 0)
                {
                    Console.WriteLine("No patients's yet.");
                    return;
                }

                foreach (var patient in patients)
                {
                    table.AddRow(patient.Id, patient.Name, patient.Surname, patient.PhoneNumber);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuAddPatient()
        {
            try
            {
                Console.WriteLine("Enter patient's name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter patient's surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter patient's phone:");
                string phoneNumber = Console.ReadLine();

                int patientId = hospitalService.AddPatient(name, surname, phoneNumber);

                Console.WriteLine($"Added patinet with ID: {patientId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuDeletePatient()
        {
            try
            {
                Console.WriteLine("Enter patinets's ID:");
                int patientId = int.Parse(Console.ReadLine());

                hospitalService.DeletePatinet(patientId);

                Console.WriteLine($"Successfully deleted patient with ID: {patientId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        #endregion


        #region Meetings

        public static void MenuMeetings()
        {
            try
            {
                var meetings = hospitalService.GetMeetings();

                var table = new ConsoleTable("Id", "Doctor Name", "Patient Name",
                    "Purpose", "Date");

                if (meetings.Count == 0)
                {
                    Console.WriteLine("No meetings's yet.");
                    return;
                }

                foreach (var meeting in meetings)
                {
                    table.AddRow(meeting.Id, meeting.Doctor.Name, meeting.Patient.Name,
                        meeting.Purpose, meeting.Date.ToString("MM/dd/yyyy HH:mm"));
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuAddMeeting()
        {
            try
            {
                Console.WriteLine("Enter doctor's ID:");
                int doctorId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter patient's ID:");
                int patientId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter meeting's purpose:");
                string purpose = Console.ReadLine();

                Console.WriteLine("Enter meeting's date (MM/dd/yyyy HH:mm) : ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);

                int meetingId = hospitalService.AddMeeting(doctorId, patientId, purpose, date);

                Console.WriteLine($"Added meeting with ID: {meetingId}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuDeleteMeeting()
        {
            try
            {
                Console.WriteLine("Enter meeting's ID:");
                int meetingId = int.Parse(Console.ReadLine());

                hospitalService.DeleteMeeting(meetingId);

                Console.WriteLine($"Successfully deleted meetings with ID: {meetingId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        #endregion


        #region Report

        public static void MenuReport()
        {
            try
            {
                Console.WriteLine("Enter start date (MM/dd/yyyy): ");
                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                Console.WriteLine("Enter end date (MM/dd/yyyy): ");
                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                var report = hospitalService.GetReport(startDate, endDate);

                Console.WriteLine($"Meeting count: {report.MeetingCount} | Total income: {report.Income}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}