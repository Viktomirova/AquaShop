namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void Ctor()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            Assert.That(aquarium.Name == "a");
            Assert.That(aquarium.Capacity == 1);
        }

        [Test]
        public void NameIsInCorrect()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(String.Empty, 1));
        }

        [Test]
        public void NameIsCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            Assert.That("a", Is.EqualTo(aquarium.Name));
        }

        [Test]
        public void CapacityIsInCorrect()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("a", -1));
        }

        [Test]
        public void CapacityIsCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            Assert.That(1, Is.EqualTo(aquarium.Capacity));
        }

        [Test]
        public void FishCountIsCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 5);
            Fish fish1 = new Fish("Poly");
            Fish fish2 = new Fish("Petra");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            
            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void AddFishIsInCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            Fish fish1 = new Fish("Poly");
            Fish fish2 = new Fish("Petra");
            aquarium.Add(fish1);
            
            Assert.Throws<InvalidOperationException>(()=> aquarium.Add(fish2));
        }

        [Test]
        public void AddFishIsCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            Fish fish1 = new Fish("Poly");
            aquarium.Add(fish1);
            Assert.That(fish1.Available == true);
        }

        [Test]
        public void AddFishIsNotCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 0);
            Assert.Throws<InvalidOperationException>(()=> aquarium.Add(new Fish("Peppy")));
        }

        [Test]
        public void RemoveFishIsCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 5);
            Fish fish1 = new Fish("Poly");
            Fish fish2 = new Fish("Petra");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.RemoveFish("Poly");
            Assert.AreEqual(1, aquarium.Count);

        }
        
        [Test]
        public void RemoveFishIsNotCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 5);
            Assert.Throws<InvalidOperationException>(()=> aquarium.RemoveFish(null));

        }
        
        [Test]
        public void RemoveFishIsInCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 5);
            Fish fish1 = new Fish("Poly");
            aquarium.Add(fish1);
            Assert.Throws<InvalidOperationException>(()=> aquarium.RemoveFish("Koko"));
        }
        
        [Test]
        public void SellFishIsInCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 5);
            Fish fish1 = new Fish("Poly");
            aquarium.Add(fish1);
            Assert.Throws<InvalidOperationException>(()=> aquarium.SellFish("Koko"));
        }
        
        [Test]
        public void SellFishIsNotCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 5);
            Assert.Throws<InvalidOperationException>(()=> aquarium.SellFish(null));
        }
        
        [Test]
        public void SellFishIsCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 5);
            aquarium.Add(new Fish("Poly"));
            Fish fish = aquarium.SellFish("Poly");
            Assert.AreEqual(fish.Name, "Poly");
            Assert.AreEqual(fish.Available, false);
        }
        
        [Test]
        public void ReportIsCorrect()
        {
            Aquarium aquarium = new Aquarium("a", 5);
            Fish fish1 = new Fish("Poly");
            Fish fish2 = new Fish("Petra");
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.That(aquarium.Count, Is.EqualTo(2));
            Assert.That(fish1.Available == true);
            Assert.That(fish2.Available == true);
            Assert.That(aquarium.Report(), Is.EqualTo("Fish available at a: Poly, Petra"));
        }

    }
}
