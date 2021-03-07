using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //token verecegimiz user ve onun claim listesini oluşturan base interface
        //token üretir.
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);

    }
}
