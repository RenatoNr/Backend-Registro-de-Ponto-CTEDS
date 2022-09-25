using Registro_de_Ponto_CTEDS.Models;
using System.Collections.Generic;

namespace Registro_de_Ponto_CTEDS.Interfaces;
    public interface IClock
    {
        public void Create(Clock clock);
        public List<Clock> GetAll();
        public List<ClocksEmployee?> GetClocksEmployee(string employeeId);
        public void UpdateTime(int  Id, int update);

    }
