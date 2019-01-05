﻿using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;
using System.Net;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.Http;

namespace EmailDelete
{
    public class EmailDelete : CodeActivity
    {

        [Output("Response")]
        public OutArgument<string> Response { get; set; }


        protected override void Execute(CodeActivityContext executionContext)
        {

            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            tracingService.Trace("Invoking the deletion of email");

            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();

            //Entity entity = (Entity)context.InputParameters["Target"];


            Guid recordId = context.PrimaryEntityId;


            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);


            Entity currentRecord = service.Retrieve("email", recordId, new Microsoft.Xrm.Sdk.Query.ColumnSet(true));

            service.Delete("email", recordId);


            
        }

    }


}

