using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Domain.Services.ResponseResult
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        //public ResponseModel(bool success, T data, string message)
        //{
        //    Success = success;
        //    Data = data;
        //    Message = message;           
        //}
        //public ResponseModel(T data) : this(true, data, string.Empty)
        //{ }

        //public ResponseModel(string message) : this(false, message)
        //{ }

    }
}
