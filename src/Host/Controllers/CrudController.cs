using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using FSH.WebApi.Application.BaseService;

namespace FSH.WebApi.Host.Controllers;

public class CrudController<TDetails, TCreate, TUpdate, TEntity>: VersionNeutralApiController
    where TDetails : class
    where TCreate : class
    where TUpdate : class
    where TEntity : class
{
    private readonly IBaseService<TDetails, TCreate, TUpdate, TEntity> _baseService;

    public CrudController(IBaseService<TDetails, TCreate, TUpdate, TEntity> _baseService)
    {
        this._baseService = _baseService;
    }

    [HttpGet("{action}")]
    [MustHavePermission(FSHAction.View, FSHResource.Users)]
    [OpenApiOperation("Get list of all users.", "")]
    public async Task<LoadResult> Get(DataSourceLoadOptions dataSourceLoadOptions)
    {
        return await _baseService.GetQueryableData(dataSourceLoadOptions);
    }
}