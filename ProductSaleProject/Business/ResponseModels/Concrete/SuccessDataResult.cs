﻿using Entities.ResponseModels.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ResponseModels.Concrete
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data):base(data, true)
        {

        }
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
    }
}
