using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FSH.WebApi.Application.BaseService;

public interface IBaseService<in TDetails, TCreate, TUpdate, TEntity>
    where TDetails : class
    where TCreate : class
    where TUpdate : class
    where TEntity : class
{
    public Task<LoadResult> GetQueryableData(DataSourceLoadOptionsBase dataSourceLoadOptions);

    public TCreate Create(TCreate data);

    public TUpdate Update(TUpdate data);

    public bool Delete(TDetails data);
}