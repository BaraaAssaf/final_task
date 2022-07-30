using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface Ipostlike_service
    {
        public List<API_Postlike> GetAll();
        public API_Postlike Insert(API_Postlike postlike);
        public bool Delete(int id);
        public bool Update(API_Postlike postlike);

        public int countpostlike(int postid);
    }
}
