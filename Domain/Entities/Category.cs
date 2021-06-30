using Shared.Entities;
using System;

namespace Domain.Entities
{
    public class Category : Entity
    {
        public Category(string name)
        {
            Name = name;
            Active = true;
        }

        public string Name { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}