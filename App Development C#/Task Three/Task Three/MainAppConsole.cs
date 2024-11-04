namespace Task_Three;
public class MainAppConsole
{
    public ObservableCollection<Store> stores { get; set; }
    public readonly Database database;
    public MainAppConsole()
    {
        stores = new();
        database = new();
        ReadDB();
    }

    #region Query by ID
    public void QueryByID()
    {
        int id;
        Store? store;
        while (true)
        {
            WriteLine("\nEnter employee ID: ");
            string? input = ReadLine();
            id = Util.ParseInt(input);
            if (Util.ParseInt(input) == Util.BAD_INT)
            {
                WriteLine("Invalid ID");
            }
            else
            {
                store = stores.FirstOrDefault(s => s.Id == id);
                if (store == null)
                    WriteLine($"Could not find employee id: {id}");
                else
                {
                    WriteLine(store);
                    break;
                }
            }
        }
    }
    #endregion

    #region Print method
    public void Print()
    {
        WriteLine("==Employee List==\n");
        stores.ToList().ForEach(item => WriteLine(item));
    }
    #endregion

    #region ReadDB
    public void ReadDB()
    {
        database.ReadItems().ForEach(x => stores.Add(x));
    }
    #endregion
}