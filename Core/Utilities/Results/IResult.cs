using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Temel voidler için başlangıç interface
    public interface IResult
    {
        //İşlemlerin başarılı-başarısız olması ; işlem sonucunda gönderilen mesajları içerir.
        //Sadece okunabilir, sonucu döndürür.
        bool Success { get; }
        string Message { get; }
    }
}
