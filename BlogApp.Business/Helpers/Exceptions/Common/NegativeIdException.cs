﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Helpers.Exceptions.Common
{
    public class NegativeIdException : Exception
    {
        public NegativeIdException() : base("Id 0 ve ya menfi olabilmez") { }

        public NegativeIdException(string? message) : base(message)
        {
        }
    }
}
