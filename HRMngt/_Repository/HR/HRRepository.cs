using HRMngt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMngt._Repository.HR
{
    public class HRRepository : IHRRepository
    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=HR;Integrated Security=True;";
        public void Add(UserModel user)
        {
            
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserModel user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
