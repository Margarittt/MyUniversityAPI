using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Domain.Services.ResponseResult
{
    public abstract class ResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResponseModel(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
