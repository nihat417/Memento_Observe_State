public interface IObserver
{
    void Update();
}


public class UserInteface : IObserver
{
    public void Update()
    {
        Console.WriteLine("Interface Updated");
    }
}
public class DifferentUnit : IObserver
{
    public void Update()
    {
        Console.WriteLine("Relation Updated");
    }
}


interface IEnemy
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify();
}


public class Enemy : IEnemy
{
    private List<IObserver> observers = new List<IObserver>();
    private int _health = 10;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            Notify();
        }
    }

    public void Notify()
    {
        observers.ForEach(x => x.Update());
    }

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Enemy subject = new Enemy();

        IObserver observer1 = new UserInteface();
        subject.Subscribe(observer1);

        subject.Subscribe(new DifferentUnit());
        subject.Health++;
        Console.WriteLine("--------------------");
        subject.Unsubscribe(observer1);
        subject.Health--;
        Console.ReadLine();
    }
}