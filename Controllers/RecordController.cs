using Microsoft.AspNetCore.Mvc;
using ScanInRecords.Models;
using ScanInRecords.Repository;

namespace ScanInRecords.Controllers
{
    public class RecordController : Controller
    {
        private IRecordRepository _iRecordRepository;
        public RecordController(IRecordRepository iRecordRepository)
        {
            _iRecordRepository = iRecordRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _iRecordRepository.GetAllAsync();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Record record)
        {
            if (ModelState.IsValid)
            {
                record.ScanInTime = DateTime.Now;
                await _iRecordRepository.Create(record);
                var latestRecords = await _iRecordRepository.GetAllAsync();
                return PartialView("_RecordPartialView", latestRecords);
            }
            return View(record);
        }
    }
}