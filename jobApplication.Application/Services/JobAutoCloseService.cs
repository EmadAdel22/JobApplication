using jobApplication.Application.Interfaces;

namespace jobApplication.Application.Services
{
    public class JobAutoCloseService
    {
        private readonly IJobRepository _jobRepository;

        public JobAutoCloseService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task CloseOldJobs()
        {
            var limitDate = DateTime.UtcNow.AddDays(-30);

            var jobs = _jobRepository
                .Get()
                .Where(x => x.IsActive && x.CreatedAt < limitDate)
                .ToList();

            foreach (var job in jobs)
            {
                job.IsActive = false;
                job.ClosedAt = DateTime.UtcNow;

                _jobRepository.Update(job);
            }

            await _jobRepository.SaveChangesAsync();
        }
    }
}