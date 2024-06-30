    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    namespace DataAccess.Repository.Exercises;

    public class ExerciseRepository : GenericRepository<Exercise> , IExerciseRepository
    {
        public ExerciseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }

        public async Task<List<Exercise>> GetAllExercises()
        {
            return await GetAll();
        }
    }