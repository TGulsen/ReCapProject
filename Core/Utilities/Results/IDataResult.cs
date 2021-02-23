using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        // İşlem sonuçlarından data döndürenlerin prototipini oluşturur. Mesaj da içerebilir.

        T Data { get; }

    
    }
}
