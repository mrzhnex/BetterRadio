﻿using Exiled.API.Interfaces;

namespace BetterRadio
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool IsFullRp { get; set; } = false;
    }
}