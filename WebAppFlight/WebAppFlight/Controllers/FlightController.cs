using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Domain;
using Domain.Repository;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebAppFlight.Helpers;
using WebAppFlight.Models;

namespace WebAppFlight.Controllers
{
    public class FlightController : Controller
    {
     
        private IFlightRepository _flightrepos;
        private IAirportRepository _airportRepo;
        private IAirlineCompanyRepository _airlineRepo;
        private IAircraftRepository _aircraftRepo;
        private List<Airport> airports;
        private List<Aircraft> aircrafts;
        private List<Flight> flights;
        private List<Airlinecompany> airlines;
        public FlightController(IFlightRepository flightrepos, IAirportRepository airportRepo,
         IAirlineCompanyRepository airlineRepo, IAircraftRepository aircraftRepo)
        {
            _flightrepos = flightrepos;
            _airportRepo = airportRepo;
            _airlineRepo = airlineRepo;
            _aircraftRepo = aircraftRepo;
            airports = _airportRepo.GetAllAirport();
            flights = _flightrepos.GetAllFlight();
            airlines = _airlineRepo.GetAllAirlines();
            aircrafts = _aircraftRepo.GetAllAircraft();
        }
        public IActionResult Index()
        {
            List<AirportViewModel> AirportList = new List<AirportViewModel>();
            if (airports != null && airports.Any())
            {
                AirportList = (from item in airports
                               select new AirportViewModel
                               {
                                   AirportId = item.Id,
                                   Name = item.Name,
                                   Latitude = item.Latitude,
                                   Longitude = item.Longitude
                               }).ToList();

            }
            ViewData["ListAirport"] = new SelectList(AirportList, "AirportId", "Name");

            List<AirlineCompnayViewModel> AirlinetList = new List<AirlineCompnayViewModel>();
            if (airlines != null && airlines.Any())
            {
                AirlinetList = (from item in airlines

                                select new AirlineCompnayViewModel
                                {
                                    AirlineId = item.Id,
                                    AirlineName = item.Name,
                                    AirlineCode = item.Code
                                }).ToList();

            }
            ViewData["ListOfAirline"] = new SelectList(AirlinetList, "AirlineId", "AirlineName");

            List<AircraftViewModel> AircraftList = new List<AircraftViewModel>();
            if (aircrafts != null && aircrafts.Any())
            {
                AircraftList = (from item in aircrafts
                                select new AircraftViewModel
                                {
                                    AircraftId = item.Id,
                                    AircraftName = item.Name,
                                    AircraftCode = item.Number
                                }).ToList();

            }
            ViewData["ListOfAircraft"] = new SelectList(AircraftList, "AircraftId", "AircraftName");

            return View();
        }
        [HttpGet]
        public JsonResult GetFlightList()
        {
            List<FlightViewModel> FlightLst = new List<FlightViewModel>();
            if (flights != null && flights.Any())
            {
                FlightLst = (from item in flights
                             select new FlightViewModel
                             {
                                 FlightId = item.FlightId,
                                 FlightDeparture = item.FlightDeparture,
                                 FlightArrival = item.FlightArrival,
                                 DepartureAirportName = item.DepartureAirport.Name,
                                 ArrivalAirportName = item.ArrivalAirport.Name,
                                 AirlineName = item.FlightAirline.Name,
                                 AircraftName = item.Aircraft.Name
                             }).ToList();
            }
            return Json(FlightLst);
        }
        [HttpGet]
        public JsonResult GetFlightById(int FlightId)
        {
            Flight flight = _flightrepos.GetFlightByID(FlightId);
            FlightViewModel model = new FlightViewModel();
            if (flight.FlightId == FlightId)
            {
                model.FlightId = flight.FlightId;
                model.FlightDeparture = flight.FlightDeparture;
                model.FlightArrival = flight.FlightArrival;
                model.DepartureAirportName = flight.DepartureAirport.Name;
                model.ArrivalAirportName = flight.ArrivalAirport.Name;
                model.DepartureId = flight.DepartureAirport.Id;
                model.ArrivalId = flight.ArrivalAirport.Id;
                model.AirlineName = flight.FlightAirline.Name;
                model.AirlineId = flight.FlightAirline.Id;
                model.AircraftName = flight.Aircraft.Name;
                model.AircraftId = flight.Aircraft.Id;
            }
            string value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }
        [HttpPost]
        public JsonResult SaveFlight(FlightViewModel model)
        {
            var result = false;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.FlightId > 0)
                    {
                        Flight flight = _flightrepos.GetFlightByID(model.FlightId);
                        flight.FlightDeparture = model.FlightDeparture;
                        flight.FlightArrival = model.FlightArrival;
                        flight.DepartureId = model.DepartureId;
                        flight.ArrivalId = model.ArrivalId;
                        flight.AircraftId = model.AircraftId;
                        flight.AirlineId = model.AirlineId;
                        flight.FlightAirline = airlines.FirstOrDefault(a => a.Id.Equals(model.AirlineId));
                        flight.ArrivalAirport = airports.FirstOrDefault(a => a.Id.Equals(model.ArrivalId));
                        flight.DepartureAirport = airports.FirstOrDefault(a => a.Id.Equals(model.DepartureId));
                        flight.Aircraft = _aircraftRepo.GetAircraftById(model.AircraftId);
                        _flightrepos.EditFlight(flight);

                    }
                    else
                    {
                        Flight flight = new Flight();
                        flight.FlightId = model.FlightId;
                        flight.FlightDeparture = model.FlightArrival;
                        flight.DepartureId = model.DepartureId;
                        flight.ArrivalId = model.ArrivalId;
                        flight.AircraftId = model.AircraftId;
                        flight.AirlineId = model.AirlineId;
                        flight.FlightDeparture = model.FlightDeparture;
                        flight.FlightArrival = model.FlightArrival;
                        flight.FlightAirline = _airlineRepo.GetAirlinecompanyById(model.AirlineId);
                        flight.ArrivalAirport = _airportRepo.GetAirportById(model.ArrivalId);
                        flight.DepartureAirport = _airportRepo.GetAirportById(model.DepartureId);
                        flight.Aircraft = _aircraftRepo.GetAircraftById(model.AircraftId);
                        _flightrepos.AddFlight(flight);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result);
        }
        [HttpPost]
        public JsonResult DeleteFlightRecord(int flightId)
        {
            bool result = _flightrepos.DeleteFlightByID(flightId);
            return Json(result);
        }

        public IActionResult Report()
        {
            List<FlightViewModel> FlightLst = new List<FlightViewModel>();
            if (flights != null && flights.Any())
            {
                FlightLst = (from item in flights
                             select new FlightViewModel
                             {
                                 FlightId = item.FlightId,
                                 FlightDeparture = item.FlightDeparture,
                                 FlightArrival = item.FlightArrival,
                                 DepartureAirportName = item.DepartureAirport.Name,
                                 ArrivalAirportName = item.ArrivalAirport.Name,
                                 AirlineName = item.FlightAirline.Name,
                                 AircraftName = item.Aircraft.Name,
                                 ArrivalAirport = _airportRepo.GetAirportById(item.ArrivalId),
                                 DepartureAirport = _airportRepo.GetAirportById(item.DepartureId) 

            }).ToList();
            }
            return View(CalculateConsumption.CalculateData(FlightLst));
        }
    }
}