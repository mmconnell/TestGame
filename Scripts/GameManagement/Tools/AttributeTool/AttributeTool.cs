using EnumsNew;
using System;
using Utility;

namespace Manager
{
    public class AttributeTool : AbstractTool
    {
        public static ToolEnum toolEnum;

        private FlatShiftPack[] attributes;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            int size = Enum.GetValues(typeof(Character_Attribute_Enum)).Length;
            attributes = new FlatShiftPack[size];
            for (int x = 0; x < size; x++)
            {
                attributes[x] = new FlatShiftPack();
                attributes[x].AddBase(1);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void AddShift(Character_Attribute_Enum characterAttribute, NumberShift numberShift)
        {
            attributes[(int)characterAttribute].AddShift(numberShift);
        }

        public void RemoveShift(Character_Attribute_Enum characterAttribute, NumberShift numberShift)
        {
            attributes[(int)characterAttribute].RemoveShift(numberShift);
        }

        public void AddBase(Character_Attribute_Enum characterAttribute, int flat)
        {
            attributes[(int)characterAttribute].AddBase(flat);
        }

        public void Calculate(Character_Attribute_Enum characterAttribute)
        {
            attributes[(int)characterAttribute].Calculate();
        }

        public int GetAttribute(Character_Attribute_Enum characterAttribute)
        {
            return attributes[(int)characterAttribute].FinalValue;
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}
