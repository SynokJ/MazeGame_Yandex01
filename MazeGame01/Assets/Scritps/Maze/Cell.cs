using UnityEditor;
using UnityEngine;

public class Cell
{

    public enum CellType
    {
        Passed = 0,
        Free = 1
    }

    public enum WallType
    {
        top = 0,
        right = 1,
        bottom = 2,
        left = 3
    }

    public int posX { private set; get; }
    public int posY { private set; get; }

    private const int _NEIGHBOUR_AMOUNT = 4;
    private Cell[] _neighbours = new Cell[_NEIGHBOUR_AMOUNT];
    private System.Collections.Generic.List<UnityEngine.GameObject> _walls 
        = new System.Collections.Generic.List<UnityEngine.GameObject>();

    private Cell _parentCell;

    private CellType _type;

    public Cell(int x, int y)
    {
        posX = x;
        posY = y;
    }

    ~Cell()
    {
        _neighbours = null;
        _walls.Clear();
    }

    public void AddNeighrbours(Cell neighbour, int index)
    {
        if (index >= 4)
            throw new System.Exception("index out of rage");

        _neighbours[index] = neighbour;
    }


    private UnityEngine.Vector2 _topPos;
    private UnityEngine.Vector2 _rightPos;
    private UnityEngine.Vector2 _bottomPos;
    private UnityEngine.Vector2 _leftPos;

    private UnityEngine.GameObject _top;
    private UnityEngine.GameObject _right;
    private UnityEngine.GameObject _bottom;
    private UnityEngine.GameObject _left;

    private float _wallSize;
    private float _wallSizeHor;
    private float _wallSizeVer;

    public void SpawnWalls(UnityEngine.GameObject pref, UnityEngine.Vector2 originPos, UnityEngine.Transform parentTr)
    {

        _wallSize = pref.transform.localScale.y;
        originPos += UnityEngine.Vector2.one * _wallSize * 0.5f;

        _topPos = new UnityEngine.Vector2(posX, _wallSize * 0.5f + posY);
        _rightPos = new UnityEngine.Vector2(_wallSize * 0.5f + posX, posY);
        _bottomPos = new UnityEngine.Vector2(posX, -_wallSize * 0.5f + posY);
        _leftPos = new UnityEngine.Vector2(-_wallSize * 0.5f + posX, posY);

        _top = UnityEngine.GameObject.Instantiate(pref, _topPos + originPos, UnityEngine.Quaternion.Euler(0.0f, 0.0f, 90.0f));
        _right = UnityEngine.GameObject.Instantiate(pref, _rightPos + originPos, UnityEngine.Quaternion.identity);
        _bottom = UnityEngine.GameObject.Instantiate(pref, _bottomPos + originPos, UnityEngine.Quaternion.Euler(0.0f, 0.0f, 90.0f));
        _left = UnityEngine.GameObject.Instantiate(pref, _leftPos + originPos, UnityEngine.Quaternion.identity);

        _top.transform.parent = parentTr;
        _right.transform.parent = parentTr;
        _bottom.transform.parent = parentTr;
        _left.transform.parent = parentTr;

        _walls.Add(_top);
        _walls.Add(_right);
        _walls.Add(_bottom);
        _walls.Add(_left);
    }

    public void SpawnWallsWithType(UnityEngine.GameObject prefHor, UnityEngine.GameObject prefVer, UnityEngine.Vector2 originPos, UnityEngine.Transform parentTr)
    {

        _wallSize = prefVer.transform.localScale.y;

        originPos += UnityEngine.Vector2.one * _wallSize * 0.5f;

        _topPos = new UnityEngine.Vector2(posX, _wallSize * 0.5f + posY);
        _rightPos = new UnityEngine.Vector2(_wallSize * 0.5f + posX, posY);
        _bottomPos = new UnityEngine.Vector2(posX, -_wallSize * 0.5f + posY);
        _leftPos = new UnityEngine.Vector2(-_wallSize * 0.5f + posX, posY);

        _top = UnityEngine.GameObject.Instantiate(prefHor, _topPos + originPos, UnityEngine.Quaternion.identity);
        _right = UnityEngine.GameObject.Instantiate(prefVer, _rightPos + originPos, UnityEngine.Quaternion.identity);
        _bottom = UnityEngine.GameObject.Instantiate(prefHor, _bottomPos + originPos, UnityEngine.Quaternion.identity);
        _left = UnityEngine.GameObject.Instantiate(prefVer, _leftPos + originPos, UnityEngine.Quaternion.identity);

        _top.transform.parent = parentTr;
        _right.transform.parent = parentTr;
        _bottom.transform.parent = parentTr;
        _left.transform.parent = parentTr;

        _walls.Add(_top);
        _walls.Add(_right);
        _walls.Add(_bottom);
        _walls.Add(_left);
    }

