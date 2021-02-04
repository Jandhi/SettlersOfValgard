using System;
using System.Collections.Generic;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public abstract class Relationship
    {
        public Settler Settler1 { get; }
        public RelationshipRole Role1 { get; }
        public Settler Settler2 { get; }
        public RelationshipRole Role2 { get; }

        public Settler[] Settlers => new[] {Settler1, Settler2};

        public int Value;
        public const int MinValue = -30;
        public const int MaxValue = 30;

        protected Relationship(SettlerManager sm, int value, Settler settler1, RelationshipRole role1, Settler settler2,
            RelationshipRole role2)
        {
            Value = value;
            Settler1 = settler1;
            Role1 = role1;
            Settler2 = settler2;
            Role2 = role2;

            settler1.Relationships.Add(this);
            settler2.Relationships.Add(this);
            sm.Add(this);
        }

        public bool Contains(Settler settler)
        {
            return settler == Settler1 || settler == Settler2;
        }

        public bool Either(Func<Settler, bool> func)
        {
            return func(Settler1) || func(Settler2);
        }

        public bool Both(Func<Settler, bool> func)
        {
            return func(Settler1) && func(Settler2);
        }

        public bool Contains(Settler settler1, Settler settler2)
        {
            return (settler1 == Settler1 && settler2 == Settler2) && (settler2 == Settler1 && settler1 == Settler2);
        }

        public Settler Other(Settler settler)
        {
            if (settler == Settler1) return Settler2;
            return settler == Settler2 ? Settler1 : null;
        }

        public RelationshipRole Role(Settler settler)
        {
            if (settler == Settler1) return Role1;
            return settler == Settler2 ? Role2 : null;
        }

        public void Increase(int amount)
        {
            Value = Math.Min(MaxValue, Value + amount);
        }
        
        public void Decrease(int amount)
        {
            Value = Math.Max(MinValue, Value - amount);
        }

        public RelationshipLevel Level => RelationshipLevel.Get(Value);
    }
}