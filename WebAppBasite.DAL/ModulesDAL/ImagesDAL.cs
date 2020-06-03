using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppBasite.DAL.BaseDAL;
using WebAppBasite.Models.ProjectModels;

namespace WebAppBasite.DAL.ModulesDAL
{
  public  class ImagesDAL : BaseDALClass<Images>
    {
        private string _tableName;
        public ImagesDAL(string tableName) : base(tableName)
        {
            _tableName = tableName;
        }

        public async Task<IEnumerable<Images>> GetSlide()
        {
            string sql = $"SELECT id, page_kind_appear,position_inpage, type, order_inpage, main_content, alter_content, url,tooltip FROM  dbo.Images WHERE  page_kind_appear= 1 ORDER BY id DESC";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<Images>(sql, null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }

        public async Task<IEnumerable<Images>> GetImageService()
        {
            string sql = $"SELECT TOP 4 id, page_kind_appear,position_inpage, type, order_inpage, main_content, alter_content, url,tooltip FROM  dbo.Images WHERE  page_kind_appear= 2 ORDER BY id DESC";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<Images>(sql, null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }
        public async Task<IEnumerable<Images>> GetImageServiceByType(int type)
        {
            string sql = $"SELECT d.id DmID, gi.AlbumId,gi.ImagId, n.id,n.page_kind_appear,n.position_inpage,n.type,n.order_inpage,n.main_content,n.alter_content,n.url,n.tooltip FROM  dbo.Images n JOIN dbo.GroupAlbumImg gi  ON gi.ImagId = n.id JOIN dbo.DanhMucChung d ON gi.AlbumId = d.id  WHERE  n.page_kind_appear=" + type + "ORDER BY n.id DESC";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<Images>(sql, null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }
        public async Task<IEnumerable<Images>> GetVideoByType()
        {
            string sql = $"SELECT TOP 6 d.id DmId, gi.AlbumId ,gi.ImagId, n.id,n.page_kind_appear,n.position_inpage,n.type,n.order_inpage,n.main_content,n.alter_content,n.url,n.tooltip, n.AlbumId FROM  dbo.Images n LEFT JOIN dbo.GroupAlbumImg gi  ON gi.ImagId = n.id JOIN dbo.DanhMucChung d ON gi.AlbumId = d.id  WHERE  n.page_kind_appear = 5";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<Images>(sql, null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }

        public async Task<List<Images>> GetImgbyAlbumId(int albumId)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@albumid", albumId);
                var result = await connection.QueryAsync<Images>("fe_GetImgbyAlbumId", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result.AsList();
            }
        }
    }
}
