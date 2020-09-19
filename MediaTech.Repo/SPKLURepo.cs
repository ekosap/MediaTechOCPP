using MediaTech.Model;
using MediaTech.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTech.Repo
{
    public class SPKLURepo
    {
        private readonly ApplicationDbContext _db;
        public SPKLURepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<SPKLUViewModel>> GetAll()
        {
            List<SPKLUViewModel> hasil = new List<SPKLUViewModel>();
            var data = await _db.SPKLU.ToListAsync();
            hasil = data.Select(x => new SPKLUViewModel()
            {
                Alamat = x.Alamat,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                IsACType = x.IsACType,
                ModifyBy = x.ModifyBy,
                ModifyDate = x.ModifyDate,
                SPKLUId = x.SPKLUId,
                SPKLUName = x.SPKLUName,
                Status = x.Status
            }).ToList();
            return hasil;
        }
        public async Task<bool> Insert(SPKLUViewModel data)
        {
            try
            {
                _db.SPKLU.Add(new SPKLUModel()
                {
                    Alamat = data.Alamat,
                    CreatedBy = data.CreatedBy,
                    CreatedDate = data.CreatedDate,
                    IsACType = data.IsACType,
                    SPKLUName = data.SPKLUName,
                    Status = data.Status
                });
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
