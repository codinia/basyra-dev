using Services.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IBaseRepository
    {
        IUnitOfWork UnitOfWork { get; set; }
    }
}
