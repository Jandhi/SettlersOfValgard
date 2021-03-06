﻿using SettlersOfValgard.Old.settler;
using SettlersOfValgard.settler;

namespace SettlersOfValgard
{
    public class Settings
    {
        public static int MaxDaysPassed = 30;
        public static bool GodMode = false;
    }

    public class SettlementSettings
    {
        public static LifeStage[] FeedOrder = {LifeStage.Child, LifeStage.Elder, LifeStage.Adult};
        public static int[] GenderWeights = {10, 10, 1};
    }
}