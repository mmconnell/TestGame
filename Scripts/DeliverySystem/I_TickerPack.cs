﻿namespace DeliverySystem
{
    public interface I_TickerPack
    {
        I_Ticker Build(I_DerivedStatus status);
    }
}