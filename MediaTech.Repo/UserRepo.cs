using MediaTech.ViewModel;
using System;
using MediaTech.Model;
using MediaTech.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MediaTech.Repo
{
    public class UserRepo
    {
        private readonly ApplicationDbContext db;
        public UserRepo(ApplicationDbContext _db)
        {
            db = _db;
        }

        public List<UserViewModel> GetUser()
        {

            return db.User.Select(x=> new UserViewModel() { 
                   UserId = x.UserId 
            }).ToList(); 
        }
    }
}
