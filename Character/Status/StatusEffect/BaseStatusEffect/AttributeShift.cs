public class AttributeShift
{
    public AttributeShift()
    {
        Flat = 0;
        Multiplier = 1;
        Devisor = 1;
    }

    public double Flat { get; set; }
    public double Multiplier { get; set; }
    public double Devisor { get; set; }

    public void Compose(AttributeShift attributeShift)
    {
        Flat += attributeShift.Flat;
        Multiplier += attributeShift.Multiplier;
        Devisor += attributeShift.Devisor;
    }

    public void Decompose(AttributeShift attributeShift)
    {
        Flat -= attributeShift.Flat;
        Multiplier -= attributeShift.Multiplier;
        Devisor -= attributeShift.Devisor;
    }
}
