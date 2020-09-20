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
        public async Task<MetadataViewModel> Insert(SPKLUViewModel data)
        {
            try
            {
                var dataDB = await _db.SPKLU.Where(x => x.SPKLUName.Contains(data.SPKLUName)).ToListAsync();
                if (dataDB.Count > 0) { return new MetadataViewModel() { Code = 201, Message = "Duplication Data" }; }
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
                return new MetadataViewModel() { Code = 200, Message = "Success" };
            }
            catch (Exception e)
            {
                return new MetadataViewModel() { Code = 400, Message = e.Message };
            }
        }
    }
}
