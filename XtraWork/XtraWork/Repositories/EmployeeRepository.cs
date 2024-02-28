using Microsoft.EntityFrameworkCore;
using XtraWork.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XtraWork.Repositories;

public class EmployeeRepository
{
    private readonly XtraWorkContext _context;

    public EmployeeRepository(XtraWorkContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _context.Employees
            .Include(x => x.Title)
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .ToListAsync();
    }

    public async Task<Employee> Get(Guid id)
    {
        var data = await _context.Employees
            .Include(x => x.Title)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (data is null)
            throw new Exception();

        return data;
    }

    public async Task<List<Employee>> Search(string keyword)
    {
        return await _context.Employees
            .Include(x => x.Title)
            .Where(x => x.FirstName.Contains(keyword) || x.LastName.Contains(keyword))
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .ToListAsync();
    }

    public async Task<Employee> Create(Employee employee)
    {
        employee.Id = Guid.NewGuid();
        _context.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> Update(Employee employee)
    {
        _context.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task Delete(Guid id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee is null)
            throw new Exception();

        _context.Remove(employee);
        await _context.SaveChangesAsync();
    }
}
