using Manager;

public interface I_BaseStatusEffect
{
    void Apply(DerivedStatusEffect dse);
    void Remove(DerivedStatusEffect dse);
    void End(DerivedStatusEffect dse);
    void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum);
    StatusEnum[] GetStatusEnums();
}
