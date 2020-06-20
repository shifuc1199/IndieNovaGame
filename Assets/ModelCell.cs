using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelCell<T>: MonoBehaviour
{
    protected T model;
    
    public virtual void SetModel(T model)
    {
       this.model = model;
       
    }

    public T GetModel()
    {
        return model;
    }
    public virtual void Refresh()
    {
         
    }
}

public class ModelCell<T,V>: MonoBehaviour
{
    protected T model;
    protected V commonModel;
    public virtual void SetModel(T model,V commonModel)
    {
        this.model = model;
        this.commonModel = commonModel;
    }
    public virtual void UpdateModel(T model)
    {
        this.model = model;
    }
    public virtual void UpdateCommonModel(V commonModel)
    {
        this.commonModel = commonModel;
    }
    public T GetModel()
    {
        return model;
    }
    public virtual void Refresh()
    {
         
    }
}