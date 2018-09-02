using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manager;

namespace DeliverySystem
{
    public class SimpleDeliveryPack : I_DeliveryPack
    {
        public List<I_Effect> Effects { get; set; }
        public I_AreaEffect AreaEffect { get; set; }

        public SimpleDeliveryPack(List<I_Effect> effects, I_AreaEffect areaEffect)
        {
            Effects = effects ?? new List<I_Effect>();
            AreaEffect = areaEffect ?? DeliveryUtility.SINGLE_TARGET_EFFECT;
        }

        public SimpleDeliveryPack()
        {
            Effects = new List<I_Effect>();
            AreaEffect = new SingleTarget();
        }

        public void AddEffect(I_Effect effect)
        {
            Effects.Add(effect);
        }

        public void Apply(ToolManager owner, I_Position position, DeliveryInformation di, bool isNewAttack)
        {
            List<ToolManager> targets = AreaEffect.GatherTargets(position, owner);
            bool canTargetOwner = di.canTargetOwner;
            foreach (ToolManager target in targets)
            {
                if (canTargetOwner || owner != target)
                {
                    DeliveryResultPack drp = null;
                    if (!di.packInfo.TryGetValue(target, out drp))
                    {
                        drp = DeliveryResultPack.GetPack(target);
                        di.packInfo.Add(target, drp);
                    }
                    if (isNewAttack)
                    {
                        if (!drp.GetCurrent().empty)
                        {
                            drp.SetNext();
                        }
                        drp.GetCurrent().empty = false;
                        drp.GetCurrent().Owner = owner;
                    }
                    foreach (I_Effect effect in Effects)
                    {
                        di.currentPosition = position;
                        effect.Apply(owner, target, di, drp);
                    }
                }
            }
            if (isNewAttack)
            {
                foreach (DeliveryResultPack drp in di.packInfo.Values)
                {
                    drp.PublishCurrent();
                }
            }
        }
    }
}
