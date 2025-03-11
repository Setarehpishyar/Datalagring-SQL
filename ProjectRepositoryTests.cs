using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Data;
using ProjectManagementApp.Models;
using System.Linq;
using System.Collections.Generic;
using Xunit;

public class ProjectRepositoryTests
{
    private readonly AppDbContext _context;
    private readonly DbSet<Project> _projects;
    private readonly DbSet<Customer> _customers;

    public ProjectRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase") 
            .Options;

        _context = new AppDbContext(options);
        _projects = _context.Set<Project>(); 
        _customers = _context.Set<Customer>(); 

        
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    [Fact]
    public void Test_AddProject()
    {
        var customer = new Customer { Name = "Customer A" };
        _customers.Add(customer);
        _context.SaveChanges();

        var project = new Project
        {
            Name = "New Project",
            ProjectNumber = "001",
            Status = "In Progress",
            Customer = customer
        };

        _projects.Add(project);
        _context.SaveChanges();

        Assert.Equal(1, _projects.Count());
        Assert.Equal("New Project", _projects.First().Name);
    }

    [Fact]
    public void Test_ProjectRepository_GetProjects()
    {
        var projectList = _projects.ToList();
        Assert.NotEmpty(projectList);
    }
}
