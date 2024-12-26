using Microsoft.EntityFrameworkCore;

using PM.Domain.Common.Models;
using PM.Domain.ProjectAggregate;
using PM.Domain.UserAggregate;
using PM.Infrastrcture.Persistence.Interceptors;

namespace PM.Infrastrcture.Persistence;
public class PMDbContext : DbContext
{
    private PublishDomainEventsInterceptors _publishDomainEventsInterceptors;
    private CreatedUpdatedAtInterceptors _createdUpdatedAtInterceptors;
    public PMDbContext(DbContextOptions<PMDbContext> options, PublishDomainEventsInterceptors publishDomainEventsInterceptors, CreatedUpdatedAtInterceptors createdUpdatedAtInterceptors) : base(options)
    {
        _publishDomainEventsInterceptors = publishDomainEventsInterceptors;
        _createdUpdatedAtInterceptors = createdUpdatedAtInterceptors;
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Ignore<List<IDomainEvent>>()
        .ApplyConfigurationsFromAssembly(typeof(PMDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptors);
        optionsBuilder.AddInterceptors(_createdUpdatedAtInterceptors);

        base.OnConfiguring(optionsBuilder);
    }

}