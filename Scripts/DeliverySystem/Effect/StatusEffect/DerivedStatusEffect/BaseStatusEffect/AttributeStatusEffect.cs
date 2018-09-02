using EnumsNew;
using Manager;

namespace DeliverySystem
{ 
    public class AttributeStatusEffect : I_BaseStatusEffect
    {
        private Character_Attribute_Enum AttributeType { get; set; }
        private NumberShift NumberShift { get; set; }

        public AttributeStatusEffect(Character_Attribute_Enum attributeType, int shiftAmount)
        {
            AttributeType = attributeType;
            NumberShift = new NumberShift
            {
                Flat = shiftAmount
            };
        }

        public void Apply(DerivedStatusEffect dse)
        {
            AttributeTool attributeTool = dse.target.Get(AttributeTool.toolEnum) as AttributeTool;
            if (attributeTool)
            {
                attributeTool.AddShift(AttributeType, NumberShift);
            }
        }

        public void End(DerivedStatusEffect dse)
        {
            Remove(dse);
        }

        public void Remove(DerivedStatusEffect dse)
        {
            AttributeTool attributeTool = dse.target.Get(AttributeTool.toolEnum) as AttributeTool;
            if (attributeTool)
            {
                attributeTool.RemoveShift(AttributeType, NumberShift);
            }
        }

        public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum) { }

        public static StatusEnum[] statusEnums = new StatusEnum[] { };
        public StatusEnum[] GetStatusEnums()
        {
            return statusEnums;
        }
    }
}