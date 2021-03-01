using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaim);

    }

}
