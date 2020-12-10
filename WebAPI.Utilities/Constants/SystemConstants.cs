﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "WebAPI";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefautLanguageId";

            public const string Token = "Token";

            public const string BaseAddress = "BaseAddress";

        }
        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLatestProducts = 6;
        }
    }

}
