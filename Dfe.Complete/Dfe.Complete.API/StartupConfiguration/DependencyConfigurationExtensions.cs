﻿using Dfe.Complete.API.UseCases;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.API.UseCases.Project;
using Dfe.Complete.API.UseCases.Project.Transfer;
using Dfe.Complete.API.UseCases.Project.Transfer.Tasks;
using Dfe.Complete.Logging;
using Dfe.Complete.UserContext;
using FluentValidation;
using System.Reflection;

namespace Dfe.Complete.API.StartupConfiguration
{
    public static class DependencyConfigurationExtensions
	{
		public static IServiceCollection AddApiDependencies(this IServiceCollection services)
		{
			services.AddScoped<IServerUserInfoService, ServerUserInfoService>();
			
			services.AddScoped<ICorrelationContext, CorrelationContext>();

			services.AddScoped<AcademiesApiClient, AcademiesApiClient>();

			services.AddScoped<IApiKeyValidationService, ApiKeyValidationService>();
			services.AddScoped<IConstructApiKeyValidationService, ConstructApiKeyValidationService>();
			services.AddScoped<ISfaApiKeyValidationService, SfaApiKeyValidationService>();
			services.AddScoped<IGetProjectListService, GetProjectListService>();
			services.AddScoped<IGetEstablishmentsBulkService, GetEstablishmentsBulkService>();
			services.AddScoped<ISetProjectSchoolNameService, SetProjectSchoolNameService>();

			// Transfer projects
			services.AddScoped<ICreateTransferProjectService, CreateTransferProjectService>();

			// Transfer tasks
			services.AddScoped<IGetTransferProjectByTaskService, GetTransferProjectByTaskService>();
			services.AddScoped<IUpdateTransferProjectByTaskService, UpdateTransferProjectByTaskService>();
			services.AddScoped<IGetTransferProjectByTaskSummaryService, GetTransferProjectByTaskSummaryService>();

            services.AddValidatorsFromAssembly(Assembly.Load(Assembly.GetExecutingAssembly().FullName));

            return services;
		}
	}
}
