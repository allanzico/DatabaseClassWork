using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            ADO ado = new ADO();
            //ado.createDB();
           // ado.createTable();
            ado.insertData();
            //ado.updateTable();
           //ado.deleteFromTable();
            Console.ReadLine();



        }
    }
}
