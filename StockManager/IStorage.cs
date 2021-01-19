using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    interface IStorage
    {
        void Show();
        void AddEntry();
        void AddLeft();

    }
}
