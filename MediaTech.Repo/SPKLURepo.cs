using MediaTech.Model;
using MediaTech.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public async Task<SPKLUViewModel> GetByID(long ID)
        {
            SPKLUViewModel hasil = new SPKLUViewModel();
            var data = await _db.SPKLU.Where(x => x.SPKLUId == ID).FirstOrDefaultAsync();
            if (data != null)
            {
                hasil.SPKLUId = data.SPKLUId;
                hasil.SPKLUName = data.SPKLUName;
                hasil.Status = data.Status;
                hasil.Alamat = data.Alamat;
                hasil.CreatedBy = data.CreatedBy;
                hasil.CreatedDate = data.CreatedDate;
                hasil.IsACType = data.IsACType;
                hasil.ModifyBy = data.ModifyBy;
                hasil.ModifyDate = data.ModifyDate;
            }
            return hasil;
        }
        public async Task<MetadataViewModel> Insert(SPKLUViewModel data)
        {
            try
            {
                var dataDB = await _db.SPKLU.Where(x => x.SPKLUName.Contains(data.SPKLUName) && x.IsACType == data.IsACType).ToListAsync();
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
        public async Task<MetadataViewModel> Update(SPKLUViewModel data)
        {
            try
            {
                var dataDB = await _db.SPKLU.Where(x => x.SPKLUId == data.SPKLUId).FirstOrDefaultAsync();
                if (dataDB == null) { return new MetadataViewModel() { Code = 404, Message = "Data Not Found" }; }
                dataDB.SPKLUId = data.SPKLUId;
                dataDB.Alamat = data.Alamat;
                dataDB.ModifyBy = data.ModifyBy;
                dataDB.ModifyDate = data.ModifyDate;
                dataDB.IsACType = data.IsACType;
                dataDB.SPKLUName = data.SPKLUName;
                dataDB.Status = data.Status;
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
