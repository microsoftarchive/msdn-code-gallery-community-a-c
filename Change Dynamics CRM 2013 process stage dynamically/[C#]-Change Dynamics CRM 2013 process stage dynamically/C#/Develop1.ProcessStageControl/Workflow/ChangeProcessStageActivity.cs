// <copyright file="ChangeProcessStageActivity.cs" company="">
// Copyright (c) 2013 All Rights Reserved
// </copyright>
// <author></author>
// <date>9/20/2013 9:51:29 AM</date>
// <summary>Implements the ChangeProcessStageActivity Workflow Activity.</summary>
namespace Develop1.Crm.Workflow
{
    using System;
    using System.Activities;
    using System.ServiceModel;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Workflow;
using Develop1.Crm.Plugins.Entities;
    using Microsoft.Xrm.Sdk.Client;
    using System.Linq;

    public sealed class ChangeProcessStageActivity : CodeActivity
    {
        [RequiredArgument]
        [Input("Process Name")]
        public InArgument<string> Process { get; set; }

        [RequiredArgument]
        [Input("Process Stage Name")]
        public InArgument<string> ProcessStage { get; set; }
        /// <summary>
        /// Executes the workflow activity.
        /// </summary>
        /// <param name="executionContext">The execution context.</param>
        protected override void Execute(CodeActivityContext executionContext)
        {
            // Create the tracing service
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            if (tracingService == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve tracing service.");
            }

            tracingService.Trace("Entered ChangeProcessStageActivity.Execute(), Activity Instance Id: {0}, Workflow Instance Id: {1}",
                executionContext.ActivityInstanceId,
                executionContext.WorkflowInstanceId);

            // Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();

            if (context == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve workflow context.");
            }

            tracingService.Trace("ChangeProcessStageActivity.Execute(), Correlation Id: {0}, Initiating User: {1}",
                context.CorrelationId,
                context.InitiatingUserId);

            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            try
            {
              
                using (var ctx = new OrganizationServiceContext(service))
                {
                    // Get the processid using the name provided
                    var process = (from p in ctx.CreateQuery<Workflow>()
                                   where
                                   p.Name == Process.Get<string>(executionContext)
                                   &&
                                   p.StateCode == WorkflowState.Activated
                                   select new Workflow
                                   {
                                       WorkflowId = p.WorkflowId

                                   }).FirstOrDefault();
                    if (process==null)
                        throw new InvalidPluginExecutionException(String.Format("Process '{0}' not found",Process.Get<string>(executionContext)));

                    // Get the stage id using the name provided
                    var stage = (from s in ctx.CreateQuery<ProcessStage>()
                                 where
                                 s.StageName == ProcessStage.Get<string>(executionContext)
                                 &&
                                 s.ProcessId.Id == process.WorkflowId
                                 select new ProcessStage
                                 {
                                     ProcessStageId = s.ProcessStageId

                                 }).FirstOrDefault();
                    if (stage == null)
                        throw new InvalidPluginExecutionException(String.Format("Stage '{0}' not found", Process.Get<string>(executionContext)));

                    // Change the stage
                    Entity updatedStage = new Entity(context.PrimaryEntityName);
                    updatedStage.Id = context.PrimaryEntityId;
                    updatedStage["stageid"] = stage.ProcessStageId;
                    updatedStage["processid"] = process.WorkflowId;
                    service.Update(updatedStage);
                }
            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                tracingService.Trace("Exception: {0}", e.ToString());

                // Handle the exception.
                throw;
            }

            tracingService.Trace("Exiting ChangeProcessStageActivity.Execute(), Correlation Id: {0}", context.CorrelationId);
        }
    }
}