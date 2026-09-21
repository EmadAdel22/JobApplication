using jobApplication.Application.Interfaces;
using jobApplication.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Commands.Applications.UpdateApplicationStatus
{
    public class UpdateApplicationStatusCommandHandler
      : IRequestHandler<UpdateApplicationStatusCommand>
    {
        private readonly IJobCandidateApplicationRepository _applicationRepository;

        public UpdateApplicationStatusCommandHandler(
            IJobCandidateApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task Handle(
            UpdateApplicationStatusCommand request,
            CancellationToken cancellationToken)
        {
            var application = _applicationRepository
                .Get()
                .FirstOrDefault(x => x.Id == request.ApplicationId);

            if (application == null)
                throw new Exception("Application not found.");

            var currentStatus = application.JobApplicationStatus;
            var newStatus = request.Status;

            if (currentStatus == newStatus)
                throw new Exception(
                    "Application already has this status.");

            if (currentStatus == JobApplicationStatus.Cancelled)
                throw new Exception(
                    "Cancelled application cannot be updated.");

            if (currentStatus == JobApplicationStatus.Accepted ||
                currentStatus == JobApplicationStatus.Rejected)
            {
                throw new Exception(
                    "Accepted or rejected application cannot be updated.");
            }

            if (currentStatus == JobApplicationStatus.Applied)
            {
                if (newStatus != JobApplicationStatus.UnderReview &&
                    newStatus != JobApplicationStatus.Rejected)
                {
                    throw new Exception(
                        "Application can only move from Applied to UnderReview or Rejected.");
                }
            }

            if (currentStatus == JobApplicationStatus.UnderReview)
            {
                if (newStatus != JobApplicationStatus.Interview &&
                    newStatus != JobApplicationStatus.Rejected)
                {
                    throw new Exception(
                        "Application can only move from UnderReview to Interview or Rejected.");
                }
            }

            if (currentStatus == JobApplicationStatus.Interview)
            {
                if (newStatus != JobApplicationStatus.Accepted &&
                    newStatus != JobApplicationStatus.Rejected)
                {
                    throw new Exception(
                        "Application can only move from Interview to Accepted or Rejected.");
                }
            }

            application.JobApplicationStatus = newStatus;

            application.StatusUpdatedAt = DateTime.UtcNow;

            _applicationRepository.Update(application);

            await _applicationRepository.SaveChangesAsync();
        }
    }
}
