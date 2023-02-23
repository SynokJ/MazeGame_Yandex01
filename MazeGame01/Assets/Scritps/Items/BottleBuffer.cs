
public class BottleBuffer : Item
{
    protected override void OnBuffed() => TimerController.Instance.AddTime();
}
