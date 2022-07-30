using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface Ipost_Repository
    {
        public List<API_Post> GetAll();
        public API_Post Insert(API_Post post);
        public bool Delete(int postid);
        public bool Update(API_Post post);
    }
}
