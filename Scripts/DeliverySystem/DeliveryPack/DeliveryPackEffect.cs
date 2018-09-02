using Manager;
using System.Collections.Generic;

namespace DeliverySystem
{
    public class DeliveryPackEffect : I_DeliveryPack
    {
        public I_Effect Effect { get; set; }
        public I_AreaEffect AreaEffect { get; set; }

        public DeliveryPackEffect(I_Effect effect, I_AreaEffect areaEffect)
        {
            Effect = effect;
            AreaEffect = areaEffect ?? DeliveryUtility.SINGLE_TARGET_EFFECT;
        }

        public DeliveryPackEffect()
        {
            AreaEffect = DeliveryUtility.SINGLE_TARGET_EFFECT;
        }

        public void Apply(ToolManager owner, I_Position position, DeliveryInformation di, bool isNewAttack)
        {
            if (Effect != null)
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
                        di.currentPosition = position;
                        Effect.Apply(owner, target, di, drp);
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
}
