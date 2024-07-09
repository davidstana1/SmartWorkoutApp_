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
        
        public async Task<List<Exercise>> GetAllForTrainer(string trainerId)
        {
            return await _appDbContext.Exercises
                .Include(e => e.Workout)
                .ThenInclude(w => w.User)
                .Where(e => e.Workout.User.Trainer.Id == trainerId)
                .ToListAsync();
        }
    }