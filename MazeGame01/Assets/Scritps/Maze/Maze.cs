public class Maze
{

    private const int _MAZE_SIZE = 11;
    private const int _MAZE_SCALE = 10;

    private Cell[,] _data = new Cell[_MAZE_SIZE, _MAZE_SIZE];

    public readonly int size = _MAZE_SIZE;

    public Maze()
    {
    }

    ~Maze()
    {
        _data = null;
    }


    public void InitData(UnityEngine.GameObject wallPref, UnityEngine.Transform parent)
    {
        for (int y = 0; y < _MAZE_SIZE; ++y)
            for (int x = 0; x < _MAZE_SIZE; ++x)
            {
                _data[y, x] = new Cell(x, y);
                _data[y, x].SetType(Cell.CellType.Free);
                _data[y, x].SpawnWalls(wallPref, UnityEngine.Vector2.zero - UnityEngine.Vector2.one * size * 0.5f, parent);
            }

        for (int y = 0; y < _MAZE_SIZE; ++y)
            for (int x = 0; x < _MAZE_SIZE; ++x)
            {
                _data[y, x].AddNeighrbours((y + 1 >= _MAZE_SIZE) ? new Cell(-1, -1) : _data[y + 1, x], 0);
                _data[y, x].AddNeighrbours((x + 1 >= _MAZE_SIZE) ? new Cell(-1, -1) : _data[y, x + 1], 1);
                _data[y, x].AddNeighrbours((y - 1 < 0) ? new Cell(-1, -1) : _data[y - 1, x], 2);
                _data[y, x].AddNeighrbours((x - 1 < 0) ? new Cell(-1, -1) : _data[y, x - 1], 3);
            }
    }

    public void InitDataWithWalls(UnityEngine.GameObject wallHorPref, UnityEngine.GameObject wallVerPref, UnityEngine.Transform parent)
    {
        for (int y = 0; y < _MAZE_SIZE; ++y)
            for (int x = 0; x < _MAZE_SIZE; ++x)
            {
                _data[y, x] = new Cell(x, y);
                _data[y, x].SetType(Cell.CellType.Free);
                _data[y, x].SpawnWallsWithType(wallHorPref, wallVerPref, UnityEngine.Vector2.zero - UnityEngine.Vector2.one * size * 0.5f, parent);
            }

        for (int y = 0; y < _MAZE_SIZE; ++y)
            for (int x = 0; x < _MAZE_SIZE; ++x)
            {
                _data[y, x].AddNeighrbours((y + 1 >= _MAZE_SIZE) ? new Cell(-1, -1) : _data[y + 1, x], 0);
                _data[y, x].AddNeighrbours((x + 1 >= _MAZE_SIZE) ? new Cell(-1, -1) : _data[y, x + 1], 1);
                _data[y, x].AddNeighrbours((y - 1 < 0) ? new Cell(-1, -1) : _data[y - 1, x], 2);
                _data[y, x].AddNeighrbours((x - 1 < 0) ? new Cell(-1, -1) : _data[y, x - 1], 3);
            }
    }

    public void GenerateCoins()
    {

    }

    public void SetRandomPath()
    {
        int centerPoint = (int)(_MAZE_SIZE * 0.5f);

        StartWalking(_data[centerPoint, centerPoint]);
    }


    private void StartWalking(Cell startPoint)
    {

        if (startPoint == null)
            return;

        if (startPoint.TryGetRandomNeighbour(out Cell res))
            StartWalking(res);
    }

    public void ClearMaze()
    {
        for (int r = 0; r < _MAZE_SIZE; ++r)
            for (int c = 0; c < _MAZE_SIZE; ++c)
                _data[r, c].DestroyWalls();
    }

    public override string ToString()
    {
        string res = default;
        for (int r = 0; r < _MAZE_SIZE; ++r)
        {
            for (int c = 0; c < _MAZE_SIZE; ++c)
                res += _data[r, c] + " ";
            res += '\n';
        }

        return res;
    }
}
