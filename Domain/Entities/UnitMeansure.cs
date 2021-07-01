using System;
using Shared.Entities;

namespace Domain.Entities
{
    public class UnitMeansure : Entity
    {
        public UnitMeansure(string name, string acronym)
        {
            Name = name;
            Acronym = acronym;
            Status = true;
        }

        public string Name { get; private set; }
        public string Acronym { get; private set; }
        public bool Status { get; private set; }

        public void Activate() => Status = true;
        public void Deactivate() => Status = false;

        public void Update(string name, string acronym)
        {
            Name = name;
            Acronym = acronym;
        }
    }
}