using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        // Constructor yapısı ile, işlem başarılı olduğunda döndürülecek mesaj yazılır. (Default:true)
        public SuccessResult(string message):base(true,message)
        {


        }

        // işleme mesaj yollanmadığında da çalışmayı sağlar.
        public SuccessResult() : base(true)
        {


        }
    }
}
