﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonalCar { TradeMark = "Hyundai", Model = "Tucson", HirePrice = 5000 };
            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine("Concrete : {0} ", personelCar.HirePrice);
            Console.WriteLine("Special offer : {0} ", specialOffer.HirePrice);

            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string TradeMark { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar:CarBase
    {
        public override string TradeMark { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    
    class CommercialCar:CarBase
    {
        public override string TradeMark { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase:CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer:CarDecoratorBase
    {
        public double DiscountPercentage { get; set; }        
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string TradeMark { get; set; }
        public override string Model { get; set; }

        public override decimal HirePrice
        {
            get
            {
                return _carBase.HirePrice - _carBase.HirePrice * Convert.ToDecimal(DiscountPercentage/100);
            }
            set
            {

            }
        }
    }
}
