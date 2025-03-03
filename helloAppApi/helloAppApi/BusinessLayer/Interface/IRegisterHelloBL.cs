using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.DTO;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IRegisterHelloBL
    {
        public RegistrationResponse RegisterBL(RegisterDTO registerDTO);
        public string Registration(string name);
        public bool LoginUser(LoginDTO loginDTO);
    }
}
