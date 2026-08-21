using Hotel_Manegment.Services;
using School_Manegment.Data;
using School_Manegment.Data.Interface;
using School_Manegment.Models;
using School_Manegment.Models.Student_tbl;

namespace School_Manegment.Service
{
    public class ISCH_ClassSectionService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwtService;

        public ISCH_ClassSectionService(IUnitOfWork unitOfWork, JwtService jwtService = null)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }


        public async Task<IEnumerable<SCH_ClassSection>> GetAllClassSectionsAsync()
        {
            try
            {
                var getData = await _unitOfWork.classSection.GetAllAsync();

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<SCH_Class>> GetAllClassAsync()
        {
            try
            {
                var getData = await _unitOfWork.sCH_class.GetAllAsync();

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
