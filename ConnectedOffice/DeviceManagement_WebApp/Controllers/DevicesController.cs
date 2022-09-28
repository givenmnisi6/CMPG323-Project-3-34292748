using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Authorization;

namespace DeviceManagement_WebApp.Controllers
{
    //Authorize so that the user can log in before accessing any of the items
    [Authorize]
    public class DevicesController : Controller
    {
        private readonly ConnectedOfficeContext _context;
        private readonly IDevicesRepository _devicesRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IZonesRepository _zonesRepository;

        //Instatiates the devicesRepository, categoriesRepository, zonesRepository
        //Since the Category & Zone is needed when adding a device, so they must be instatiated
        public DevicesController(IDevicesRepository devicesRepository, ICategoriesRepository categoriesRepository, IZonesRepository zonesRepository)
        {
            _devicesRepository = devicesRepository;
            _categoriesRepository = categoriesRepository;
            _zonesRepository = zonesRepository;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            return View(_devicesRepository.GetAll());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _devicesRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoriesRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zonesRepository.GetAll(), "ZoneId", "ZoneName");
            return View();
        }

        // POST: Devices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _devicesRepository.Add(device);
            return RedirectToAction(nameof(Index));
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _devicesRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoriesRepository.GetAll(), "CategoryId", "CategoryName", device.CategoryId);
            ViewData["ZoneId"] = new SelectList(_zonesRepository.GetAll(), "ZoneId", "ZoneName", device.ZoneId);
            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                _devicesRepository.Update(device);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
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

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _devicesRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device = _devicesRepository.GetById(id);
            _devicesRepository.Remove(device);
            return RedirectToAction(nameof(Index));
        }
        //Checks whether the Device Exists
        private bool DeviceExists(Guid id)
        {
            return _devicesRepository.Exists(id);
        }
    }
}
