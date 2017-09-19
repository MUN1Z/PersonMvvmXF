using SQLite;

namespace PersonMvvmXF.Ioc
{
    public interface ISqLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}
