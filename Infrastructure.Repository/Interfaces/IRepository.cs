using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Interfaces
{
    public interface IRepository : IAdd, IGet, IUpdate, IDelete
    {
    }
}
