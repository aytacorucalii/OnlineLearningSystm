using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.BL.Utilities;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.BL.Services.Concretes;

public class StudentService : IStudentService
{
    readonly IStudentReadRepository _readRepo;
    readonly IStudentWriteRepository _writeRepo;
    readonly IStatisticsService _statisticsService;
    readonly ICourseReadRepository _courseRepo;
    readonly IMapper _mapper;

	public StudentService(IMapper mapper, IStudentWriteRepository writeRepo, IStudentReadRepository readRepo, IStatisticsService statisticsService, ICourseReadRepository courseRepo)
	{
		_mapper = mapper;
		_writeRepo = writeRepo;
		_readRepo = readRepo;
		_statisticsService = statisticsService;
		_courseRepo = courseRepo;
	}

	public async Task<Student> GetByIdAsync(int id) =>
        await _readRepo.GetByIdAsync(id) ?? throw new BaseException();

    public async Task<Student> GetByIdWithChildrenAsync(int id) =>
        await _readRepo.GetByIdAsync(id, "StudentCourses") ?? throw new BaseException();

    public async Task<StudentUpdateDTO> GetByIdForUpdateAsync(int id) =>
        _mapper.Map<StudentUpdateDTO>(await GetByIdAsync(id));

    public async Task<ICollection<StudentListItemDTO>> GetStudentListItemsAsync() =>
        _mapper.Map<ICollection<StudentListItemDTO>>(await _readRepo.GetAllAsync());

    public async Task<ICollection<StudentViewItemDTO>> GetStudentViewItemsAsync() =>
        _mapper.Map<ICollection<StudentViewItemDTO>>(await _readRepo.GetAllAsync("StudentCourses.Course"));

	public async Task CreateAsync(StudentCreateDTO dto)
	{
		foreach (var courseId in dto.Courses)
		{
			if (await _courseRepo.GetByIdAsync(courseId) is null)
				throw new BaseException($"Course with ID {courseId} not found!");
		}

		Student student = _mapper.Map<Student>(dto);
		student.ImgUrl = await dto.Image.SaveAsync("student");
		await _writeRepo.CreateAsync(student);
		await _statisticsService.IncrementStudentCount();
	}

	public async Task UpdateAsync(StudentUpdateDTO dto)
    {
		foreach (var courseId in dto.Courses)
		{
			if (await _courseRepo.GetByIdAsync(courseId) is null)
				throw new BaseException($"Course with ID {courseId} not found!");
		}
		Student oldStudent = await GetByIdAsync(dto.Id);
        Student student = _mapper.Map<Student>(dto);
        student.CreatedAt = oldStudent.CreatedAt;
        student.ImgUrl = dto.Image is not null ? await dto.Image.SaveAsync("student") : oldStudent.ImgUrl;
        _writeRepo.Update(student);
    }

    public async Task DeleteAsync(int id)
    {
        Student student = await GetByIdWithChildrenAsync(id);

        if (student.StudentCourses.Count != 0)
            throw new BaseException("This student is enrolled in courses!");

        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "student", student.ImgUrl));
        _writeRepo.Delete(student);
    }

    public async Task<int> SaveChangesAsync() => await _writeRepo.SaveChangesAsync();
}
