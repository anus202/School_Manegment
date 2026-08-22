using Hotel_Manegment.Services;
using School_Manegment.Data;
using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;
using static School_Manegment.Payload.ApplicationDTO;

namespace School_Manegment.Service
{
    public class TeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwtService;

        public TeacherService(IUnitOfWork unitOfWork, JwtService jwtService = null)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<string> AddAsync(TeacherDetailsDto Payload)
        {
            try
            {
                var res = string.Empty;

                var getstudent = (await _unitOfWork.student.GetAllAsync()).Where(x => x.StudentId == Payload.Teacher.TeacherCode);
                if (getstudent.Any())
                {
                    throw new Exception("Teacher Code Alredy Assign Student");
                }

                if(Payload.Teacher == null)
                {
                    throw new Exception("Add techer Details");
                }

                await _unitOfWork.teacher.AddAsync(Payload.Teacher);
                await _unitOfWork.SaveAsync();

                if (Payload.Educations != null && Payload.Educations.Count > 0)
                {
                    foreach (var education in Payload.Educations)
                    {
                        education.FK_TeacherId = Payload.Teacher.Id;
                        education.TeacherCode = Payload.Teacher.TeacherCode;
                        await _unitOfWork.teacherEducation.AddAsync(education);
                    }
                }
                if(Payload.Experiences != null && Payload.Experiences.Count > 0)
                {
                    foreach (var experience in Payload.Experiences)
                    {
                        experience.FK_TeacherId = Payload.Teacher.Id;
                        experience.TeacherCode = Payload.Teacher.TeacherCode;
                        await _unitOfWork.teacherExperience.AddAsync(experience);
                    }
                }
                if (Payload.LoginDetail != null)
                {
                    if (Payload.LoginDetail.IsWebLogin)
                    {
                        Payload.LoginDetail.FK_TeacherId = Payload.Teacher.Id;
                    Payload.LoginDetail.TeacherCode = Payload.Teacher.TeacherCode;
                    await _unitOfWork.teacherLoginDetail.AddAsync(Payload.LoginDetail);
                    
                        Login LPayload = new Login
                        {
                            Email = Payload.Teacher.Email,
                            UserName = Payload.Teacher.FirstName + " " + Payload.Teacher.LastName,
                            Password = Payload.Teacher.TeacherCode,
                            Roll = 0,
                            LastLoginTime = DateTime.Now,
                            IsLoggedIn = false,
                            IsActive = true,
                            IsDeleted = false,
                            IsTeacher = true,
                            IsStudent = false,
                        };
                        await _unitOfWork.login.AddAsync(LPayload);
                    }
                }
                

                await _unitOfWork.SaveAsync();

                res = "Teacher Added Successfully";

                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                var teacher = await _unitOfWork.teacher.GetByIdAsync(id);

                if (teacher == null)
                {
                    return;
                }

                // Teacher inactive
                teacher.IsActive = false;
                teacher.IsDeleted = true;

                var loginDetail = await _unitOfWork.teacherLoginDetail.GetByIdAsync(id);

                loginDetail.IsActive = false;
                loginDetail.IsDeleted = true;

                // Education inactive
                var educations = await _unitOfWork.teacherEducation.GetAllAsync();

                foreach (var education in educations.Where(x => x.FK_TeacherId == id))
                {
                    education.IsActive = false;
                    education.IsDeleted = true;
                }

                // Experience inactive
                var experiences = await _unitOfWork.teacherExperience.GetAllAsync();

                foreach (var experience in experiences.Where(x => x.FK_TeacherId == id))
                {
                    experience.IsActive = false;
                    experience.IsDeleted = true;
                }

                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            try
            {
                var getData = (await _unitOfWork.teacher.GetAllAsync()).Where(x => x.IsActive);

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            try
            {
                var getData = await _unitOfWork.teacher.GetByIdAsync(id);

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> UpdateAsync(TeacherDetailsDto payload)
        {
            try
            {
                await _unitOfWork.teacher.UpdateAsync(payload.Teacher);

                if (payload.Educations != null)
                {
                    foreach (var education in payload.Educations)
                    {
                        education.FK_TeacherId = payload.Teacher.Id;
                        education.TeacherCode = payload.Teacher.TeacherCode;

                        await _unitOfWork.teacherEducation.UpdateAsync(education);
                    }
                }


                if (payload.Experiences != null)
                {
                    foreach (var experience in payload.Experiences)
                    {
                        experience.FK_TeacherId = payload.Teacher.Id;
                        experience.TeacherCode = payload.Teacher.TeacherCode;

                        await _unitOfWork.teacherExperience.UpdateAsync(experience);
                    }
                }


                if (payload.LoginDetail != null)
                {
                    payload.LoginDetail.FK_TeacherId = payload.Teacher.Id;
                    payload.LoginDetail.TeacherCode = payload.Teacher.TeacherCode;

                    await _unitOfWork.teacherLoginDetail.UpdateAsync(
                        payload.LoginDetail
                    );


                    if (payload.LoginDetail.IsWebLogin)
                    {
                        var users = await _unitOfWork.login.GetAllAsync();

                        var login = users.FirstOrDefault(
                            x => x.Email == payload.Teacher.Email
                        );


                        if (login != null)
                        {
                            login.Email = payload.Teacher.Email;
                            login.UserName =
                                payload.Teacher.FirstName + " " +
                                payload.Teacher.LastName;

                            login.Password = payload.Teacher.TeacherCode;

                            login.IsActive = true;
                            login.IsDeleted = false;

                            await _unitOfWork.login.UpdateAsync(login);
                        }
                        else
                        {
                            Login loginPayload = new Login
                            {
                                Email = payload.Teacher.Email,
                                UserName =
                                    payload.Teacher.FirstName + " " +
                                    payload.Teacher.LastName,

                                Password = payload.Teacher.TeacherCode,

                                Roll = 0,
                                LastLoginTime = DateTime.Now,
                                IsLoggedIn = false,
                                IsActive = true,
                                IsDeleted = false
                            };

                            await _unitOfWork.login.AddAsync(loginPayload);
                        }
                    }


                    else
                    {
                        var users = await _unitOfWork.login.GetAllAsync();

                        var login = users.FirstOrDefault(
                            x => x.Email == payload.Teacher.Email
                        );

                        if (login != null)
                        {
                            login.IsActive = false;
                            login.IsDeleted = true;

                            await _unitOfWork.login.UpdateAsync(login);
                        }
                    }
                }


                await _unitOfWork.SaveAsync();

                return "Teacher Updated Successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<object> GetByIdAsyncAllTbl(int id)
        {
            try
            {
                var teacher = await _unitOfWork.teacher.GetByIdAsync(id);

                if (teacher == null)
                {
                    return new
                    {
                        Message = "No Data Found"
                    };
                }

                var education = (await _unitOfWork.teacherEducation.GetAllAsync()).Where(x=>x.IsActive);
                var experience = (await _unitOfWork.teacherExperience.GetAllAsync()).Where(x => x.IsActive);
                var loginDetail = (await _unitOfWork.teacherLoginDetail.GetAllAsync()).Where(x => x.IsActive);

                var edu = education
                    .Where(x => x.FK_TeacherId == id)
                    .ToList();

                var exp = experience
                    .Where(x => x.FK_TeacherId == id)
                    .ToList();

                var login = loginDetail
                    .Where(x => x.FK_TeacherId == id)
                    .ToList();

                return new
                {
                    Teacher = teacher,
                    Education = edu,
                    Experience = exp,
                    LoginDetail = loginDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
