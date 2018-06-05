﻿using EnumsNew;
using Manager;
using UnityEngine;

namespace Utility
{
    public class StatBasedNumber : DynamicNumber
    {
        public DynamicNumber DynamicNumber { get; private set; }
        public bool SourceIsOwner { get; private set; }
        public Character_Stat CharacterStat { get; private set; }

        public StatBasedNumber(DynamicNumber dynamicNumber, Character_Stat characterStat, bool sourceIsOwner)
        {
            DynamicNumber = dynamicNumber;
            CharacterStat = characterStat;
            SourceIsOwner = sourceIsOwner;
        }

        public override float GetAmount(ToolManager owner, ToolManager target)
        {
            ToolManager source = SourceIsOwner ? owner : target;
            if (source == null)
            {
                return 0;
            }
            float value = DynamicNumber.GetAmount(owner, target);
            //value *= source.GetStatBonus(CharacterStat);
            return value;
        }

        public override float GetAmount(ToolManager source)
        {
            float value = DynamicNumber.GetAmount(source);
            //value *= source.GetStatBonus(CharacterStat);
            return value;
        }
    }
}