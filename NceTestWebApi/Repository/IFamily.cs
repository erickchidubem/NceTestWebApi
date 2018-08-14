using NceTestWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NceTestWebApi.Repository
{
    interface IFamily
    {
        void InsertFamily(Family family);

        IEnumerable<Family> GetFamilyByUserID(int UserId);

        Family GetFamilyByID(int FamilyId,int UserId);

        void UpdateFamily(Family family);

        void DeleteFamily(int FamilyId);

        void Save();
    }
}
