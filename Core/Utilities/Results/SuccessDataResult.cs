using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        // Default olarak true olan, data ve mesaj döndüren const.
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        } 
        // Default olarak true olan, mesajsız sadece data döndüren const.
        public SuccessDataResult(T data):base(data,true)
        {

        }

        // Default olarak true olan, sadece mesaj döndüren const.
        public SuccessDataResult(string message):base(default,true,message)
        {

        }

        // Default olarak true olan, Hiçbir şey döndürmeyen const.
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
