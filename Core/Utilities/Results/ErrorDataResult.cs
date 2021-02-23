using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        // Default olarak false olan, data ve mesaj döndüren const.
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        // Default olarak false olan, data döndüren const.
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        // Default olarak false olan, sadece mesaj döndüren const.
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        // Default olarak false olan, Hiçbir şey döndürmeyen const.
        public ErrorDataResult() : base(default, false)
        {

        }

    }
}
