namespace Task_Three;

public class Database
{
    private readonly SQLiteConnection _connection;

    #region Path
    public Database()
    {
        var dataDir = @"C:/Users/jonty/OneDrive/Desktop/App Dev/Tasks/Task Three/Task Three/bin/Debug";
        var dbPath = Path.Combine(dataDir, "EmployeeData.db");
        _connection = new SQLiteConnection(dbPath);
    }
    #endregion

    #region Read Items
    public List<Store> ReadItems()
    {
        var emp = new List<Store>();
        var list = _connection.Table<Salesperson> ().ToList();
        emp.AddRange(list);

        var listTwo = _connection.Table<Manager>().ToList();
        emp.AddRange(listTwo);

        return emp;
    }
    #endregion
}
