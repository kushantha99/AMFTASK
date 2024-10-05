using Supabase;
using TaskManagerTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagerTest.Services
{
    public class SupabaseService
    {
        private readonly Client _supabaseClient;

        // Constructor to initialize the Supabase client
        public SupabaseService(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        // Get all tasks from the usertask table
        public async Task<List<UserTask>> GetAllTasks()
        {
            var response = await _supabaseClient.From<UserTask>().Get();
            return response.Models;
        }

        // Insert a new task into the usertask table
        public async Task InsertTask(UserTask task)
        {
            await _supabaseClient.From<UserTask>().Insert(task);
        }

        // Update an existing task in the usertask table
        public async Task UpdateTask(UserTask task)
        {
            await _supabaseClient.From<UserTask>().Update(task);
        }

        // Delete a task by its ID from the usertask table
        public async Task DeleteTask(int taskId)
        {
            var taskToDelete = new UserTask { TaskID = taskId };
            var response = await _supabaseClient.From<UserTask>().Delete(taskToDelete);

          
        }
    }
}
