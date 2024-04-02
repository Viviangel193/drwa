using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
[Route("[controller]")]
[ApiController]
public class GuruController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GuruController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: guru
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetGuru()
    {
        return await _context.Guru.ToListAsync();
    }

    // GET: guru/{nip}
    [HttpGet("{nip}")]
    public async Task<ActionResult<TodoItem>> GetTodoItem(long nip)
    {
        var todoItem = await _context.Guru.FindAsync(nip);

        if (todoItem == null)
        {
            return NotFound();
        }

        return todoItem;
    }

    // POST: guru
    [HttpPost]
    public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
    {
        _context.Guru.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTodoItem), new { nip = todoItem.Id }, todoItem);
    }
}

[Route("[controller]")]
[ApiController]
public class MapelController : ControllerBase
{
    private readonly ApplicationDbContextt _context;

    public MapelController(ApplicationDbContextt context)
    {
        _context = context;
    }

    // DELETE: mapel/{nip}
    [HttpDelete("{nip}")]
    public async Task<IActionResult> DeleteTodoItem(long nip)
    {
        var todoItem = await _context.Mapel.FindAsync(nip);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.Mapel.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // PUT: mapel
    [HttpPut]
    public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
    {
        if (id != todoItem.Id)
        {
            return BadRequest();
        }

        _context.Entry(todoItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool TodoItemExists(long id)
    {
        return _context.Mapel.Any(e => e.Id == id);
    }
}

namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: userpost
        [HttpGet("userpost")]
        public async Task<ActionResult<UserpostsResponse>> GetUserPosts()
        {
            var userPosts = await _context.Userposts.Include(up => up.Posts).ToListAsync();
            var response = new UserpostsResponse { UserPosts = userPosts };
            return Ok(response);
        }

        // GET: student
        [HttpGet("student")]
        public async Task<ActionResult<StudentsResponse>> GetStudents()
        {
            var students = await _context.Students.Include(s => s.Courses).ToListAsync();
            var response = new StudentsResponse { Students = students };
            return Ok(response);
        }
    }
}

}