﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeightTracker.Data;
using WeightTracker.Entities;

namespace WeightTracker.Controllers
{
   [Route("trainings")]
    public class TrainingRecordsController : Controller
    {
      private readonly WeightTrackerContext _context;
      private readonly UserManager<User> _userManager;

      public TrainingRecordsController(WeightTrackerContext context, UserManager<User> userManager)
      {
         _context = context;
         _userManager = userManager;
      }

      // GET: TrainingRecords
      [HttpGet]
      public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingRecords.ToListAsync());
        }


        // GET: TrainingRecords/Create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TimeStamp")] TrainingRecord trainingRecord)
        {
            if (ModelState.IsValid)
            {
            var user = await _userManager.GetUserAsync(User);

            trainingRecord.TimeStamp = DateTime.Now;
            trainingRecord.User = user;
            _context.TrainingRecords.Add(trainingRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
            return View(trainingRecord);
        }

        // GET: TrainingRecords/Edit/id
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingRecord = await _context.TrainingRecords.FindAsync(id);
            if (trainingRecord == null)
            {
                return NotFound();
            }
            return View(trainingRecord);
        }

        // POST: TrainingRecords/Edit/id
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TimeStamp")] TrainingRecord trainingRecord)
        {
            if (id != trainingRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingRecordExists(trainingRecord.Id))
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
            return View(trainingRecord);
        }

        // GET: TrainingRecords/Delete/id
        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingRecord = await _context.TrainingRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingRecord == null)
            {
                return NotFound();
            }

            return View(trainingRecord);
        }

        // POST: TrainingRecords/Delete/id
        [HttpPost("delete/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingRecord = await _context.TrainingRecords.FindAsync(id);
            _context.TrainingRecords.Remove(trainingRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingRecordExists(int id)
        {
            return _context.TrainingRecords.Any(e => e.Id == id);
        }
    }
}