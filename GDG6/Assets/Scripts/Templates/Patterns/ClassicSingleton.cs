
public class ClassicSingleton
{
    private static ClassicSingleton _instance;

    protected ClassicSingleton() {}

    public static ClassicSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ClassicSingleton();
            }
            return _instance;
        }
    }
}