using System.Collections.Generic;

public class DeliveryPack
{
    public List<DamagePack> DamagePacks { get; set; }
    public List<EffectPack> EffectPacks { get; set; }
    public CharacterManager Owner { get; set; }

    public DeliveryPack(CharacterManager owner)
    {
        DamagePacks = new List<DamagePack>();
        EffectPacks = new List<EffectPack>();
        Owner = owner;
    }

    public void AddDamagePack(DamagePack DamagePack)
    {
        DamagePacks.Add(DamagePack);
    }

    public void AddEffectPack(EffectPack effectPack)
    {
        EffectPacks.Add(effectPack);
    }
}
