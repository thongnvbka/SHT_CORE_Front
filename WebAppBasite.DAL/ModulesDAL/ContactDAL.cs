using System;
using System.Collections.Generic;
using System.Text;
using WebAppBasite.DAL.BaseDAL;
using WebAppBasite.Models.ProjectModels;

namespace WebAppBasite.DAL.ModulesDAL
{
    public  class ContactDAL : BaseDALClass<Contacts>
    {
        private string _tableName;
        public ContactDAL(string tableName) : base(tableName)
        {
            _tableName = tableName;
        }
    }
}
