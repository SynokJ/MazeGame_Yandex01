using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MazeGenerator : MonoBehaviour, IStateListener
{
    [Header("Maze Components: ")]
    [SerializeField] private GameObject _wallHorizontal;
    [SerializeField] private GameObject _wallVertical;

    [SerializeField] private GameObject _wallPref;
    [SerializeField] private GameObject _wallParent;

    [SerializeField] private bool _isBetaVersion;

    private const float _MAZE_SCALE = 5.0f;

    private Maze _maze;

    private void OnEnable()
    {
        GameStateListener.Listen(this);
    }

    private void OnDisable()
    {
        GameStateListener.CloseListener(this);
    }

    public void CreateMaze()
    {
        GenerateMazeBasic();
        GenerateRandomPaths();

        if (_wallParent.GetComponent<CompositeShadowCaster2D>() == null)
            _wallParent.AddComponent<CompositeShadowCaster2D>();

        AstarPath.active.Scan();
    }

    public void GenerateMazeBasic()
    {
        DestroyMaze();

        _maze = new Maze();

        if (_isBetaVersion)
            _maze.InitData(_wallPref, _wallParent.transform);
        else
            _maze.InitDataWithWalls(_wallHorizontal, _wallVertical, _wallParent.transform);

        _wallParent.transform.localScale *= _MAZE_SCALE;
    }

    public void GenerateRandomPaths()
    {
        _maze.SetRandomPath();
    }

    public void DestroyMaze()
    {
        if (_maze == null)
            return;

        _maze.ClearMaze();
    }

    public void OnGameStarted()
    {
        CreateMaze();
    }

    public void OnGameFinished()
    {
        if (_wallParent == null)
            return;

        if (_wallParent.GetComponent<CompositeShadowCaster2D>() != null)
            Destroy(_wallParent.GetComponent<CompositeShadowCaster2D>());
    }
}
