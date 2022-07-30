using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface Igroup_Repository
    {
        public List<API_group> GetAll();
        public API_group Insert(API_group group);
        public bool Delete(int groupid);
        public bool Update(API_group group);
    }
}
