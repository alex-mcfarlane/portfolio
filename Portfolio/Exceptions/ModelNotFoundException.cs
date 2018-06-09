﻿using System;

namespace Portfolio.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException()
        {

        }

        public ModelNotFoundException(string message) : base(message)
        {

        }
    }
}
