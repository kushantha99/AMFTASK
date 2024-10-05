using Microsoft.AspNetCore.Mvc;
using TaskManagerTest.Models;
using TaskManagerTest.Services;

namespace TaskManagerTest.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly SupabaseService _supabaseService;

        public UserTaskController(SupabaseService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        // GET: UserTask/Index
        public async Task<IActionResult> Index()
        {
            // Get all tasks from the Supabase database
            var tasks = await _supabaseService.GetAllTasks();
            return View(tasks);
        }

        // GET: UserTask/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description")] UserTask task)
        {
            if (ModelState.IsValid)
            {
                await _supabaseService.InsertTask(task);  // Insert task into the database
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: UserTask/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _supabaseService.GetAllTasks();  // Get the task by id
            var userTask = task.Find(t => t.TaskID == id);
            if (userTask == null)
            {
                return NotFound();
            }
            return View(userTask);
        }

        // POST: UserTask/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskID,Title,Description")] UserTask task)
        {
            if (id != task.TaskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _supabaseService.UpdateTask(task);  // Update task in the database
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: UserTask/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine($"Received ID for deletion: {id}");

            var tasks = await _supabaseService.GetAllTasks(); // Get the task list
            var userTask = tasks.Find(t => t.TaskID == id); // Find the task by id

            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask); // Return the view with the task to delete
        }

        // POST: UserTask/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int TaskID)
        {
            Console.WriteLine($"Received ID for deletion: {TaskID}");
            await _supabaseService.DeleteTask(TaskID); // Call the delete method
            return RedirectToAction(nameof(Index)); // Redirect to the Index after deletion
        }

        public async Task<IActionResult> Details(int id)
        {
            var tasks = await _supabaseService.GetAllTasks();
            var userTask = tasks.Find(t => t.TaskID == id);

            if (userTask == null)
            {
                return NotFound(); // Return 404 if the task is not found
            }

            return View(userTask); // Pass the task to the Details view
        }
    }
}
