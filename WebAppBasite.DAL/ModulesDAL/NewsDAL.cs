using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppBasite.Common.Dtos;
using WebAppBasite.DAL.BaseDAL;
using WebAppBasite.Models.ProjectModels;

namespace WebAppBasite.DAL.ModulesDAL
{
  public  class NewsDAL : BaseDALClass<News>
    {
        private readonly string _tableName;
        public NewsDAL(string tableName):base(tableName)
        {
            _tableName = tableName;
        }
        public async Task<IEnumerable<News>> GetAllNews()
        {
            string sql = $"SELECT * FROM {_tableName}";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
             var result = await connection.QueryAsync<News>(sql, null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }


        public async Task<IEnumerable<News>> GetListByCate()
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var paramaters = new DynamicParameters();
                var result = await connection.QueryAsync<News>("new_listtop_bycates", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<PagedResult<News>> GetListNewsbyCates(string cate_slug, int page, int pageSize)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@cate_slug", cate_slug);
                var result = await connection.QueryAsync<News>("sp_list_cateNews", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                int totalRow = result.Count();
                result = result .Skip((page - 1) * pageSize).Take(pageSize);
                var paginationSet = new PagedResult<News>()
                {
                    Results = result.ToList(),
                    CurrentPage = page,
                    RowCount = totalRow,
                    PageSize = pageSize
                };
                return paginationSet;
            }
        }
        // Top bài viết
        public async Task<IEnumerable<News>> GetListTophot(int top)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@top", top);
                var result = await connection.QueryAsync<News>("news_list_tophot", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<News>> GetTopNews()
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var paramaters = new DynamicParameters();
                var result = await connection.QueryAsync<News>("news_list_top", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Tìm kiếm theo từ khóa
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public async Task<PagedResult<News>> GetListSearching(string keyWord, int page, int pageSize)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@key", keyWord);
                var result = await connection.QueryAsync<News>("news_list_search", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                int totalRow = result.Count();
                result = result.Skip((page - 1) * pageSize).Take(pageSize);
                var paginationSet = new PagedResult<News>()
                {
                    Results = result.ToList(),
                    CurrentPage = page,
                    RowCount = totalRow,
                    PageSize = pageSize
                };
                return paginationSet;
            }
        }
        /// <summary>
        /// Chi tiết News
        /// </summary>
        /// <param name="cate_slug"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        public async Task<News> GetNewsdetail(string cate_slug, string slug)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@cate_slug", cate_slug);
                paramaters.Add("@slug", slug);
                var result = await connection.QueryAsync<News>("sp_dt_getNewsid", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result.Single();
            }
        }

        /// <summary>
        /// Danh sách các sản phẩm khác
        /// </summary>
        /// <param name="cate_slug">Slug danh mục </param>
        /// <param name="slug"> Slug bài viết</param>
        /// <returns></returns>
        public async Task<IEnumerable<News>> GetlistRelatedNews(string cate_slug, string slug)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@cate_slug", cate_slug);
                paramaters.Add("@slug", slug);
                var result = await connection.QueryAsync<News>("sp_listrelated_news", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Danh sách bài viết theo Tag
        /// </summary>
        /// <param name="tag_slug"></param>
        /// <returns></returns>
        
        public async Task<PagedResult<News>> GetListNewsbyTag(string tag_slug, int page, int pageSize)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@tag_slug", tag_slug);
                var result = await connection.QueryAsync<News>("sp_list_News_byTag", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                int totalRow = result.Count();
                result = result.Skip((page - 1) * pageSize).Take(pageSize);
                var paginationSet = new PagedResult<News>()
                {
                    Results = result.ToList(),
                    CurrentPage = page,
                    RowCount = totalRow,
                    PageSize = pageSize
                };
                return paginationSet;
            }
        }

    }
}
