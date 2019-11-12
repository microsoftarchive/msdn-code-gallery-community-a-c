using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using CodeGen.Web.Models;
using CodeGen.Web.Utility;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeGen.Web.Controllers
{
    [EnableCors("AllowCors"), Produces("application/json"), Route("api/Codegen")]
    public class CodegenController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private string conString = "server=DESKTOP-80DEJMQ; uid=sa; pwd=sa@12345;";

        public CodegenController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        #region ++++++ Database +++++++
        // api/Codegen/GetDatabaseList
        [HttpGet, Route("GetDatabaseList"), Produces("application/json")]
        public List<vmDatabase> GetDatabaseList()
        {
            List<vmDatabase> data = new List<vmDatabase>();
            using (SqlConnection con = new SqlConnection(conString))
            {
                int count = 0; con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb') ORDER BY create_date", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            count++;
                            data.Add(new vmDatabase()
                            {
                                DatabaseId = count,
                                DatabaseName = dr[0].ToString()
                            });
                        }
                    }
                }
            }
            return data.ToList();
        }

        // api/Codegen/GetDatabaseTableList
        [HttpPost, Route("GetDatabaseTableList"), Produces("application/json")]
        public List<vmTable> GetDatabaseTableList([FromBody]vmParam model)
        {
            List<vmTable> data = new List<vmTable>();
            string conString_ = conString + " Database=" + model.DatabaseName + ";";
            using (SqlConnection con = new SqlConnection(conString_))
            {
                int count = 0; con.Open();
                DataTable schema = con.GetSchema("Tables");
                foreach (DataRow row in schema.Rows)
                {
                    count++;
                    data.Add(new vmTable()
                    {
                        TableId = count,
                        TableName = row[2].ToString()
                    });
                }
            }

            return data.ToList();
        }

        // api/Codegen/GetDatabaseTableColumnList
        [HttpPost, Route("GetDatabaseTableColumnList"), Produces("application/json")]
        public List<vmColumn> GetDatabaseTableColumnList([FromBody]vmParam model)
        {
            List<vmColumn> data = new List<vmColumn>();
            string conString_ = conString + " Database=" + model.DatabaseName + ";";
            using (SqlConnection con = new SqlConnection(conString_))
            {
                int count = 0; con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME, DATA_TYPE, ISNULL(CHARACTER_MAXIMUM_LENGTH,0), IS_NULLABLE, TABLE_SCHEMA FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + model.TableName + "' ORDER BY ORDINAL_POSITION", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            count++;
                            data.Add(new vmColumn()
                            {
                                ColumnId = count,
                                ColumnName = dr[0].ToString(),
                                DataType = dr[1].ToString(),
                                MaxLength = dr[2].ToString(),
                                IsNullable = dr[3].ToString(),
                                Tablename = model.TableName.ToString(),
                                TableSchema = dr[4].ToString()
                            });
                        }
                    }
                }
            }
            return data.ToList();
        }
        #endregion

        #region +++++ CodeGeneration +++++
        // api/Codegen/GenerateCode
        [HttpPost, Route("GenerateCode"), Produces("application/json")]
        public IActionResult GenerateCode([FromBody]object[] data)
        {
            List<string> spCollection = new List<string>();
            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath; //From wwwroot
                string contentRootPath = _hostingEnvironment.ContentRootPath; //From Others

                var tblColumns = JsonConvert.DeserializeObject<List<vmColumn>>(data[0].ToString());

                string fileContentSet = string.Empty; string fileContentGet = string.Empty;
                string fileContentPut = string.Empty; string fileContentDelete = string.Empty;
                string fileContentVm = string.Empty; string fileContentView = string.Empty;
                string fileContentNg = string.Empty; string fileContentAPIGet = string.Empty;
                string fileContentAPIGetById = string.Empty;

                //SP
                fileContentSet = SpGenerator.GenerateSetSP(tblColumns, webRootPath);
                fileContentGet = SpGenerator.GenerateGetSP(tblColumns, webRootPath);
                fileContentPut = SpGenerator.GeneratePutSP(tblColumns, webRootPath);
                fileContentDelete = SpGenerator.GenerateDeleteSP(tblColumns, webRootPath);
                spCollection.Add(fileContentSet);
                spCollection.Add(fileContentGet);
                spCollection.Add(fileContentPut);
                spCollection.Add(fileContentDelete);

                //VM
                fileContentVm = VmGenerator.GenerateVm(tblColumns, webRootPath);
                spCollection.Add(fileContentVm);

                //VU
                fileContentView = ViewGenerator.GenerateForm(tblColumns, webRootPath);
                spCollection.Add(fileContentView);

                //NG
                fileContentNg = NgGenerator.GenerateNgController(tblColumns, webRootPath);
                spCollection.Add(fileContentNg);

                //API
                fileContentAPIGet = APIGenerator.GenerateAPIGet(tblColumns, webRootPath);
                spCollection.Add(fileContentAPIGet);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return Json(new
            {
                spCollection
            });
        }

        #endregion
    }
}
