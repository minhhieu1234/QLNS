﻿using HRMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRMngt.Model
{
    public interface IUserRepository
    {
        void Add(UserModel userModel);
        void Update(UserModel userModel);
        void Delete(string id);
        IEnumerable<UserModel> GetAll();
        IEnumerable<UserModel> GetByValue(); // Search
        List<string> GetUserIdNName(); // Get "ID - Name"
        string GetNameById(string id);
        
        UserModel GetById(string id);
    }
}
