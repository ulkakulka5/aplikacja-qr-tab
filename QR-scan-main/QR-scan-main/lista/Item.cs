using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_zakupow
{
    public class Item
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string NumerUrzadzenia { get; set; }
        public string ImieNazwiskoKLasa { get; set; }
        public DateTime Data { get; set; }

    }
}
