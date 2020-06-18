using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace DreamerTool.UI
{

public class Scene : MonoBehaviour
{
    public Transform _root;
   
    public Dictionary<string, View> _views = new Dictionary<string, View>();

    private static Camera UICamera;
    public static Camera GetUICamera()
    {
        if (UICamera != null)
        {
            return UICamera;
        }
        return null;
    }
    public virtual void Awake()
    {
        View.CurrentScene = this;

        var UICameraGameObject = GameObject.Find("UICamera");

        if (UICameraGameObject)
            UICamera = UICameraGameObject.GetComponent<Camera>();

        if (_root)
        {
            for (int i = 0; i < _root.childCount; i++)
            {
                var child = _root.GetChild(i);
                if (child.GetComponent<View>())
                    _views.Add(child.name, child.GetComponent<View>());
            }
        }

    }
 
    public T OpenView<T>() where T : View
    {
        var _name = typeof(T).Name;
        if (!_views.ContainsKey(_name))
            return null;
        _views[_name].gameObject.SetActive(true);

        return (T)_views[_name];
    }
    public T GetView<T>() where T : View
    {
        var _name = typeof(T).Name;
        if (!_views.ContainsKey(_name))
            return null;

        return (T)_views[_name];
    }
    public T CloseView<T>() where T : View
    {
        var _name = typeof(T).Name;
        if (!_views.ContainsKey(_name))
            return null;
        _views[_name].gameObject.SetActive(false);
        return (T)_views[_name];
    }
    public void SceneChange(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
 
}
    

    
}