using MediaTech.ViewModel;
using MediaTech.Model;
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


        public UserViewModel GetUserAdmin()
        {
            var data = new UserViewModel();
            data.ListUser = (from User in db.User
                       where(User.UserId == 1)
                       select new UserViewModel {
                            UserId      = User.UserId,     
                            Name        = User.Name,       
                            Address     = User.Address,    
                            Phone       = User.Phone,      
                            Email       = User.Email,      
                            UserName    = User.UserName,   
                            Password    = User.Password,   
                            CreatedDate = User.CreatedDate,
                            CreatedBy   = User.CreatedBy,  
                            ModifyDate  = User.ModifyDate, 
                            ModifyBy    = User.ModifyBy,   
                            RoleId      = User.RoleId,     
                            Status      = User.Status,
                       }).ToList();

            return data;
        }
    }
}
