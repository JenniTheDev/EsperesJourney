using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomEvents : MonoBehaviour
{

  private bool isOn = false;
  private float currentTime = 0.0f;
  [Header ("Self Containted")]
  [SerializeField] private bool startOnAwake = false;
  [Tooltip ("You can set external timers as well and just call ActivateEvents()")]
  [SerializeField] private Vector2 eventRate;
  [Space]
  [Header ("Events")]
  [SerializeField] private bool activateNormalEvent = false;
  [SerializeField] private UnityEvent normalEvent;
  [SerializeField] private bool activateBoolEvent = false;
  [SerializeField] private BoolEvent boolEvent;
  [SerializeField] private bool activateIntEvent = false;
  [SerializeField] private IntEvent intEvent;
  [SerializeField] private bool activateFloatEvent = false;
  [SerializeField] private FloatEvent floatEvent;
  [SerializeField] private bool activateDoubleEvent = false;
  [SerializeField] private DoubleEvent doubleEvent;
  [SerializeField] private bool activateVector2Event = false;
  [SerializeField] private Vector2Event vector2Event;
  [SerializeField] private bool activateVector3Event = false;
  [SerializeField] private Vector3Event vector3Event;

  // Awake/Update

  public void Awake(){
    if(startOnAwake) turnOn();
  }

  public void Update(){
    if(isOn &&timer())ActivateEvents();
  }

  // Key Functions

  public void turnOn(){
    isOn = true;
  }

  public void turnOff(){
    isOn = false;
  }

  public void ActivateEvents(){
    boolEventFunct();
    intEventFunct();
    floatEventFunct();
    doubleEventFunct();
    vector2EventFunct();
    vector3EventFunct();
  }

  // Private Functions

  private bool timer(){
    currentTime += Time.deltaTime;
    if(currentTime > Random.Range(eventRate.x, eventRate.y)){
      currentTime = 0.0f;
      return true;
    }
    else return false;
  }

  private void normalEventFunct(){
    if(activateNormalEvent)normalEvent.Invoke();
  }

  private void boolEventFunct(){
    if(activateBoolEvent){
      if(Random.Range(0,100) > 50) boolEvent.Invoke(true);
      else boolEvent.Invoke(false);
    }
  }

  private void intEventFunct(){
    if(activateIntEvent)intEvent.Invoke(Random.Range(0,100));
  }

  private void floatEventFunct(){
    if(activateFloatEvent)floatEvent.Invoke(Random.Range(0,100));
  }

  private void doubleEventFunct(){
    if(activateDoubleEvent)doubleEvent.Invoke(Random.Range(0,100));
  }

  private void vector2EventFunct(){
    if(activateVector2Event)vector2Event.Invoke(new Vector2(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f)));
  }

  private void vector3EventFunct(){
    if(activateVector3Event)vector3Event.Invoke(new Vector3(Random.Range(-1,1), Random.Range(-1,1), Random.Range(-1,1)));
  }
}
