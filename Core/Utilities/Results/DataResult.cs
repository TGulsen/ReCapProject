using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        // DataResult, Result'tan farklı olarak "Data" içerir.
        // Constructor yapısı ile aynı kodu tekrar yazmadan base class'a atıf yaparız.
        public DataResult(T data,bool success, string message):base(success,message)
        {
            Data = data;
        }

        //Message göndermeyebiliriz.
        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }

    }
}
