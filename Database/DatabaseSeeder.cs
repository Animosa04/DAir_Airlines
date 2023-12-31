﻿using Database.DTOs;

namespace Database
{
    public static class DatabaseSeeder
    {
        public static void Seed(DAirDatabaseContext context)
        {
            SeedAircraftModels(context);
            SeedAircraft(context);
            SeedEmployees(context);
            SeedLanguages(context);
            SeedLanguages(context);
            SeedCabinCrewMembers(context);
            SeedCabinCrewLanguages(context);
            SeedPilots(context);
            SeedPilotCertifications(context);
            SeedPilotRatings(context);
            SeedPilotConflicts(context);
            SeedFlightState(context);
            SeedFlights(context);
            SeedDailyTrips(context);
            SeedEmployeeAssignments(context);
        }

        private static void SeedAircraftModels(DAirDatabaseContext context)
        {
            // Check if the data is already seeded
            if (!context.AircraftModels.Any())
            {
                var models = new List<AircraftModelDto>
            {
                new AircraftModelDto { Model = "Boeing 737", Manufacturer = "Boeing", PassengerCapacity = 189 },
                new AircraftModelDto { Model = "Airbus A320", Manufacturer = "Airbus", PassengerCapacity = 150 },
                new AircraftModelDto { Model = "Boeing 747", Manufacturer = "Boeing", PassengerCapacity = 524 },
                new AircraftModelDto { Model = "Airbus A350", Manufacturer = "Airbus", PassengerCapacity = 440 },
                new AircraftModelDto { Model = "Embraer E190", Manufacturer = "Embraer", PassengerCapacity = 114 },
                new AircraftModelDto { Model = "Bombardier CRJ-900", Manufacturer = "Bombardier", PassengerCapacity = 76 },
                new AircraftModelDto { Model = "Boeing 777", Manufacturer = "Boeing", PassengerCapacity = 550 },
                new AircraftModelDto { Model = "Airbus A330", Manufacturer = "Airbus", PassengerCapacity = 440 },
                new AircraftModelDto { Model = "Airbus A380", Manufacturer = "Airbus", PassengerCapacity = 853 },
                new AircraftModelDto { Model = "Embraer E145", Manufacturer = "Embraer", PassengerCapacity = 50 }
            };

                context.AircraftModels.AddRange(models);
                context.SaveChanges();
            }
        }

        private static void SeedAircraft(DAirDatabaseContext context)
        {
            if (!context.Aircrafts.Any())
            {
                var aircrafts = new List<AircraftDto>
        {
            new AircraftDto { RegistrationNumber = "SG101", AircraftModel = "Boeing 737", YearOfManufacture = 2019 },
            new AircraftDto { RegistrationNumber = "SG102", AircraftModel = "Airbus A320", YearOfManufacture = 2018 },
            new AircraftDto { RegistrationNumber = "SG103", AircraftModel = "Boeing 747", YearOfManufacture = 2017 },
            new AircraftDto { RegistrationNumber = "SG104", AircraftModel = "Airbus A350", YearOfManufacture = 2016 },
            new AircraftDto { RegistrationNumber = "SG105", AircraftModel = "Embraer E190", YearOfManufacture = 2019 },
            new AircraftDto { RegistrationNumber = "SG106", AircraftModel = "Bombardier CRJ-900", YearOfManufacture = 2018 },
            new AircraftDto { RegistrationNumber = "SG107", AircraftModel = "Boeing 777", YearOfManufacture = 2020 },
            new AircraftDto { RegistrationNumber = "SG108", AircraftModel = "Airbus A330", YearOfManufacture = 2021 },
            new AircraftDto { RegistrationNumber = "SG109", AircraftModel = "Airbus A380", YearOfManufacture = 2022 },
            new AircraftDto { RegistrationNumber = "SG110", AircraftModel = "Embraer E145", YearOfManufacture = 2015 }
        };

                context.Aircrafts.AddRange(aircrafts);
                context.SaveChanges();
            }
        }

