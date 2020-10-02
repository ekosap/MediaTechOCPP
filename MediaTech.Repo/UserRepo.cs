using MediaTech.ViewModel;
using MediaTech.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Security.Cryptography;

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
                             join Role in db.Role
                                    on User.RoleId equals Role.RoleID
                             join UserModify in db.User
                                    on User.ModifyBy equals UserModify.UserId into GetUserModify
                             from gum in GetUserModify.DefaultIfEmpty()
                             join UserCreate in db.User
                                    on User.CreatedBy equals UserCreate.UserId into GetUserCreate
                             from guc in GetUserCreate.DefaultIfEmpty()
                                
                             where Role.RoleName == "Admin"
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
                            StringRole  = Role.RoleName,
                            GetUserModify = gum.Name,
                            GetUserCreate = guc.Name
                       }).ToList();

            return data;
        }

        public  bool Insert (UserViewModel model)
        {
            bool result = false;
            try
            {
                UserModel item = new UserModel()
                {
                    Name        = model.Name,
                    Address     = model.Address,
                    Phone       = model.Phone,
                    Email       = model.Email,
                    Password    = model.Password,
                    CreatedDate = model.CreatedDate,
                    CreatedBy   = model.CreatedBy,
                    RoleId      = 3,
                    Status      = true
                };
                db.User.Add(item);
                db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                result = false;

            }
            
            return result;
        }

        public UserViewModel GetByID(int ID)
        {
            UserViewModel hasil = new UserViewModel();
            hasil = (from User in db.User
                     join Role in db.Role
                            on User.RoleId equals Role.RoleID
                     join UserModify in db.User
                            on User.ModifyBy equals UserModify.UserId into GetUserModify
                     from gum in GetUserModify.DefaultIfEmpty()
                     join UserCreate in db.User
                            on User.CreatedBy equals UserCreate.UserId into GetUserCreate
                     from guc in GetUserCreate.DefaultIfEmpty()
                     where User.UserId == ID
                     select new UserViewModel
                     {
                         UserId=User.UserId,
                         Name = User.Name,
                         Address = User.Address,
                         Phone = User.Phone,
                         Email = User.Email,
                         CreatedDate = User.CreatedDate,
                         ModifyDate = User.ModifyDate,
                         StringRole = Role.RoleName,
                         GetUserModify = gum.Name,
                         GetUserCreate = guc.Name,
                         Status = User.Status,
                         Password=User.Password

                     }).FirstOrDefault();
            return hasil;
        }

        public  bool Update(UserViewModel model)
        {
            bool result = false;
            try
            {
                UserModel item = db.User.Find(model.UserId);
                item.Name          = model.Name;
                item.Address       = model.Address;
                item.Phone         = model.Phone;
                item.Email         = model.Email;
                item.ModifyDate    = DateTime.Now;
                item.ModifyBy      = model.ModifyBy;
                db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
