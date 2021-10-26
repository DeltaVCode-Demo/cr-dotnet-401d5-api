using SchoolAPI.Models;
using SchoolAPI.Models.Services;
using Xunit;

namespace SchoolAPI.Tests
{
    public class CourseRepositoryTests : DatabaseTestBase
    {
        [Fact]
        public async void Can_get_courses()
        {
            // Arrange
            var repository = new CourseService(_db);

            // Act
            var result = await repository.GetCourses();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void Can_enroll_and_drop_student()
        {
            // Arrange
            var repository = new CourseService(_db);

            var course = await CreateAndSaveTestCourse();
            Assert.Null(course.Enrollments);
            var student = await CreateAndSaveTestStudent();

            // Act
            await repository.AddStudent(course.Id, student.Id);

            // Assert
            var savedCourse = await repository.GetCourse(course.Id);
            Assert.NotEmpty(savedCourse.Enrollments);
            Assert.Contains(savedCourse.Enrollments,
                e => e.StudentId == student.Id);

            // Act
            await repository.DropStudent(course.Id, student.Id);

            // Assert
            Assert.Empty(savedCourse.Enrollments);
        }
    }
}
