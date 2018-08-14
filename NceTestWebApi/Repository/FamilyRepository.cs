using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NceTestWebApi.Models;

namespace NceTestWebApi.Repository
{
    public class FamilyRepository : IFamily
    {
        private nse_testContext DBcontext;

        public FamilyRepository(nse_testContext objFamilyContext)
        {
            this.DBcontext = objFamilyContext;
        }
        public void DeleteFamily(int FamilyId)
        {
            Family family = DBcontext.Family.Find(FamilyId);
            DBcontext.Family.Remove(family);
            DBcontext.SaveChanges();
        }

        public IEnumerable<Family> GetFamilyByUserID(int UserId)
        {
            return DBcontext.Family.Where(x => x.UserId == UserId).ToList();
        }

        public Family GetFamilyByID(int FamilyId, int UserId)
        {
            return DBcontext.Family.Where(x => x.UserId == UserId && x.Id == FamilyId).First();
        }

        public void InsertFamily(Family family)
        {
            DBcontext.Family.Add(family);
            DBcontext.SaveChanges();
        }

        public void Save()
        {
           
        }

        public void UpdateFamily(Family family)
        {
            DBcontext.Entry(family).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DBcontext.SaveChanges();
        }    
    }
}
