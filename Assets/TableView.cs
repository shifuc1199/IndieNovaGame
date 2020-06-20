using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableView<Cell, Model, CommonModel> : MonoBehaviour where Cell : ModelCell<Model, CommonModel>
{
    public GameObject cellPrefab;
    private List<Cell> cellList = new List<Cell>();

    public virtual void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        
    }
    public virtual void AddCell(Model model,CommonModel commonModel)
    {
        var cellObj = Instantiate(cellPrefab, transform);
        var cell = cellObj.GetComponent<Cell>();
        cell.SetModel(model,commonModel);    
        cellList.Add(cell);
    }

    public virtual void ClearCell()
    {
        foreach (var cell in cellList)
        {
            Destroy(cell.gameObject);
        }
        cellList.Clear();
    }

    public virtual void SetCommonModel(CommonModel commonModel)
    {
        foreach (var cell in cellList)
        {
            cell.UpdateCommonModel(commonModel);
        }
    }
    
    public virtual void RefreshAllCell()
    {
        foreach (var cell in cellList)
        {
            cell.Refresh();
        }
    }
    public virtual void RemovelCell(Model model)
    {
        var cell = cellList.Find(m => { return m.GetModel().Equals(model); });
        cellList.Remove(cell);
        Destroy(cell.gameObject);
        
    }
}


public class TableView<Cell,Model> : MonoBehaviour where Cell : ModelCell<Model>
{
    public GameObject cellPrefab;
    private List<Cell> cellList = new List<Cell>();

    public virtual void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        
    }
    public virtual void AddCell(Model model)
    {
        var cellObj = Instantiate(cellPrefab, transform);
        var cell = cellObj.GetComponent<Cell>();
        cell.SetModel(model);    
        cellList.Add(cell);
    }

    public virtual void ClearCell()
    {
        foreach (var cell in cellList)
        {
            Destroy(cell.gameObject);
        }
        cellList.Clear();
    }
    public virtual void RefreshAllCell()
    {
        foreach (var cell in cellList)
        {
            cell.Refresh();
        }
    }
    public virtual void RemovelCell(Model model)
    {
        var cell = cellList.Find(m => { return m.GetModel().Equals(model); });
        cellList.Remove(cell);
        Destroy(cell.gameObject);
        
    }
}
