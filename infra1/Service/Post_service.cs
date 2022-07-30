using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra1.Repository
{
    public class Post_service : Ipost_service
    {
        private readonly Ipost_Repository ipost;
        public Post_service(Ipost_Repository ipost)
        {
            this.ipost = ipost;
        }

        public bool Delete(int postid)
        {
            return ipost.Delete(postid);
        }

        public List<API_Post> GetAll()
        {
            return ipost.GetAll();
        }

        public API_Post Insert(API_Post post)
        {
            return ipost.Insert(post);
        }

        public bool Update(API_Post post)
        {
            return ipost.Update(post);
        }
    }
}
