﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace LearnEnglishWords.DatabaseConfig.Entities.Interfaces
{
    public interface IDeleteMarker
    {
        bool Deleted { get; set; }
    }
}