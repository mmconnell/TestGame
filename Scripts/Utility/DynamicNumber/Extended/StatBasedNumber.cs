using EnumsNew;
using Manager;
using UnityEngine;

namespace Utility
{
    public class StatBasedNumber : DynamicNumber
    {
        public DynamicNumber DynamicNumber { get; private set; }
        public bool SourceIsOwner { get; private set; }
        public Character_Attribute_Enum CharacterStat { get; private set; }
        private float scale;

        public StatBasedNumber(DynamicNumber dynamicNumber, Character_Attribute_Enum characterStat, float scale, bool sourceIsOwner)
        {
            DynamicNumber = dynamicNumber;
            CharacterStat = characterStat;
            SourceIsOwner = sourceIsOwner;
            this.scale = scale;
        }

        public override float GetAmount(ToolManager owner, ToolManager target)
        {
            ToolManager source = SourceIsOwner ? owner : target;
            if (source == null)
            {
                return 0;
            }
            AttributeTool at = source.Get(AttributeTool.toolEnum) as AttributeTool;
            float value = DynamicNumber.GetAmount(owner, target);
            value *= (1 + (at.GetAttribute(CharacterStat) * scale));
            return value;
        }

        public override float GetAmount(ToolManager source)
        {
            AttributeTool at = source.Get(AttributeTool.toolEnum) as AttributeTool;
            float value = DynamicNumber.GetAmount(source);
            value *= (1 + (at.GetAttribute(CharacterStat) * scale));
            return value;
        }
    }
}