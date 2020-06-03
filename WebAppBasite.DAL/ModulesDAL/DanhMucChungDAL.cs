using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppBasite.DAL.BaseDAL;
using WebAppBasite.Models.ProjectModels;

namespace WebAppBasite.DAL.ModulesDAL
{
   public class DanhMucChungDAL : BaseDALClass<DanhMucChung>
    {
        private string _tableName; 
        public DanhMucChungDAL(string tableName) : base(tableName)
        {
            _tableName = tableName;
        }
        /// <summary>
        /// Danh mục bài viết được hiển thị
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DanhMucChung>> GetDanhMucChung()
        {
            string sql = $"SELECT id, TenDanhMuc,MaDanhMuc,LoaiDanhMuc,SoThuTu,TrangThai,idDanhMucCha,Type,Path,Thumbnail,Url FROM  dbo.DanhMucChung WHERE LoaiDanhMuc = 1 AND TrangThai = 1 AND Type <> 0    ORDER BY SoThuTu  ";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<DanhMucChung>(sql, null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }
        public async Task<IEnumerable<DanhMucChung>> GetAbumList()
        {
            string sql = $"SELECT id, TenDanhMuc,MaDanhMuc,LoaiDanhMuc,SoThuTu,TrangThai,idDanhMucCha,Type,Path,Thumbnail,Url FROM  dbo.DanhMucChung WHERE LoaiDanhMuc = 2 AND TrangThai = 1 AND  SoThuTu <> 0  ORDER BY SoThuTu DESC,id DESC ";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<DanhMucChung>(sql, null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }
        public async Task<IEnumerable<DanhMucChung>> GetVideoList()
        {
            string sql = $"SELECT id, TenDanhMuc,MaDanhMuc,LoaiDanhMuc,SoThuTu,TrangThai,idDanhMucCha,Type,Path,Thumbnail,Url FROM  dbo.DanhMucChung WHERE LoaiDanhMuc = 3 AND TrangThai = 1 AND  SoThuTu <> 0  ORDER BY SoThuTu DESC,id DESC";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<DanhMucChung>(sql, null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }
        public async Task<IEnumerable<DanhMucChung>> GetListcateNews()
        {
            string sql = $"SELECT id, TenDanhMuc,MaDanhMuc,LoaiDanhMuc,SoThuTu,TrangThai,idDanhMucCha,Type,Path,Thumbnail, Url,Template FROM  dbo.DanhMucChung WHERE LoaiDanhMuc = 1 AND idDanhMucCha = 0 AND TrangThai = 1 AND Type = 1 AND ShowHome = 1 AND  SoThuTu <> 0  ORDER BY SoThuTu DESC,id DESC";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<DanhMucChung>(sql, null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }
    }

}
