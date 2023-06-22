using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FSH.WebApi.Host;

public class DataSourceLoadOptionsBinder : IModelBinder
{
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="bindingContext"></param>
    /// <returns></returns>
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        DataSourceLoadOptions sourceLoadOptions = new DataSourceLoadOptions();
        DataSourceLoadOptionsParser.Parse((DataSourceLoadOptionsBase) sourceLoadOptions, (Func<string, string>) (key => ((IEnumerable<string>) bindingContext.ValueProvider.GetValue(key)).FirstOrDefault<string>()));
        bindingContext.Result = ModelBindingResult.Success((object) sourceLoadOptions);
        return (Task) Task.FromResult<bool>(true);
    }
}