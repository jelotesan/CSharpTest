namespace CodelyTv.Mooc.Courses.Infrastructure
{
    using System.IO;
    using System.Threading.Tasks;
    using Domain;
    using Newtonsoft.Json;

    public class FileCourseRepository : ICourseRepository
    {
        private readonly string _filePath = Directory.GetCurrentDirectory() + "/courses";

        public async Task Save(Course course)
        {
            await Task.Run(() =>
            {
                using (StreamWriter outputFile = new StreamWriter(this.FileName(course.Id.Value), false))
                {
                    outputFile.WriteLine(JsonConvert.SerializeObject(course));
                }
            });
        }

        public Course Search(CourseId id)
        {
            return File.Exists(FileName(id.Value)) ? JsonConvert.DeserializeObject<Course>(File.ReadAllText(FileName(id.Value))) : null;
        }

        private string FileName(string id)
        {
            return $"{_filePath}.{id}.repo";
        }
    }
}