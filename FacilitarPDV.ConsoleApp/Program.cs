using FacilitarPDV.Domain.Commands.Handlers;
using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Domain.ValueObjects;
using FacilitarPDV.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilitarPDV.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Cash cash = new Cash(
                10,
                ECashStatus.Open,
                new DateTime(2020, 01, 01),
                new DateTime(2010, 01, 02),
                "",
                "",
                new User("teste", "teste", new Name("teste", "teste")),
                new User("teste", "teste", new Name("teste", "teste"))
            );

            CashRepository repositorio = new CashRepository();
            CashHandler handler;

            repositorio.Insert(cash);

            Console.ReadKey();
        }
    }
}
