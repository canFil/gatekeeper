using DevExtreme.AspNet.Data;

namespace FSH.WebApi.Host;

[ModelBinder(BinderType = typeof (DataSourceLoadOptionsBinder))]
public class DataSourceLoadOptions: DataSourceLoadOptionsBase
{

}