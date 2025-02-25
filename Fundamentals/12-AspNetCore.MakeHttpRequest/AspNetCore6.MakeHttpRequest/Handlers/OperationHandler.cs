﻿using AspNetCore6.MakeHttpRequest.Models;

namespace AspNetCore6.MakeHttpRequest.Handlers
{
    public class OperationHandler : DelegatingHandler
    {
        private readonly IOperationScoped _operationScoped;
        public OperationHandler(IOperationScoped operationScoped)
            =>_operationScoped=operationScoped;
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            request.Headers.Add("X-OPERATION-ID", _operationScoped.OperationId);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
