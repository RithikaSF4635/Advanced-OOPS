using System;
using System.Collections.Generic;
using DependenceInjection;
namespace DependenceIjection;
public class Program
{
    public static void Main(string[] args)
    {
        CAccount cAccount=new CAccount();
        cAccount.AccountNumber=123;
        cAccount.Name="rithi";
        cAccount.Balance=1000000;

        SBAccount sbAccount=new SBAccount();
        sbAccount.AccountNumber=123;
        sbAccount.Name="rithi";
        sbAccount.Balance=500000;

        List<CAccount> ccList=new List<CAccount>();
        ccList.Add(cAccount);

        List<SBAccount> sbList=new List<SBAccount>();
        sbList.Add(sbAccount);

        List<IAccounts> accountList=new List<IAccounts>();
        accountList.Add(cAccount);
        accountList.Add(sbAccount);

    }
}