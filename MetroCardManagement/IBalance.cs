using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public interface IBalance
    {
        //Property
        double WalletBalance{get;}

        //methods
        void WalletRecharge(double amount);

        void DeductBalance(double amount);

    }
}