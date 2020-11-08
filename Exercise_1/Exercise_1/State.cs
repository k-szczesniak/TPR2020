using System;
using System.Collections.Generic;

namespace Exercise_1
{
    public class State
    {
        public Catalog Catalog { get; set; }                            
        public string Description { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public bool IsAvailable { get; set; }

        public State(Catalog catalog, string description, DateTime dateOfPurchase, bool isAvailable)
        {
            Catalog = catalog;
            Description = description;
            DateOfPurchase = dateOfPurchase;
            IsAvailable = isAvailable;
        }

        public override bool Equals(object obj)
        {
            return obj is State state &&
                   EqualityComparer<Catalog>.Default.Equals(Catalog, state.Catalog) &&
                   Description == state.Description &&
                   DateOfPurchase == state.DateOfPurchase &&
                   IsAvailable == state.IsAvailable;
        }

        public override int GetHashCode()
        {
            int hashCode = 1012177992;
            hashCode = hashCode * -1521134295 + EqualityComparer<Catalog>.Default.GetHashCode(Catalog);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + DateOfPurchase.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAvailable.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "State{Book: " + Catalog + ", Description: " + Description + ", DateOfPurchase: " + DateOfPurchase + "IsAvailable: " + IsAvailable + "}";
        }
    }
}
