using System.Collections.Generic;

public class DeliveryPack
{
    public List<DamagePack> DamagePack { get; set; }
    public List<EffectPack> EffectPack { get; set; }

    public DeliveryPack()
    {
        DamagePack = new List<DamagePack>();
        EffectPack = new List<EffectPack>();
    }

    public void AddDamagePack(DamagePack damagePack)
    {
        DamagePack.Add(damagePack);
    }

    public void AddEffectPack(EffectPack effectPack)
    {
        EffectPack.Add(effectPack);
    }
}
