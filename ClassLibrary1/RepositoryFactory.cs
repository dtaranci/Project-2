﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class RepositoryFactory
    {
        public static IRepository GetRepository(string PATH) => new FileRepository(PATH);
    }
}
