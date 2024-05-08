﻿using Dfe.Complete.API.Contracts.Project;

namespace Dfe.Complete.API.UseCases.Academies
{
    public interface ISetProjectSchoolNameService
    {
        public Task Execute(ProjectBaseResponse project);

        public Task Execute(IEnumerable<ProjectBaseResponse> projects);
    }

    public class SetProjectSchoolNameService : ISetProjectSchoolNameService
    {
        private readonly IGetEstablishmentsBulkService _getEstablishmentBulkService;

        public SetProjectSchoolNameService(IGetEstablishmentsBulkService getEstablishmentBulkService)
        {
            _getEstablishmentBulkService = getEstablishmentBulkService;
        }

        public async Task Execute(ProjectBaseResponse project)
        {
            var projects = new List<ProjectBaseResponse> { project };

            await Execute(projects);
        }

        public async Task Execute(IEnumerable<ProjectBaseResponse> projects)
        {
            var projectsMissingName = projects.Where(p => string.IsNullOrEmpty(p.SchoolName)).ToList();
            await SetSchoolNameLookup(projectsMissingName);
        }

        private async Task SetSchoolNameLookup(List<ProjectBaseResponse> projects)
        {
            var urns = projects.Select(r => r.Urn).Distinct().ToArray();

            if (!urns.Any())
            {
                return;
            }

            var establishments = await _getEstablishmentBulkService.Execute(urns);

            var establishmentLookup = establishments.ToDictionary(e => e.Urn);

            foreach (var entry in projects)
            {
                if (establishmentLookup.ContainsKey(entry.Urn.ToString()))
                {
                    entry.SchoolName = establishmentLookup[entry.Urn.ToString()].Name;
                }
            }
        }
    }
}
