﻿using AviationWx.NET.Models.Enums;

namespace AviationWx.NET.Models.DTOs
{
    public class SkyConditionDto
    {
        public SkyConditionType SkyCondition { get; set; }

        public int CloudBase_Ft { get; set; }
    }
}
