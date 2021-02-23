using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        // Constructor yapısı ile, işlem başarısız olduğunda döndürülecek mesaj yazılır. (Default:false)
        public ErrorResult(string message) : base(false, message)
        {


        }

        // işleme mesaj yollanmadığında da çalışmayı sağlar.
        public ErrorResult() : base(false)
        {


        }


    }
}
