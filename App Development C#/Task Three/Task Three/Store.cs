using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Three
{
    #region Getters, setters and what not
    public class Store
    {
        [PrimaryKey, AutoIncrement]

        public string? Role { get; set; }
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name,-15}{this.Role,-5} {this.Id,-10} {this.FullName,-20} {this.Age,-15}";
        }
    }
    #endregion

    #region Salespersons Table
    [Table("Salesperson")]
    public class Salesperson: Store
    {
        public int SalesVolume { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"{this.SalesVolume,10}";
        }
    }
    #endregion

    #region Manager Table
    [Table("Manager")]
    public class Manager : Store
    {
        public int TeamSize { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"{this.TeamSize,10}";
        }
    }
    #endregion
}