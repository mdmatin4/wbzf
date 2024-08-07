﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.DataAccess.Repository
{
    public class PurposeRepository : Repository<Purpose>, IPurposeRepository
    {
        private readonly ApplicationDbContext _db;
        public PurposeRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void update(Purpose purpose)
        {
            var objFromDb = _db.purposes.FirstOrDefault(u => u.Id==purpose.Id);
            if (objFromDb!=null)
            {
                
                if (purpose.Form_url != null)
                {
                    objFromDb.Form_url = purpose.Form_url;
                }
                 if (purpose.Order != null)
                {
                    objFromDb.Order = purpose.Order;
                }
                 if (purpose.Name != null)
                {
                    objFromDb.Name = purpose.Name;
                }
                if (purpose.IsDefault != null)
                {
                    objFromDb.IsDefault = purpose.IsDefault;
                }
               
                objFromDb.Updated_at=DateTime.Now;
            }

        }
        public void Deactive(Purpose purpose)
        {
            var objFromDb = _db.purposes.FirstOrDefault(u => u.Id==purpose.Id);
            if (objFromDb!=null)
            {
                objFromDb.IsActive=false;
                objFromDb.Updated_at=DateTime.Now;
            }
        }
        public void Activate(Purpose purpose)
        {
            var objFromDb = _db.purposes.FirstOrDefault(u => u.Id==purpose.Id);
            if (objFromDb!=null)
            {
                objFromDb.IsActive=false;
                objFromDb.Updated_at=DateTime.Now;
            }
        }
        public void updatestatus(int id)
        {
            var allPurposes = _db.purposes.ToList();
            foreach (var session in allPurposes)
            {
                session.IsDefault = false;
            }
            allPurposes.FirstOrDefault(u => u.Id == id).IsDefault = true;

        }
    }
}
