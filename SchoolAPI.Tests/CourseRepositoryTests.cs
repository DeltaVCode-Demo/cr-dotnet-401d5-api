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
    }
}
