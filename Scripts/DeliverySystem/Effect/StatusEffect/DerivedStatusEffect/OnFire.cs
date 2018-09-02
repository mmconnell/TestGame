using EnumsNew;
using Utility;
using Manager;
using System.Collections.Generic;

namespace DeliverySystem
{
    public class OnFire : DerivedStatusEffect
    {
        public static OnFire Cloner = new OnFire();
        private static List<I_BaseStatusEffect> statusEffects;

        private OnFire() : base() { }

        public OnFire(ToolManager owner, ToolManager target) : base(owner, target)
        {
            if (statusEffects == null)
            {
                I_DeliveryPack deliveryPack = new PriorityDeliveryPack
                {
                    AreaEffect = new SingleTarget(),
                    EffectMap = new Dictionary<int, List<I_Effect>>
                {
                    {
                        1, new List<I_Effect>
                        {
                            new DamagePack(new SimpleDamageType(Damage_Type_Enum.SHOCK), new FlatNumber(10)),
                            new SubDeliveryPack
                            {
                                IsNewAttack = true,
                                DeliveryPack = new PriorityDeliveryPack
                                {
                                    AreaEffect = new SimpleAreaCircle2D(new FlatNumber(1)),
                                    EffectMap = new Dictionary<int, List<I_Effect>>
                                    {
                                        {
                                            1, new List<I_Effect>
                                            {
                                                new DamagePack(new SimpleDamageType(Damage_Type_Enum.SHOCK), new FlatNumber(100)),
                                                new PullForceEffect(new RangeNumber(new FlatNumber(5), new FlatNumber(10)))
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                };
                statusEffects = new List<I_BaseStatusEffect>();
                DamagePack damagePack = new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new RangeNumber(new FlatNumber(20), new FlatNumber(30))/*new RangeNumber(new FlatNumber(10), new FlatNumber(20))*/);
                statusEffects.Add(new EffectOverTime(damagePack));
                statusEffects.Add(new ResistanceStatusEffect(Damage_Type_Enum.FIRE, -15));
                statusEffects.Add(new ResistanceStatusEffect(Damage_Type_Enum.COLD, 15));
                SubDeliveryPack sdp = new SubDeliveryPack
                {
                    DeliveryPack = deliveryPack,
                    IsNewAttack = false,
                    CanTargetOwner = true,
                };
                statusEffects.Add(new EffectOverTime(sdp));
            }

            foreach (I_BaseStatusEffect bse in statusEffects)
            {
                AddBaseStatusEffect(bse);
            }
        }

        public override I_DerivedStatus Clone(ToolManager owner, ToolManager target)
        {
            return new OnFire(owner, target);
        }
    }
}