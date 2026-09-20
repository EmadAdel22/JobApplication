using MediatR;
using jobApplication.Application.Interfaces;
using jobApplication.Domain.Enum;

namespace jobApplication.Application.Commands.Applications.CancelApplication
{
    public class CancelApplicationCommandHandler : IRequestHandler<CancelApplicationCommand>
    {
        private readonly IJobCandidateApplicationRepository _applicationRepository;
        private readonly ICandidateRepository _candidateRepository;

        public CancelApplicationCommandHandler(
            IJobCandidateApplicationRepository applicationRepository,
            ICandidateRepository candidateRepository)
        {
            _applicationRepository = applicationRepository;
            _candidateRepository = candidateRepository;
        }

        public async Task Handle(
            CancelApplicationCommand request,
            CancellationToken cancellationToken)
        {
            var candidate = _candidateRepository
                .Get()
                .FirstOrDefault(x => x.UserId == request.UserId);

            if (candidate == null)
                throw new Exception("Candidate not found.");

            var application = _applicationRepository
                .Get()
                .FirstOrDefault(x => x.Id == request.ApplicationId);

            if (application == null)
                throw new Exception("Application not found.");

            if (application.CandidateId != candidate.Id)
                throw new Exception(
                    "You are not allowed to cancel this application.");

            if (application.JobApplicationStatus == JobApplicationStatus.Interview)
                throw new Exception(
                    "You cannot cancel the application after the interview.");

            if (application.JobApplicationStatus == JobApplicationStatus.Accepted)
                throw new Exception(
                    "You cannot cancel an accepted application.");

            if (application.JobApplicationStatus == JobApplicationStatus.Rejected)
                throw new Exception(
                    "You cannot cancel a rejected application.");

            if (application.JobApplicationStatus == JobApplicationStatus.Cancelled)
                throw new Exception(
                    "Application is already cancelled.");

            application.JobApplicationStatus =
                JobApplicationStatus.Cancelled;

            application.CancelledAt = DateTime.UtcNow;

            application.StatusUpdatedAt = DateTime.UtcNow;

            _applicationRepository.Update(application);

            await _applicationRepository.SaveChangesAsync();
        }
    }
}