﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration) => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (this.Fish.Any())
            {
                sb.AppendLine($"Fish: {String.Join(", ", this.Fish.Select(f => f.Name))}");
            }
            else
            {
                sb.AppendLine($"Fish: none");
            }
            //sb.AppendLine($"Fish: {(this.Fish.Any() ? String.Join(", " , this.Fish.Select(f => f.Name)) : "none")}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => this.Fish.Remove(fish);
    }
}
