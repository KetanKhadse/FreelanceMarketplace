using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace CommonLiberaryCore.Helper.JqueryDT
{
    public class jQueryDataTableGridHelper
    {
        public SearchModel BindRequestParam(ControllerBase controllerBase)
        {
            SearchModel searchModel = new SearchModel();
            searchModel.draw = controllerBase.Request.Form["draw"].FirstOrDefault();
            searchModel.start = controllerBase.Request.Form["start"].FirstOrDefault();
            searchModel.length = controllerBase.Request.Form["length"].FirstOrDefault();
            searchModel.sortColumn = controllerBase.Request.Form["columns[" + controllerBase.Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            searchModel.sortColumnDirection = controllerBase.Request.Form["order[0][dir]"].FirstOrDefault();
            searchModel.searchValue = controllerBase.Request.Form["search[value]"].FirstOrDefault();
            searchModel.pageSize = searchModel.length != null ? Convert.ToInt32(searchModel.length) : 0;
            searchModel.skip = searchModel.start != null ? Convert.ToInt32(searchModel.start) : 0;
            searchModel.recordsTotal = 0;

            return searchModel;
        }
        public dynamic RenderGrid(ControllerBase controllerBase, IQueryable dbData)
        {
            try
            {
                var grid = BindRequestParam(controllerBase);

                if (!(string.IsNullOrEmpty(grid.sortColumn) && string.IsNullOrEmpty(grid.sortColumnDirection)))
                {
                    dbData = dbData.OrderBy(grid.sortColumn + " " + grid.sortColumnDirection);
                }

                grid.recordsTotal = dbData.Count();
                var data = dbData.Skip(grid.skip).Take(grid.pageSize);//.ToList();
                var jsonData = new { grid.draw, recordsFiltered = grid.recordsTotal, grid.recordsTotal, data };
                return jsonData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
