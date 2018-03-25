using Enums.Damage;
using System.Collections.Generic;

public class BombOld : DerivedStatusEffectOld
{
    public BombOld()
    {
        DeliveryPackOld dp = new DeliveryPackOld();
        dp.Add(new FlatDamageOld(DamageTypes.BLUDGEONING, 100));
        dp.Add(new BurstOld(DamageTypes.BLUDGEONING, new FlatDamageOld(DamageTypes.BLUDGEONING, 50), 5, Enums.Team_Target.ENEMIES));
        //effectPacks.Add(new EffectPack(100,
        //    new AuraStatusEffect(
        //        new EffectPack(100,
        //        new DamageOverTimeStatusEffect(
        //            new FlatDamage(DamageTypes.BLUDGEONING, 50)), Enums.Persistance.COMBAT, 1), Enums.TeamTarget.ALL, 5), Enums.Persistance.COMBAT, 1));
        AddBaseStatusEffect(new DelayedStatusEffectOld(dp));
    }
}
