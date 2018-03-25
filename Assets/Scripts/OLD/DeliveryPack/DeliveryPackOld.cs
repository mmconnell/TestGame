using System.Collections.Generic;

public class DeliveryPackOld
{
    public List<DamagePackOld> DamagePacks { get; set; }
    public List<EffectPackOld> EffectPacks { get; set; }

    public DeliveryPackOld()
    {
        DamagePacks = new List<DamagePackOld>();
        EffectPacks = new List<EffectPackOld>();
    }

    public void Add(DamagePackOld DamagePack)
    {
        DamagePacks.Add(DamagePack);
    }

    public void Add(EffectPackOld effectPack)
    {
        EffectPacks.Add(effectPack);
    }
}
