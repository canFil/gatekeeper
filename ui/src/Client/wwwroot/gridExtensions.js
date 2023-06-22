function initGrid(apibaseUrl, path, editTitle, exportName, popupWidth, popupHeight , columns) {
    $(() => {
        $('#grid').dxDataGrid({
            dataSource: DevExpress.data.AspNet.createStore({
                key: 'id',
                loadUrl: `${apibaseUrl}api/${path}/Get`,
                insertUrl: `${apibaseUrl}api/${path}/Insert`,
                updateUrl: `${apibaseUrl}api/${path}/Update`,
                deleteUrl: `${apibaseUrl}api/${path}/Delete`,
                onBeforeSend(method, ajaxOptions) {
                    ajaxOptions.headers = {
                        Authorization: 'Bearer ' + localStorage.getItem("authToken").replaceAll('"', '')
                    };
                },
            }),
            remoteOperations: true,
            filterRow: {
                visible: true,
            },
            headerFilter: {
                visible: true,
            },
            groupPanel: {
                visible: true,
            },
            paging: {
                pageSize: 20,
            },
            pager: {
                visible: true,
                showInfo: true,
                showNavigationButtons: true,
            },
            height: 500,
            showBorders: true,
            editing: {
                mode: 'popup',
                allowAdding: true,
                allowUpdating: true,
                allowDeleting: true,
                useIcons: true,
                popup: {
                    title: editTitle,
                    showTitle: true,
                    width: popupWidth.toString(),
                    height: popupHeight.toString(),
                },
            },
            toolbar: {
                items: [
                    {
                        name: 'addRowButton',
                        showText: 'always',
                        options: {
                            text: 'Kayıt Ekle',
                        }
                    },
                    {
                        name: 'exportButton',
                        showText: 'always',
                        options: {
                            text: 'Excel Çıktı Al',
                        }
                    }
                ],
            },
            export: {
                enabled: true
            },
            onExporting(e) {
                const workbook = new ExcelJS.Workbook();
                const worksheet = workbook.addWorksheet(exportName);

                DevExpress.excelExporter.exportDataGrid({
                    component: e.component,
                    worksheet,
                    autoFilterEnabled: true,
                }).then(() => {
                    workbook.xlsx.writeBuffer().then((buffer) => {
                        saveAs(new Blob([buffer], {type: 'application/octet-stream'}), exportName + '.xlsx');
                    });
                });
                e.cancel = true;
            },
            grouping: {
                autoExpandAll: false,
            },
            columns: JSON.parse(columns)
        });
    });
}