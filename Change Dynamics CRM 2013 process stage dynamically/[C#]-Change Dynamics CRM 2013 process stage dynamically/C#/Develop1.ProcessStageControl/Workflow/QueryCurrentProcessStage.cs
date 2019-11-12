// <copyright file="QueryCurrentProcessStage.cs" company="">
// Copyright (c) 2013 All Rights Reserved
// </copyright>
// <author></author>
// <date>9/20/2013 11:53:58 AM</date>
// <summary>Implements the QueryCurrentProcessStage Workflow Activity.</summary>
namespace Develop1.Crm.Workflow
{
    using System;
    using System.Activities;
    using System.ServiceModel;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Workflow;
    using Develop1.Crm.Plugins.Entities;
    using Microsoft.Xrm.Sdk.Query;

    public sealed class QueryCurrentProcessStage : CodeActivity
    {
        [Output("Process")]
        public OutArgument<string> ProcessName { get; set; }

        [Output("Process Stage Name")]
        public OutArgument<string> ProcessStageName { get; set; }

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

            tracingService.Trace("Entered QueryCurrentProcessStage.Execute(), Activity Instance Id: {0}, Workflow Instance Id: {1}",
                executionContext.ActivityInstanceId,
                executionContext.WorkflowInstanceId);

            // Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();

            if (context == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve workflow context.");
            }

            tracingService.Trace("QueryCurrentProcessStage.Execute(), Correlation Id: {0}, Initiating User: {1}",
                context.CorrelationId,
                context.InitiatingUserId);

            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            try
            {
                Entity target = (Entity)context.InputParameters["Target"];
                Entity preImage = null;
                if (context.PreEntityImages.ContainsKey("PreBusinessEntity"))
                    preImage = (Entity)context.PreEntityImages["PreBusinessEntity"];
                
                Guid? stageid = null;
                Guid? processid = null;
                if (target.Attributes.ContainsKey("stageid"))
                {
                    stageid = (Guid?)target["stageid"];
                }
                else if (preImage != null)
                {
                    stageid = (Guid?)preImage["stageid"];
                }
                if (target.Attributes.ContainsKey("processid"))
                {
                    processid = (Guid?)target["processid"];
                }
                else if (preImage != null)
                {
                    processid = (Guid?)preImage["processid"];
                }

                // Get the process and stage names
                string processName = "";
                string stageName = "";
                if (processid != null)
                {
                    Workflow processStage = (Workflow)service.Retrieve(Workflow.EntityLogicalName, processid.Value, new ColumnSet("name"));
                    processName = processStage.Name;
                }
                if (stageid != null)
                {
                    ProcessStage processStage = (ProcessStage)service.Retrieve(ProcessStage.EntityLogicalName, stageid.Value, new ColumnSet("stagename"));
                    stageName = processStage.StageName;
                }
                ProcessName.Set(executionContext, processName);
                ProcessStageName.Set(executionContext, stageName);

            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                tracingService.Trace("Exception: {0}", e.ToString());

                // Handle the exception.
                throw;
            }

            tracingService.Trace("Exiting QueryCurrentProcessStage.Execute(), Correlation Id: {0}", context.CorrelationId);
        }
    }
}