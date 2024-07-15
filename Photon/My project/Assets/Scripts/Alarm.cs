using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum AlarmType
{ 
    Alarm,
    NickName,
}
public class Alarm : MonoBehaviour
{
    [SerializeField] Text content;

    public static void Show(string massage, AlarmType alarmType)
    {
        GameObject window = Instantiate(Resources.Load<GameObject>(alarmType.ToString()));

        window.GetComponent<Alarm>().content.text = massage;

        window.GetComponent<Alarm>().content.fontSize = 65;

        window.GetComponent<Alarm>().content.alignment = TextAnchor.MiddleCenter;
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
