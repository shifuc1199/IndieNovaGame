
using UnityEngine;


namespace  DreamerTool.UI
{
    
 
public class View : MonoBehaviour
{
    public static Scene CurrentScene;

    public virtual void OnShow()
    {

    }
    public virtual void OnHide()
    {

    }
    private void OnEnable()
    {
        OnShow();
    }
    private void OnDisable()
    {
        OnHide();
    }
    public void OnCloseClick()
    {
        gameObject.SetActive(false);
    }
    public void OnShowClick()
    {
        gameObject.SetActive(true);
    }
}
}