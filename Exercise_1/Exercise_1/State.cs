using System;
using System.Collections.Generic;

namespace Exercise_1
{
    public class State
    {
        public Catalog Catalog { get; set; }                            
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime DateOfPurchase { get; set; }

        public State(Catalog catalog, string description, int amount, DateTime dateOfPurchase)
        {
            Catalog = catalog;
            Description = description;
            Amount = amount;
            DateOfPurchase = dateOfPurchase;
        }

        public override bool Equals(object obj)
        {
            return obj is State state &&
                   EqualityComparer<Catalog>.Default.Equals(Catalog, state.Catalog) &&
                   Description == state.Description &&
                   Amount == state.Amount &&
                   DateOfPurchase == state.DateOfPurchase;
        }

        public override int GetHashCode()
        {
            int hashCode = 94035033;
            hashCode = hashCode * -1521134295 + EqualityComparer<Catalog>.Default.GetHashCode(Catalog);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + DateOfPurchase.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "State{Book: " + Catalog + ", Description: " + Description + ", Amount: " + Amount + "DateOfPurchase: " + DateOfPurchase + "}";
        }


        //TODO: Sprawdzić toString
    }
}
