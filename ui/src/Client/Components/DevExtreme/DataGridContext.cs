namespace FSH.BlazorWebAssembly.Client.Components.DevExtreme;

/// <summary>
/// Abstract base class for the initialization Context of the EntityTable Component.
/// </summary>
public class DataGridContext
{
    public List<object> Fields { get; set; }
    public string Path { get; set; }
    public string EditTitle { get; set; }
    public string ExportName { get; set;}
    public int PopupWidth { get; set; }
    public int PopupHeight { get; set;}

    public DataGridContext(
        string path,
        string editTitle,
        string exportName,
        int popupWidth,
        int popupHeight,
        List<object> fields)
    {
        Path = path;
        EditTitle = editTitle;
        ExportName = exportName;
        PopupWidth = popupWidth;
        PopupHeight = popupHeight;
        Fields = fields;
    }
}