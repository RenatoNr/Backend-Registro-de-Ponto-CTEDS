﻿using Registro_de_Ponto_CTEDS.Models;
using System.Collections.Generic;

namespace Registro_de_Ponto_CTEDS.Interfaces
{
    public interface IUser
    {
        public void Create(User user);
        public List<User> GetAll();
    }
}