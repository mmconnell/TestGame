using UnityEngine;
using EnumsNew;

public class PoorGuy : MonoBehaviour
{
    public CharacterManager CharacterManager { get; set; }
    public int FrameCount { get; set; }

    // Use this for initialization
    void Start()
    {
        CharacterManager = GetComponent<CharacterManager>();
        EventManager.StartListening("TIME_INSTANCE", TriggerTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterManager.Trigger(Character_Trigger_Enum.FRAME);
        FrameCount++;
        if (FrameCount%30 == 0)
        {
            
            //CharacterManager.Trigger(CharacterTriggers.TURN_START);
            //CharacterManager.Trigger(CharacterTriggers.TURN_END);
            FrameCount = 0;
        }

    }

    void TriggerTime()
    {
        EventManager.TriggerEvent(gameObject, "TURN_START");
        EventManager.TriggerEvent(gameObject, "TURN_END");
        CharacterManager.Trigger(Character_Trigger_Enum.TURN_START);
        CharacterManager.Trigger(Character_Trigger_Enum.TURN_END);
    }
}
