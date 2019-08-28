using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Domain.Services.ResponseResult
{
    public class ResponseModel1<T>
    {

        public bool Success { get; set; }
        public T Data { get; set; }
        public List<Message<MessageType, string>> Messages { get; set; }

    }
}
