using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Domain.Common.Contracts;
using FSH.WebApi.Infrastructure.Persistence.Context;
using Mapster;

namespace FSH.WebApi.Infrastructure.Persistence.Repository;

public class CrudDbRepository<T> : RepositoryBase<T>, ICrudRepository<T>
    where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public CrudDbRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    // We override the default behavior when mapping to a dto.
    // We're using Mapster's ProjectToType here to immediately map the result from the database.
    // This is only done when no Selector is defined, so regular specifications with a selector also still work.
    protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
        specification.Selector is not null
            ? base.ApplySpecification(specification)
            : ApplySpecification(specification, false)
                .ProjectToType<TResult>();

    public IQueryable<T> GetList()
    {
        return _dbContext.Set<T>();
    }
}