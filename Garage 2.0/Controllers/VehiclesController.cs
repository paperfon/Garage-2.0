using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Models;

namespace Garage_2._0.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage_2_0Context _context;

        public VehiclesController(Garage_2_0Context context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicle.ToListAsync());
        }

        // GET: Vehicles Overview
        public async Task<IActionResult> Overview()
        {
            var vehicles = await _context.Vehicle.ToListAsync();

            var model = vehicles.Select(v => new VehicleOverviewModel()
            {
                Typ = v.Typ,
                RegNr = v.RegNr,
                Color = v.Color,
                TimeOfParking = v.TimeOfParking
            }).ToList();

            return View(model);
        }

        // GET: Vehicles Other information
        public async Task<IActionResult> OtherDetails()
        {
            var vehicles = await _context.Vehicle.ToListAsync();

            var model = vehicles.Select(v => new VehicleOtherInfoModel()
            {
                NumnOfWheels = v.NumnOfWheels,
                Brand = v.Brand,
                Model = v.Model
            }).ToList();

            return View(model);
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegNr,Typ,NumnOfWheels,Color,Model,Brand")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.TimeOfParking = DateTime.UtcNow;
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegNr,Typ,NumnOfWheels,Color,Model,Brand")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            // Adding the time of parking
            //var editable =  await _context.Vehicle.AsNoTracking().FindAsync(id);
            //var time = editable.TimeOfParking;
            // https://stackoverflow.com/questions/26546891/how-keep-original-value-for-some-field-when-execute-edit-on-mvc


            if (ModelState.IsValid)
            {
                try
                {
                    //vehicle.TimeOfParking = time;
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }

        // Filter
        public async Task<IActionResult> Filter(string regnr)
        {
            var filtermodel = string.IsNullOrWhiteSpace(regnr) ?
                 await _context.Vehicle.ToListAsync() :
                await _context.Vehicle.Where(m => m.RegNr == regnr).ToListAsync();
            return View(nameof(Index), filtermodel);
        }

        // Receipt
        public async Task<IActionResult> Receipt(int? id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);

            var endtime = DateTime.UtcNow;
            var startime = vehicle.TimeOfParking;
            var parkingduration = endtime - startime;
            double parkingduration2 = (endtime - startime).TotalHours;
            double price = 100 * parkingduration2;

            var model = new ReceiptViewModel
            {
                RegNr = vehicle.RegNr,
                TimeOfParking = vehicle.TimeOfParking,
                TimeOfUnParking = endtime,
                TotalTimeOfParking = parkingduration2,
                Price = price
            };

            //var model = vehicles.Select(v => new VehicleOtherInfoModel()
            //{
            //    NumnOfWheels = v.NumnOfWheels,
            //    Brand = v.Brand,
            //    Model = v.Model
            //}).ToList();

            return View(model);
        }
    }
}
