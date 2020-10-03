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
    public class SKPLURepo
    {
        private readonly ApplicationDbContext _db;
        public SKPLURepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<SKPLUViewModel>> GetAll()
        {
            List<SKPLUViewModel> hasil = new List<SKPLUViewModel>();
            var data = await _db.SKPLU.ToListAsync();
            hasil = data.Select(x => new SKPLUViewModel()
            {
                Address = x.Address,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                SocketType = x.SocketType,
                ModifyBy = x.ModifyBy,
                ModifyDate = x.ModifyDate,
                SKPLUID = x.SKPLUID,
                Name = x.Name,
                Status = x.Status,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                MapLocation = x.MapLocation,
                Interval = x.Interval
            }).ToList();
            return hasil;
        }
        public async Task<SKPLUViewModel> GetByID(long ID)
        {
            SKPLUViewModel hasil = new SKPLUViewModel();
            var data = await _db.SKPLU.Where(x => x.SKPLUID == ID).FirstOrDefaultAsync();
            if (data != null)
            {
                hasil.SKPLUID = data.SKPLUID;
                hasil.Name = data.Name;
                hasil.Status = data.Status;
                hasil.Address = data.Address;
                hasil.CreatedBy = data.CreatedBy;
                hasil.CreatedDate = data.CreatedDate;
                hasil.SocketType = data.SocketType;
                hasil.ModifyBy = data.ModifyBy;
                hasil.ModifyDate = data.ModifyDate;
                hasil.Address = data.Address;
                hasil.EndTime = data.EndTime;
                hasil.Interval = data.Interval;
                hasil.MapLocation = data.MapLocation;
            }
            return hasil;
        }
        public async Task<MetadataViewModel> Insert(SKPLUViewModel data)
        {
            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var dataDB = await _db.SKPLU.Where(x => x.Name.Contains(data.Name) && x.SocketType == data.SocketType).ToListAsync();
                    if (dataDB.Count > 0) { await trans.RollbackAsync(); return new MetadataViewModel() { Success=false, Message = "Duplication Data" }; }
                    SKPLUModel dataSKPLU = new SKPLUModel()
                    {
                        Address = data.Address,
                        CreatedBy = data.CreatedBy,
                        CreatedDate = data.CreatedDate,
                        SocketType = data.SocketType,
                        Name = data.Name,
                        Status = data.Status,
                        StartTime = data.StartTime,
                        EndTime = data.EndTime,
                        Interval = data.Interval,
                        MapLocation =data.MapLocation
                    };
                    _db.SKPLU.Add(dataSKPLU);
                    await _db.SaveChangesAsync();

                    await trans.CommitAsync();
                    return new MetadataViewModel() { Success= true, Message = "Success" };
                }
                catch (Exception e)
                {
                    await trans.RollbackAsync();
                    return new MetadataViewModel() { Success= false, Message = e.Message };
                }

            }
        }
        public async Task<MetadataViewModel> Update(SKPLUViewModel data)
        {
            try
            {
                var dataDB = await _db.SKPLU.Where(x => x.SKPLUID == data.SKPLUID).FirstOrDefaultAsync();
                if (dataDB == null) { return new MetadataViewModel() { Success=false, Message = "Data Not Found" }; }
                dataDB.SKPLUID = data.SKPLUID;
                dataDB.Address = data.Address;
                dataDB.ModifyBy = data.ModifyBy;
                dataDB.ModifyDate = data.ModifyDate;
                dataDB.SocketType = data.SocketType;
                dataDB.Name = data.Name;
                dataDB.Status = data.Status;
                await _db.SaveChangesAsync();
                return new MetadataViewModel() { Success= true, Message = "Success" };
            }
            catch (Exception e)
            {
                return new MetadataViewModel() { Success= false, Message = e.Message };
            }
        }

        public async Task<MetadataViewModel> Delete(SKPLUViewModel data)
        {
            try
            {
                var dataDB = await _db.SKPLU.Where(x => x.SKPLUID == data.SKPLUID).FirstOrDefaultAsync();
                if (dataDB == null) { return new MetadataViewModel() { Success= false, Message = "Data Not Found" }; }
                _db.SKPLU.Remove(dataDB);
                await _db.SaveChangesAsync();
                return new MetadataViewModel() { Success= true, Message = "Success" };
            }
            catch (Exception e)
            {
                return new MetadataViewModel() { Success= false, Message = e.Message };
            }
        }
    }
}
