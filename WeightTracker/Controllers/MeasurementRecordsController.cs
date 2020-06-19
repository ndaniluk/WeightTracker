using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeightTracker.Data;
using WeightTracker.Entities;

namespace WeightTracker.Controllers
{
   [Route("measurements")]
   public class MeasurementRecordsController : Controller
   {
      private readonly WeightTrackerContext _context;
      private readonly UserManager<User> _userManager;

      public MeasurementRecordsController(WeightTrackerContext context, UserManager<User> userManager)
      {
         _context = context;
         _userManager = userManager;
      }

      // GET: MeasurementRecords
      [HttpGet]
      public async Task<IActionResult> Index()
      {
         var user = await _userManager.GetUserAsync(User);
         return View(await _context.MeasurementRecords.Where(record => record.User == user).ToListAsync());
      }

      // GET: MeasurementRecords/Create
      [HttpGet("create")]
      public IActionResult Create()
      {
         return View();
      }

      // POST: MeasurementRecords/Create
      [HttpPost("create")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Id,Chest,Biceps,Waist,Hips,Thigh,Calf,Height,Weight,TimeStamp")] MeasurementRecord measurementRecord)
      {
         if (ModelState.IsValid)
         {
            var user = await _userManager.GetUserAsync(User);

            measurementRecord.TimeStamp = DateTime.Now;
            measurementRecord.User = user;
            _context.MeasurementRecords.Add(measurementRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(measurementRecord);
      }

      // GET: MeasurementRecords/Edit/id
      [HttpGet("edit/{id:int}")]
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var measurementRecord = await _context.MeasurementRecords.FindAsync(id);
         if (measurementRecord == null)
         {
            return NotFound();
         }
         return View(measurementRecord);
      }

      // POST: MeasurementRecords/Edit/id
      [HttpPost("edit/{id:int}")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Chest,Biceps,Waist,Hips,Thigh,Calf,Height,Weight,TimeStamp")] MeasurementRecord measurementRecord)
      {
         if (id != measurementRecord.Id)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {
            try
            {
               _context.Update(measurementRecord);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!MeasurementRecordExists(measurementRecord.Id))
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
         return View(measurementRecord);
      }

      // GET: MeasurementRecords/Delete/id
      [HttpGet("delete/{id:int}")]
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var measurementRecord = await _context.MeasurementRecords
             .FirstOrDefaultAsync(m => m.Id == id);
         if (measurementRecord == null)
         {
            return NotFound();
         }

         return View(measurementRecord);
      }

      // POST: MeasurementRecords/Delete/id
      [HttpPost("delete/{id:int}"), ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         var measurementRecord = await _context.MeasurementRecords.FindAsync(id);
         _context.MeasurementRecords.Remove(measurementRecord);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool MeasurementRecordExists(int id)
      {
         return _context.MeasurementRecords.Any(e => e.Id == id);
      }
   }
}
