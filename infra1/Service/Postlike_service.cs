using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra1.Repository
{
    public class Postlike_service : Ipostlike_service
    {
        private readonly Ipostlike_Repository ipostlike_;
        public Postlike_service(Ipostlike_Repository ipostlike_)
        {
            this.ipostlike_ = ipostlike_;
        }

        public bool Delete(int id)
        {
            return ipostlike_.Delete(id);
        }

        public List<API_Postlike> GetAll()
        {
            return ipostlike_.GetAll();
        }

        public API_Postlike Insert(API_Postlike postlike)
        {
            return ipostlike_.Insert(postlike);
        }

        public int countpostlike(int postid) 
        {
            return ipostlike_.countpostlike(postid);
        }

        public bool Update(API_Postlike postlike)
        {
            return ipostlike_.Update(postlike);
        }
    }
}
