
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;


namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolController : ControllerBase
{
    private readonly AppDbContext _context;

    public SchoolController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<School>>> GetAllSchools()
    {
        return await _context.Schools.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<School>> GetSchoolById(int id)
    {
        var school = await _context.Schools.FindAsync(id);
        if (school == null) return NotFound();
        return school;
    }

    [HttpPost]
    public async Task<ActionResult<School>> CreateSchool(School school)
    {
        _context.Schools.Add(school);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSchoolById), new { id = school.Id }, school);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSchool(int id, School updatedSchool)
    {
        if (id != updatedSchool.Id) return BadRequest();

        var existingSchool = await _context.Schools.FindAsync(id);
        if (existingSchool == null) return NotFound();

        existingSchool.Name = updatedSchool.Name;
        existingSchool.Address = updatedSchool.Address;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSchool(int id)
    {
        var school = await _context.Schools.FindAsync(id);
        if (school == null) return NotFound();

        _context.Schools.Remove(school);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
