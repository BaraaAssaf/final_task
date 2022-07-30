using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra1.Repository
{
    public class Group_service : Igroup_service
    {
        private readonly Igroup_Repository igroup;
        public Group_service(Igroup_Repository igroup)
        {
            this.igroup = igroup;
        }

        bool Igroup_service.Delete(int groupid)
        {
            return igroup.Delete(groupid);
        }

        List<API_group> Igroup_service.GetAll()
        {
            return igroup.GetAll();
        }

        API_group Igroup_service.Insert(API_group group)
        {
            return igroup.Insert(group);
        }

        bool Igroup_service.Update(API_group group)
        {
            return igroup.Update(group);
        }
    }
}
