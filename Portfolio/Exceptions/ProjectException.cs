﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Exceptions
{
    public class ProjectException : Exception
    {
        public ProjectException()
        {

        }

        public ProjectException(string message) : base(message)
        {

        }
    }
}
