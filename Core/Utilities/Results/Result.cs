using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
      
        //Constructor yapısı kullanarak, standart hale getiriyoruz. 
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        //OverLoading, istemediğimiz zaman mesaj yazmayabiliriz.
        public Result(bool success)
        {
           
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
