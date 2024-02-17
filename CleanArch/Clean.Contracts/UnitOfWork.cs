﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Contracts
{
    public interface UnitOfWork
    {
        Task Begin();
        Task Commit();
        Task Complete();
        Task RollBack();
    }
}
