using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Mapster;

namespace FSH.WebApi.Application.BaseService;

public class BaseService<TDetails, TCreate, TUpdate, TEntity>: IBaseService<TDetails, TCreate, TUpdate, TEntity>
    where TEntity : class
    where TDetails : class
    where TCreate : class
    where TUpdate : class
{
    private readonly ICrudRepository<TEntity> _repository;

    public BaseService(ICrudRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<LoadResult> GetQueryableData(DataSourceLoadOptionsBase dataSourceLoadOptions)
    {
        var result = await DataSourceLoader.LoadAsync(_repository.GetList(), dataSourceLoadOptions).ConfigureAwait(false);

        result.data = result.data.Adapt<List<TDetails>>();

        return result;
    }

    public TCreate Create(TCreate data)
    {
        throw new NotImplementedException();
    }

    public TUpdate Update(TUpdate data)
    {
        throw new NotImplementedException();
    }

    public bool Delete(TDetails data)
    {
        throw new NotImplementedException();
    }
}