using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.BL.Utilities;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.BL.Services.Concretes;

public class TeacherService : ITeacherService
{
    readonly ITeacherWriteRepository _writeRepo;
    readonly ITeacherReadRepository _readRepo;
    readonly IMapper _mapper;
    readonly IStatisticsService _statisticsService;

	public TeacherService(ITeacherWriteRepository writeRepo, ITeacherReadRepository readRepo, IMapper mapper, IStatisticsService statisticsService)
	{
		_writeRepo = writeRepo;
		_readRepo = readRepo;
		_mapper = mapper;
		_statisticsService = statisticsService;
	}

	public async Task<Teacher> GetByIdAsync(int id) =>
        await _readRepo.GetByIdAsync(id) ?? throw new BaseException();

    public async Task<Teacher> GetByIdWithChildrenAsync(int id) =>
        await _readRepo.GetByIdAsync(id, "Courses") ?? throw new BaseException();

    public async Task<TeacherUpdateDTO> GetByIdForUpdateAsync(int id) =>
        _mapper.Map<TeacherUpdateDTO>(await GetByIdAsync(id));

    public async Task<ICollection<TeacherListItemDTO>> GetTeacherListItemsAsync() =>
        _mapper.Map<ICollection<TeacherListItemDTO>>(await _readRepo.GetAllAsync());

    public async Task<ICollection<TeacherViewItemDTO>> GetTeacherViewItemsAsync() =>
        _mapper.Map<ICollection<TeacherViewItemDTO>>(await _readRepo.GetAllAsync("Courses"));

    public async Task CreateAsync(TeacherCreateDTO dto)
    {
        var teacher = _mapper.Map<Teacher>(dto);

        if (dto.Image is not null)
        {
            teacher.ImgUrl = await dto.Image.SaveAsync("teacher");
        }

        await _writeRepo.CreateAsync(teacher);
		await _statisticsService.IncrementTeacherCount();
	}

    public async Task UpdateAsync(TeacherUpdateDTO dto)
    {
        var oldTeacher = await GetByIdAsync(dto.Id);
        var updatedTeacher = _mapper.Map<Teacher>(dto);

        updatedTeacher.CreatedAt = oldTeacher.CreatedAt;
        updatedTeacher.ImgUrl = dto.Image is not null ? await dto.Image.SaveAsync("teacher") : oldTeacher.ImgUrl;

        _writeRepo.Update(updatedTeacher);
        if (dto.Image is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "teacher", oldTeacher.ImgUrl));
    }

    public async Task DeleteAsync(int id)
    {
        var teacher = await GetByIdWithChildrenAsync(id);

        if (teacher.Courses.Any())
            throw new BaseException("This Teacher has courses!");

        var imgPath = Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "teacher", teacher.ImgUrl);
        if (File.Exists(imgPath))
        {
            File.Delete(imgPath);
        }

        _writeRepo.Delete(teacher);
    }

    public async Task<int> SaveChangesAsync() => await _writeRepo.SaveChangesAsync();
}