        private static void SeedEmployees(DAirDatabaseContext context)
        {
            if (!context.Employees.Any())
            {
                var employees = new List<EmployeeDto>
        {
            new EmployeeDto { EmployeeNumber = "E001", EmployeeName = "John Doe" },
            new EmployeeDto { EmployeeNumber = "E002", EmployeeName = "Jane Smith" },
            new EmployeeDto { EmployeeNumber = "E003", EmployeeName = "Alice Johnson" },
            new EmployeeDto { EmployeeNumber = "E004", EmployeeName = "Bob Williams" },
            new EmployeeDto { EmployeeNumber = "E005", EmployeeName = "Charlie Brown" },
            new EmployeeDto { EmployeeNumber = "E006", EmployeeName = "Eve Martin" },
            new EmployeeDto { EmployeeNumber = "E007", EmployeeName = "David Jones" },
            new EmployeeDto { EmployeeNumber = "E008", EmployeeName = "Ella Davis" },
            new EmployeeDto { EmployeeNumber = "E009", EmployeeName = "Frank Wilson" },
            new EmployeeDto { EmployeeNumber = "E010", EmployeeName = "Grace Taylor" }
        };

                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }

        private static void SeedLanguages(DAirDatabaseContext context)
        {
            if (!context.Languages.Any())
            {
                var languages = new List<LanguageDto>
        {
            new LanguageDto { LanguageName = "English" },
            new LanguageDto { LanguageName = "Spanish" },
            new LanguageDto { LanguageName = "French" },
            new LanguageDto { LanguageName = "German" },
            new LanguageDto { LanguageName = "Chinese" }
        };

                context.Languages.AddRange(languages);
                context.SaveChanges();
            }
        }

        private static void SeedCabinCrewMembers(DAirDatabaseContext context)
        {
            if (!context.CabinCrewMembers.Any())
            {
                var cabinCrewMembers = new List<CabinCrewMemberDto>
        {
            new CabinCrewMemberDto { CabinCrewMemberNumber = "CC001", CrewMemberEmployeeNumber = "E001", Position = "Pursuer" },
            new CabinCrewMemberDto { CabinCrewMemberNumber = "CC002", CrewMemberEmployeeNumber = "E002", Position = "Flight Attendant" },
            new CabinCrewMemberDto { CabinCrewMemberNumber = "CC003", CrewMemberEmployeeNumber = "E003", Position = "Flight Attendant" },
            new CabinCrewMemberDto { CabinCrewMemberNumber = "CC004", CrewMemberEmployeeNumber = "E004", Position = "Flight Attendant" },
            new CabinCrewMemberDto { CabinCrewMemberNumber = "CC005", CrewMemberEmployeeNumber = "E005", Position = "Pursuer" }
        };

                context.CabinCrewMembers.AddRange(cabinCrewMembers);
                context.SaveChanges();
            }
        }

        private static void SeedCabinCrewLanguages(DAirDatabaseContext context)
        {
            if (!context.CabinCrewLanguages.Any())
            {
                var cabinCrewLanguages = new List<CabinCrewLanguagesDto>
        {
            new CabinCrewLanguagesDto { CabinCrewMemberNumber = "CC001", LanguageID = 1 },
            new CabinCrewLanguagesDto { CabinCrewMemberNumber = "CC001", LanguageID = 2 },
            new CabinCrewLanguagesDto { CabinCrewMemberNumber = "CC002", LanguageID = 3 },
            new CabinCrewLanguagesDto { CabinCrewMemberNumber = "CC003", LanguageID = 1 },
            new CabinCrewLanguagesDto { CabinCrewMemberNumber = "CC004", LanguageID = 2 },
            new CabinCrewLanguagesDto { CabinCrewMemberNumber = "CC004", LanguageID = 3 },
            new CabinCrewLanguagesDto { CabinCrewMemberNumber = "CC005", LanguageID = 1 },
            new CabinCrewLanguagesDto { CabinCrewMemberNumber = "CC005", LanguageID = 4 }
        };

                context.CabinCrewLanguages.AddRange(cabinCrewLanguages);
                context.SaveChanges();
            }
        }

        private static void SeedPilots(DAirDatabaseContext context)
        {
            if (!context.Pilots.Any())
            {
                var pilots = new List<PilotDto>
        {
            new PilotDto { PilotLicenseNumber = "P001", PilotEmployeeNumber = "E006", Position = "Captain" },
            new PilotDto { PilotLicenseNumber = "P002", PilotEmployeeNumber = "E007", Position = "First Officer" },
            new PilotDto { PilotLicenseNumber = "P003", PilotEmployeeNumber = "E008", Position = "Second Officer" },
            new PilotDto { PilotLicenseNumber = "P004", PilotEmployeeNumber = "E009", Position = "Cadet" },
            new PilotDto { PilotLicenseNumber = "P005", PilotEmployeeNumber = "E010", Position = "Captain" }
        };

                context.Pilots.AddRange(pilots);
                context.SaveChanges();
            }
        }

        private static void SeedPilotCertifications(DAirDatabaseContext context)
        {
            if (!context.PilotCertifications.Any())
            {
                var pilotCertifications = new List<PilotCertificationsDto>
        {
            new PilotCertificationsDto { PilotLicenseNumber = "P001", AircraftModel = "Airbus A350" },
            new PilotCertificationsDto { PilotLicenseNumber = "P001", AircraftModel = "Boeing 747" },
            new PilotCertificationsDto { PilotLicenseNumber = "P002", AircraftModel = "Airbus A350" },
            new PilotCertificationsDto { PilotLicenseNumber = "P003", AircraftModel = "Boeing 777" },
            new PilotCertificationsDto { PilotLicenseNumber = "P004", AircraftModel = "Embraer E145" },
            new PilotCertificationsDto { PilotLicenseNumber = "P005", AircraftModel = "Airbus A350" }
        };

                context.PilotCertifications.AddRange(pilotCertifications);
                context.SaveChanges();
            }
        }

        private static void SeedPilotRatings(DAirDatabaseContext context)
        {
            if (!context.PilotRatings.Any())
            {
                var pilotRatings = new List<PilotRatingsDto>
        {
            new PilotRatingsDto { RatingPilotLicenseNumber = "P001", RatedCabinCrewMemberNumber = "CC003", Rating = 5 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P002", RatedCabinCrewMemberNumber = "CC002", Rating = 2 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P003", RatedCabinCrewMemberNumber = "CC003", Rating = 5 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P004", RatedCabinCrewMemberNumber = "CC001", Rating = 3 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P005", RatedCabinCrewMemberNumber = "CC001", Rating = 4 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P001", RatedCabinCrewMemberNumber = "CC004", Rating = 4 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P002", RatedCabinCrewMemberNumber = "CC003", Rating = 2 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P003", RatedCabinCrewMemberNumber = "CC003", Rating = 3 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P004", RatedCabinCrewMemberNumber = "CC004", Rating = 4 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P005", RatedCabinCrewMemberNumber = "CC002", Rating = 2 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P002", RatedCabinCrewMemberNumber = "CC002", Rating = 2 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P005", RatedCabinCrewMemberNumber = "CC003", Rating = 5 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P002", RatedCabinCrewMemberNumber = "CC003", Rating = 3 },
            new PilotRatingsDto { RatingPilotLicenseNumber = "P004", RatedCabinCrewMemberNumber = "CC002", Rating = 2 }
        };

                context.PilotRatings.AddRange(pilotRatings);
                context.SaveChanges();
            }
        }

        private static void SeedPilotConflicts(DAirDatabaseContext context)
        {
            if (!context.PilotConflicts.Any())
            {
                var pilotConflicts = new List<PilotConflictsDto>
        {
            new PilotConflictsDto { PilotLicenseNumber = "P001", ConflicsWithPilot = "P002" },
            new PilotConflictsDto { PilotLicenseNumber = "P001", ConflicsWithPilot = "P003" },
            new PilotConflictsDto { PilotLicenseNumber = "P002", ConflicsWithPilot = "P004" },
            new PilotConflictsDto { PilotLicenseNumber = "P003", ConflicsWithPilot = "P005" },
            new PilotConflictsDto { PilotLicenseNumber = "P004", ConflicsWithPilot = "P001" },
            new PilotConflictsDto { PilotLicenseNumber = "P005", ConflicsWithPilot = "P003" },
            new PilotConflictsDto { PilotLicenseNumber = "P002", ConflicsWithPilot = "P005" },
            new PilotConflictsDto { PilotLicenseNumber = "P004", ConflicsWithPilot = "P003" },
            new PilotConflictsDto { PilotLicenseNumber = "P003", ConflicsWithPilot = "P002" },
            new PilotConflictsDto { PilotLicenseNumber = "P005", ConflicsWithPilot = "P004" }
        };

                context.PilotConflicts.AddRange(pilotConflicts);
                context.SaveChanges();
            }
        }

        private static void SeedFlightState(DAirDatabaseContext context)
        {
            if (!context.FlightStates.Any())
            {
                var flightStates = new List<FlightStateDto>
        {
            new FlightStateDto { StateName = "Scheduled" },
            new FlightStateDto { StateName = "Delayed" },
            new FlightStateDto { StateName = "En-route" },
            new FlightStateDto { StateName = "Cancelled" }
        };

                context.FlightStates.AddRange(flightStates);
                context.SaveChanges();
            }
        }

        private static void SeedFlights(DAirDatabaseContext context)
        {
            if (!context.Flights.Any())
            {
                var flights = new List<FlightDto>
        {
            new FlightDto
            {
                FlightCode = "F001",
                DepartureAirport = "LAX",
                DestinationAirport = "JFK",
                ScheduledDepartureTime = "01102023 0800",
                ScheduledArrivalTime = "01102023 1600",
                AircraftRegistrationNumber = "SG101",
                CaptainLicenseNumber = "P001",
                FirstOfficerLicenseNumber = "P002",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F002",
                DepartureAirport = "JFK",
                DestinationAirport = "LHR",
                ScheduledDepartureTime = "01102023 18:00",
                ScheduledArrivalTime = "02102023 07:00",
                AircraftRegistrationNumber = "SG103",
                CaptainLicenseNumber = "P001",
                FirstOfficerLicenseNumber = "P003",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F003",
                DepartureAirport = "LHR",
                DestinationAirport = "CDG",
                ScheduledDepartureTime = "02102023 0900",
                ScheduledArrivalTime = "02102023 1030",
                AircraftRegistrationNumber = "SG104",
                CaptainLicenseNumber = "P005",
                FirstOfficerLicenseNumber = "P002",
                CurrentStateID = 2
            },
            new FlightDto
            {
                FlightCode = "F004",
                DepartureAirport = "LAX",
                DestinationAirport = "ORD",
                ScheduledDepartureTime = "02102023 0900",
                ScheduledArrivalTime = "02102023 1200",
                AircraftRegistrationNumber = "SG105",
                CaptainLicenseNumber = "P001",
                FirstOfficerLicenseNumber = "P002",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F005",
                DepartureAirport = "ORD",
                DestinationAirport = "DFW",
                ScheduledDepartureTime = "02102023 1400",
                ScheduledArrivalTime = "02102023 1700",
                AircraftRegistrationNumber = "SG106",
                CaptainLicenseNumber = "P003",
                FirstOfficerLicenseNumber = "P004",
                CurrentStateID = 2
            },
            new FlightDto
            {
                FlightCode = "F006",
                DepartureAirport = "DFW",
                DestinationAirport = "SEA",
                ScheduledDepartureTime = "02102023 1900",
                ScheduledArrivalTime = "02102023 2200",
                AircraftRegistrationNumber = "SG107",
                CaptainLicenseNumber = "P002",
                FirstOfficerLicenseNumber = "P005",
                CurrentStateID = 3
            },
            new FlightDto
            {
                FlightCode = "F007",
                DepartureAirport = "SEA",
                DestinationAirport = "SFO",
                ScheduledDepartureTime = "03102023 0900",
                ScheduledArrivalTime = "03102023 1100",
                AircraftRegistrationNumber = "SG108",
                CaptainLicenseNumber = "P005",
                FirstOfficerLicenseNumber = "P001",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F008",
                DepartureAirport = "SFO",
                DestinationAirport = "MIA",
                ScheduledDepartureTime = "03102023 1300",
                ScheduledArrivalTime = "03102023 2100",
                AircraftRegistrationNumber = "SG109",
                CaptainLicenseNumber = "P004",
                FirstOfficerLicenseNumber = "P003",
                CurrentStateID = 2
            },
            new FlightDto
            {
                FlightCode = "F009",
                DepartureAirport = "MIA",
                DestinationAirport = "BOS",
                ScheduledDepartureTime = "04102023 0800",
                ScheduledArrivalTime = "04102023 1100",
                AircraftRegistrationNumber = "SG110",
                CaptainLicenseNumber = "P003",
                FirstOfficerLicenseNumber = "P005",
                CurrentStateID = 3
            },
            new FlightDto
            {
                FlightCode = "F010",
                DepartureAirport = "BOS",
                DestinationAirport = "IAD",
                ScheduledDepartureTime = "04102023 1300",
                ScheduledArrivalTime = "04102023 1500",
                AircraftRegistrationNumber = "SG101",
                CaptainLicenseNumber = "P002",
                FirstOfficerLicenseNumber = "P004",
                CurrentStateID = 4
            },
            new FlightDto
            {
                FlightCode = "F011",
                DepartureAirport = "JFK",
                DestinationAirport = "ATL",
                ScheduledDepartureTime = "02102023 0700",
                ScheduledArrivalTime = "02102023 0930",
                AircraftRegistrationNumber = "SG105",
                CaptainLicenseNumber = "P001",
                FirstOfficerLicenseNumber = "P002",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F012",
                DepartureAirport = "ATL",
                DestinationAirport = "DEN",
                ScheduledDepartureTime = "02102023 1100",
                ScheduledArrivalTime = "02102023 1315",
                AircraftRegistrationNumber = "SG106",
                CaptainLicenseNumber = "P003",
                FirstOfficerLicenseNumber = "P004",
                CurrentStateID = 2
            },
            new FlightDto
            {
                FlightCode = "F013",
                DepartureAirport = "DEN",
                DestinationAirport = "PHX",
                ScheduledDepartureTime = "02102023 1500",
                ScheduledArrivalTime = "02102023 1630",
                AircraftRegistrationNumber = "SG107",
                CaptainLicenseNumber = "P004",
                FirstOfficerLicenseNumber = "P005",
                CurrentStateID = 3
            },
            new FlightDto
            {
                FlightCode = "F014",
                DepartureAirport = "PHX",
                DestinationAirport = "LAX",
                ScheduledDepartureTime = "03102023 0900",
                ScheduledArrivalTime = "03102023 1030",
                AircraftRegistrationNumber = "SG108",
                CaptainLicenseNumber = "P001",
                FirstOfficerLicenseNumber = "P003",
                CurrentStateID = 4
            },
            new FlightDto
            {
                FlightCode = "F015",
                DepartureAirport = "LAX",
                DestinationAirport = "SEA",
                ScheduledDepartureTime = "03102023 1200",
                ScheduledArrivalTime = "03102023 1400",
                AircraftRegistrationNumber = "SG109",
                CaptainLicenseNumber = "P002",
                FirstOfficerLicenseNumber = "P005",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F016",
                DepartureAirport = "ATL",
                DestinationAirport = "LHR",
                ScheduledDepartureTime = "04102023 1000",
                ScheduledArrivalTime = "05102023 0000",
                AircraftRegistrationNumber = "SG110",
                CaptainLicenseNumber = "P003",
                FirstOfficerLicenseNumber = "P004",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F017",
                DepartureAirport = "LHR",
                DestinationAirport = "LAX",
                ScheduledDepartureTime = "05102023 0200",
                ScheduledArrivalTime = "05102023 1200",
                AircraftRegistrationNumber = "SG109",
                CaptainLicenseNumber = "P005",
                FirstOfficerLicenseNumber = "P001",
                CurrentStateID = 2
            },
            new FlightDto
            {
                FlightCode = "F018",
                DepartureAirport = "LAX",
                DestinationAirport = "DEN",
                ScheduledDepartureTime = "05102023 1400",
                ScheduledArrivalTime = "05102023 1700",
                AircraftRegistrationNumber = "SG108",
                CaptainLicenseNumber = "P004",
                FirstOfficerLicenseNumber = "P002",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F019",
                DepartureAirport = "DEN",
                DestinationAirport = "ORD",
                ScheduledDepartureTime = "05102023 1900",
                ScheduledArrivalTime = "05102023 2200",
                AircraftRegistrationNumber = "SG107",
                CaptainLicenseNumber = "P002",
                FirstOfficerLicenseNumber = "P003",
                CurrentStateID = 2
            },
            new FlightDto
            {
                FlightCode = "F020",
                DepartureAirport = "ORD",
                DestinationAirport = "JFK",
                ScheduledDepartureTime = "06102023 0800",
                ScheduledArrivalTime = "06102023 1100",
                AircraftRegistrationNumber = "SG106",
                CaptainLicenseNumber = "P001",
                FirstOfficerLicenseNumber = "P004",
                CurrentStateID = 3
            },
            new FlightDto
            {
                FlightCode = "F021",
                DepartureAirport = "JFK",
                DestinationAirport = "MIA",
                ScheduledDepartureTime = "06102023 1300",
                ScheduledArrivalTime = "06102023 1600",
                AircraftRegistrationNumber = "SG105",
                CaptainLicenseNumber = "P002",
                FirstOfficerLicenseNumber = "P005",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F022",
                DepartureAirport = "MIA",
                DestinationAirport = "ATL",
                ScheduledDepartureTime = "06102023 1800",
                ScheduledArrivalTime = "06102023 2030",
                AircraftRegistrationNumber = "SG104",
                CaptainLicenseNumber = "P003",
                FirstOfficerLicenseNumber = "P001",
                CurrentStateID = 4
            },
            new FlightDto
            {
                FlightCode = "F023",
                DepartureAirport = "ATL",
                DestinationAirport = "SEA",
                ScheduledDepartureTime = "07102023 0800",
                ScheduledArrivalTime = "07102023 1100",
                AircraftRegistrationNumber = "SG103",
                CaptainLicenseNumber = "P004",
                FirstOfficerLicenseNumber = "P005",
                CurrentStateID = 1
            },
            new FlightDto
            {
                FlightCode = "F024",
                DepartureAirport = "SEA",
                DestinationAirport = "SFO",
                ScheduledDepartureTime = "07102023 1300",
                ScheduledArrivalTime = "07102023 1500",
                AircraftRegistrationNumber = "SG102",
                CaptainLicenseNumber = "P005",
                FirstOfficerLicenseNumber = "P003",
                CurrentStateID = 2
            },
            new FlightDto
            {
                FlightCode = "F025",
                DepartureAirport = "SFO",
                DestinationAirport = "LAX",
                ScheduledDepartureTime = "07102023 1700",
                ScheduledArrivalTime = "07102023 1900",
                AircraftRegistrationNumber = "SG101",
                CaptainLicenseNumber = "P001",
                FirstOfficerLicenseNumber = "P002",
                CurrentStateID = 3
            }
        };

                context.Flights.AddRange(flights);
                context.SaveChanges();
            }
        }

        private static void SeedDailyTrips(DAirDatabaseContext context)
        {
            if (!context.DailyTrips.Any())
            {
                var dailyTrips = new List<DailyTripDto>
        {
            new DailyTripDto { EmployeeNumber = "E001", BaseAirport = "LAX" },
            new DailyTripDto { EmployeeNumber = "E001", BaseAirport = "LAX" },
            new DailyTripDto { EmployeeNumber = "E003", BaseAirport = "JFK" },
            new DailyTripDto { EmployeeNumber = "E008", BaseAirport = "DEN" },
            new DailyTripDto { EmployeeNumber = "E007", BaseAirport = "SFO" },
            new DailyTripDto { EmployeeNumber = "E006", BaseAirport = "SEA" },
            new DailyTripDto { EmployeeNumber = "E007", BaseAirport = "SFO" },
            new DailyTripDto { EmployeeNumber = "E008", BaseAirport = "MIA" },
            new DailyTripDto { EmployeeNumber = "E009", BaseAirport = "BOS" },
            new DailyTripDto { EmployeeNumber = "E010", BaseAirport = "IAD" },
            new DailyTripDto { EmployeeNumber = "E006", BaseAirport = "ATL" },
            new DailyTripDto { EmployeeNumber = "E006", BaseAirport = "ATL" },
            new DailyTripDto { EmployeeNumber = "E008", BaseAirport = "DEN" },
            new DailyTripDto { EmployeeNumber = "E008", BaseAirport = "DEN" },
            new DailyTripDto { EmployeeNumber = "E010", BaseAirport = "PHX" },
            new DailyTripDto { EmployeeNumber = "E001", BaseAirport = "LHR" },
            new DailyTripDto { EmployeeNumber = "E006", BaseAirport = "ATL" },
            new DailyTripDto { EmployeeNumber = "E003", BaseAirport = "MIA" },
            new DailyTripDto { EmployeeNumber = "E006", BaseAirport = "ATL" },
            new DailyTripDto { EmployeeNumber = "E006", BaseAirport = "SFO" },
            new DailyTripDto { EmployeeNumber = "E006", BaseAirport = "LAX" },
            new DailyTripDto { EmployeeNumber = "E007", BaseAirport = "SFO" },
            new DailyTripDto { EmployeeNumber = "E008", BaseAirport = "ORD" },
            new DailyTripDto { EmployeeNumber = "E006", BaseAirport = "ATL" },
            new DailyTripDto { EmployeeNumber = "E010", BaseAirport = "DFW" }
        };

                context.DailyTrips.AddRange(dailyTrips);
                context.SaveChanges();
            }
        }

        private static void SeedEmployeeAssignments(DAirDatabaseContext context)
        {
            if (!context.EmployeeAssignments.Any())
            {
                var employeeAssignments = new List<EmployeeAssignmentDto>
        {
            new EmployeeAssignmentDto { TripID = 1, FlightCode = "F001" },
            new EmployeeAssignmentDto { TripID = 2, FlightCode = "F002" },
            new EmployeeAssignmentDto { TripID = 3, FlightCode = "F003" },
            new EmployeeAssignmentDto { TripID = 4, FlightCode = "F004" },
            new EmployeeAssignmentDto { TripID = 5, FlightCode = "F005" },
            new EmployeeAssignmentDto { TripID = 6, FlightCode = "F006" },
            new EmployeeAssignmentDto { TripID = 7, FlightCode = "F007" },
            new EmployeeAssignmentDto { TripID = 8, FlightCode = "F008" },
            new EmployeeAssignmentDto { TripID = 9, FlightCode = "F009" },
            new EmployeeAssignmentDto { TripID = 10, FlightCode = "F010" },
            new EmployeeAssignmentDto { TripID = 11, FlightCode = "F011" },
            new EmployeeAssignmentDto { TripID = 12, FlightCode = "F012" },
            new EmployeeAssignmentDto { TripID = 13, FlightCode = "F013" },
            new EmployeeAssignmentDto { TripID = 14, FlightCode = "F014" },
            new EmployeeAssignmentDto { TripID = 15, FlightCode = "F015" },
            new EmployeeAssignmentDto { TripID = 16, FlightCode = "F016" },
            new EmployeeAssignmentDto { TripID = 17, FlightCode = "F017" },
            new EmployeeAssignmentDto { TripID = 18, FlightCode = "F018" },
            new EmployeeAssignmentDto { TripID = 19, FlightCode = "F019" },
            new EmployeeAssignmentDto { TripID = 20, FlightCode = "F020" },
            new EmployeeAssignmentDto { TripID = 21, FlightCode = "F021" },
            new EmployeeAssignmentDto { TripID = 22, FlightCode = "F022" },
            new EmployeeAssignmentDto { TripID = 23, FlightCode = "F023" },
            new EmployeeAssignmentDto { TripID = 24, FlightCode = "F024" },
            new EmployeeAssignmentDto { TripID = 25, FlightCode = "F025" }
        };

                context.EmployeeAssignments.AddRange(employeeAssignments);
                context.SaveChanges();
            }
        }
    }
}