    public void DestroyWalls()
    {
        foreach (var wall in _walls)
            if (!Application.isPlaying)
                UnityEngine.GameObject.DestroyImmediate(wall);
            else if (Application.isPlaying)
                UnityEngine.GameObject.Destroy(wall);
    }

    public void DestroyCertainWallByType(WallType type)
    {
        if (_walls.Count != 4)
            return;

        switch (type)
        {
            case WallType.top: UnityEngine.GameObject.DestroyImmediate(_walls[0]); break;
            case WallType.right: UnityEngine.GameObject.DestroyImmediate(_walls[1]); break;
            case WallType.bottom: UnityEngine.GameObject.DestroyImmediate(_walls[2]); break;
            case WallType.left: UnityEngine.GameObject.DestroyImmediate(_walls[3]); break;
        }
    }

    public void DestroyWallsRound()
    {
        DestroyWalls();

        _neighbours[0].DestroyCertainWallByType(WallType.bottom);
        _neighbours[1].DestroyCertainWallByType(WallType.left);
        _neighbours[2].DestroyCertainWallByType(WallType.top);
        _neighbours[3].DestroyCertainWallByType(WallType.right);
    }

    private System.Collections.Generic.List<System.Tuple<Cell, int>> _analyzingCells = new System.Collections.Generic.List<System.Tuple<Cell, int>>();
    private System.Random rand = new System.Random();
    public bool TryGetRandomNeighbour(out Cell res)
    {
        res = default;
        _analyzingCells.Clear();

        for (int i = 0; i < _neighbours.Length; ++i)
            if (_neighbours[i].IsCellPickable())
                _analyzingCells.Add(new System.Tuple<Cell, int>(_neighbours[i], i));

        if (_analyzingCells.Count == 0)
        {
            res = _parentCell;
            _type = CellType.Passed;

            return _parentCell != null;
        }

        int indexOfCell = rand.Next(0, _analyzingCells.Count);
        _type = CellType.Passed;

        res = _analyzingCells[indexOfCell].Item1;

        res.SetParent(this);
        RemovePairWall(res, _analyzingCells[indexOfCell].Item2);

        return true;
    }

    private void RemovePairWall(Cell neighbourCell, int id)
    {
        switch (id)
        {
            case 0:
                DestroyCertainWallByType(WallType.top);
                neighbourCell.DestroyCertainWallByType(WallType.bottom);
                break;
            case 1:
                DestroyCertainWallByType(WallType.right);
                neighbourCell.DestroyCertainWallByType(WallType.left);
                break;
            case 2:
                neighbourCell.DestroyCertainWallByType(WallType.top);
                DestroyCertainWallByType(WallType.bottom);
                break;
            case 3:
                DestroyCertainWallByType(WallType.left);
                neighbourCell.DestroyCertainWallByType(WallType.right);
                break;
        }
    }

    public bool IsCellPickable()
    {
        if (_type == CellType.Passed)
            return false;
        else if (posX == -1 && posY == -1)
            return false;

        return true;
    }

    public void SetType(CellType type) 
        => _type = type;

    public void SetParent(Cell parent) 
        => _parentCell = parent;

    public CellType GetType() 
        => _type;

    public Cell GetParent() 
        => _parentCell;

    public override string ToString() 
        => $"[{posY}, {posX}]";

    public void PrintNeighbours()
    {
        string res = default;

        for (int i = 0; i < _neighbours.Length; ++i)
            if (_neighbours != null)
                res += _neighbours[i].ToString();

        UnityEngine.Debug.Log($"[{posX}, {posY}] => ({res})");
    }

}