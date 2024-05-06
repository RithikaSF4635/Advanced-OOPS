using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public interface IBalance
    {
        //property
        double WalletBalance{get;}

        //Methods
        void WalletRecharge(double amount);
        void DeductBalance(double amount);
    }
}