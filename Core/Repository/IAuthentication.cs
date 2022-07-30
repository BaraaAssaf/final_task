using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IAuthentication
    {
        public login_api auth(login_api login);

    }
}
