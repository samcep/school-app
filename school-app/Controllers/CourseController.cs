using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_app.Dtos;
using school_app.Entities;

namespace school_app.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {

        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;
        private  ApplicationDbConext _dbContext;

        public CourseController(ILogger<CourseController> logger , 
            ApplicationDbConext dbContext,
            IMapper mapper) 
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _dbContext.courses.AsNoTracking()
                .Include(course => course.Enrollments)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> PostCourseAsync(CourseCreateDto courseCreateDto)
        {
            var course = _mapper.Map<CourseCreateDto, Course>(courseCreateDto);
            _dbContext.Add(course);
            await _dbContext.SaveChangesAsync();
            return Ok(course);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCourseAsync(Course course, int id)
        {
            Course currentCourse = await _dbContext.courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if(currentCourse is null)
            {
                return NotFound();
            }
            _dbContext.Update(course);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("a record has been updated");
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCourseAsync(int id)
        {
            Course currentCourse = await _dbContext.courses.FirstOrDefaultAsync(c => c.Id == id);
            if (currentCourse is null)
            {
                return NotFound();
            }

            _dbContext.Remove(currentCourse);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        
        
    }
}
