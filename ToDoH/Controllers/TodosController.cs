using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDoH.Data;
using ToDoH.DTO;
using ToDoH.Models.Todos;

namespace ToDoH.Controllers
{
    [Authorize]
    public class TodosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TodosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Render the Razor view with embedded AngularJS app
        public IActionResult Index()
        {
            return View();
        }

        // Get current user's todos
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var todos = _context.Todos
                .Where(t => t.UserId == user.Id)
                .ToList();

            return Json(todos);
        }

        // Add new todo for current user
        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] TodoCreateDto todoDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var todo = new TodoItemModel
            {
                Title = todoDto.Title,
                Completed = todoDto.Completed,
                UserId = user.Id
            };

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return Json(todo);
        }


        // Delete todo by ID, but only if it belongs to the current user
        [HttpPost]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var todo = _context.Todos.FirstOrDefault(t => t.Id == id && t.UserId == user.Id);

            if (todo == null)
                return Json(new { success = false });

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
        [HttpPost]
        public async Task<IActionResult> ToggleCompleted(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var todo = _context.Todos.FirstOrDefault(t => t.Id == id && t.UserId == user.Id);
            if (todo == null)
                return NotFound();

            todo.Completed = !todo.Completed; 
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();

            return Json(todo); 
        }



    }
}
