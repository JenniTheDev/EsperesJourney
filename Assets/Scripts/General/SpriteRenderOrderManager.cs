using UnityEngine;

public class SpriteRenderOrderManager : MonoBehaviour
{

  [SerializeField] private int multiplier = -100;
  public enum RenderMode {Awake, Update}
  public enum WhatToChange {Everything, JustOne}
  [SerializeField] private RenderMode renderMode = RenderMode.Awake;
  [SerializeField] private WhatToChange whatToChange = WhatToChange.Everything;
  [SerializeField] private SpriteRenderer renderToChange;

  private SpriteRenderer[] renderers;

  public void Awake() {
    DefineRenderes();
    if(renderMode == RenderMode.Awake){
      UpdateRenderers();
    }
  }

  public void Update() {
    if(renderMode == RenderMode.Update){
      UpdateRenderers();
    }
  }

  private void DefineRenderes(){
    if(whatToChange == WhatToChange.Everything) {
      renderers = FindObjectsOfType<SpriteRenderer>();
    }
    else renderers = new SpriteRenderer[] {renderToChange};
  }

  public void UpdateRenderers(){
    foreach(SpriteRenderer renderer in renderers) {
      renderer.sortingOrder = (int)(renderer.transform.position.y * multiplier);
    }
  }


}
