using Microsoft.EntityFrameworkCore;
using School_Manegment.Data;
using School_Manegment.Models;
using static School_Manegment.Payload.ApplicationDTO;

namespace School_Manegment.Service
{
    public class Sys_DetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GenericService<SCH_Class> _classService;
        private readonly GenericService<SCH_ClassSection> _sectionService;
        private readonly GenericService<Sys_Detail> _detailService;
        private readonly GenericService<Subject> _subject;
        private readonly ApplicationDbContext _context;

        public Sys_DetailService(
            IUnitOfWork unitOfWork,
            GenericService<SCH_Class> classService,
            GenericService<SCH_ClassSection> sectionService,
            GenericService<Sys_Detail> detailService,
            ApplicationDbContext context,
            GenericService<Subject> subject)
        {
            _unitOfWork = unitOfWork;
            _classService = classService;
            _sectionService = sectionService;
            _detailService = detailService;
            _context = context;
            _subject = subject;
        }

        public async Task<object> GetAllAsync()
        {
            try
            {
                var GetDetail = (await _unitOfWork.sysDetail.GetAllAsync()).FirstOrDefault();
                var GetClass = (await _unitOfWork.sCH_class.GetAllAsync()).Where(x => x.IsActive);
                var GetSection = (await _unitOfWork.classSection.GetAllAsync()).Where(x => x.IsActive);
                var GetSubjectn = (await _unitOfWork.subject.GetAllAsync()).Where(x => x.IsActive);

                return new
                {
                    GetDetail,
                    GetClass,
                    GetSection,
                    GetSubjectn,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Update(MasterDto payload)
        {
            if (payload == null)
            {
                throw new Exception("Payload cannot be null");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _sectionService.DeleteAllAsync();
                await _classService.DeleteAllAsync();
                await _detailService.DeleteAllAsync();
                await _subject.DeleteAllAsync();


                if (payload.Detail != null)
                {
                    await _detailService.AddAsync(payload.Detail);
                }

                if (payload.Classes != null && payload.Classes.Any())
                {
                    await _classService.AddRangeAsync(payload.Classes);
                }

                if (payload.Sections != null && payload.Sections.Any())
                {
                    await _sectionService.AddRangeAsync(payload.Sections);
                }
                if (payload.subjects != null && payload.subjects.Any())
                {
                    await _subject.AddRangeAsync(payload.subjects);
                }

                await transaction.CommitAsync();

                return "Successfully deleted old data and added new data!";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"Operation failed: {ex.Message}");
            }
        }
    }
}