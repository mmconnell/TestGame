using Enums.Damage;
using System.Collections.Generic;

public class Bomb : DerivedStatusEffect
{
    public Bomb()
    {
        List<EffectPack> effectPacks = new List<EffectPack>();
        List<DamagePack> damagePacks = new List<DamagePack>();
        damagePacks.Add(new FlatDamage(DamageTypes.BLUDGEONING, 100));
        damagePacks.Add(new Burst(DamageTypes.BLUDGEONING, new FlatDamage(DamageTypes.BLUDGEONING, 50), 5, Enums.TeamTarget.ENEMIES));
        //effectPacks.Add(new EffectPack(100,
        //    new AuraStatusEffect(
        //        new EffectPack(100,
        //        new DamageOverTimeStatusEffect(
        //            new FlatDamage(DamageTypes.BLUDGEONING, 50)), Enums.Persistance.COMBAT, 1), Enums.TeamTarget.ALL, 5), Enums.Persistance.COMBAT, 1));
        AddBaseStatusEffect(new DelayedStatusEffect(damagePacks, effectPacks));
    }
}
