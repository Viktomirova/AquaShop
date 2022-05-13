﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorations.AsReadOnly();

        public void Add(IDecoration model) => this.decorations.Add(model);

        public IDecoration FindByType(string type) => this.decorations.FirstOrDefault(d => d.GetType().Name == type);

        public bool Remove(IDecoration model) => this.decorations.Remove(model);
    }
}
