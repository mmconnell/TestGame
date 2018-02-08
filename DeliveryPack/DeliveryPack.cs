using System.Collections.Generic;

public class DeliveryPack
{
    public List<DamagePack> DamagePacks { get; set; }
    public List<EffectPack> EffectPacks { get; set; }

    public DeliveryPack()
    {
        DamagePacks = new List<DamagePack>();
        EffectPacks = new List<EffectPack>();
    }

    public void Add(DamagePack DamagePack)
    {
        DamagePacks.Add(DamagePack);
    }

    public void Add(EffectPack effectPack)
    {
        EffectPacks.Add(effectPack);
    }
}
