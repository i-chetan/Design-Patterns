using System;
using System.Net.Security;

namespace Exercise.CreationalPattern
{
    public interface IPrototype<T>
    {
        T Clone();
        T DeepClone();
    }

    public class Document : IPrototype<Document>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Tags { get; set; }
        public DocumentMetadata Metadata { get; set; }

        public Document(string title, string author)
        {
            Title = title;
            Author = author;
            CreatedDate = DateTime.Now;
            Tags = new();
            Metadata = new DocumentMetadata();
        }

        public Document Clone()
        {
            Console.WriteLine($"📄 Creating shallow clone of '{Title}'");
            return (Document)this.MemberwiseClone();
        }

        public Document DeepClone()
        {
            Console.WriteLine($"📄 Creating deep clone of '{Title}'");
            Document cloned = (Document)this.MemberwiseClone();

            cloned.Tags = new List<string>(this.Tags);
            cloned.Metadata = this.Metadata.DeepClone();

            return cloned;
        }

        public void Display()
        {
            Console.WriteLine($"\n📄 Document: {Title}");
            Console.WriteLine($"   Author: {Author}");
            Console.WriteLine($"   Created: {CreatedDate:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"   Content: {Content?.Substring(0, Math.Min(50, Content?.Length ?? 0))}...");
            Console.WriteLine($"   Tags: {string.Join(", ", Tags)}");
            Console.WriteLine($"   Metadata: Version {Metadata.Version}, Status: {Metadata.Status}");
        }
    }

    public class DocumentMetadata 
    {
        public int Version { get; set; }
        public string Status { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        public DocumentMetadata()
        {
            Version = 1;
            Status = "Draft";
            Properties = [];
        }

        public DocumentMetadata DeepClone()
        {
            DocumentMetadata cloned = new()
            {
                Version = this.Version,
                Status = this.Status,
                Properties = this.Properties
            };
            return cloned;
        }
    }

    public abstract class GameCharacter : IPrototype<GameCharacter>
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public List<string> Abilities { get; set; }
        public Equipment Equipment { get; set; }
        public CharacterStats Stats { get; set; }
        protected GameCharacter()
        {
            Abilities = new List<string>();
            Equipment = new Equipment();
            Stats = new CharacterStats();
        }

        public abstract GameCharacter Clone();
        public abstract GameCharacter DeepClone();
        public abstract void DisplayInfo();
        public abstract string GetCharacterType();
    }

    public class Warrior : GameCharacter
    {
        public int Strength { get; set; }
        public int Armor { get; set; }

        public Warrior(string name)
        {
            Name = name;
            Level = 1;
            Health = 150;
            Mana = 50;
            Strength = 20;
            Armor = 15;
            Abilities.Add("Power Strike");
            Abilities.Add("Shield Block");
        }

        public override GameCharacter Clone()
        {
            Console.WriteLine($"⚔️  Creating shallow clone of Warrior '{Name}'");
            return (Warrior)this.MemberwiseClone();
        }

        public override GameCharacter DeepClone()
        {
            Console.WriteLine($"⚔️  Creating deep clone of Warrior '{Name}'");
            Warrior cloned = (Warrior)this.MemberwiseClone();

            cloned.Abilities = new List<string>(this.Abilities);
            cloned.Equipment = this.Equipment.DeepClone();
            cloned.Stats = this.Stats.DeepClone();
            return cloned;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"\n⚔️  Warrior: {Name}");
            Console.WriteLine($"  Level: {Level} | HP: {Health} | Mana: {Mana}");
            Console.WriteLine($"  Strength: {Strength}  | Armor: {Armor}");
            Console.WriteLine($"  Abilities: {string.Join(", ", Abilities)}");
            Console.WriteLine($"  Equipment: {Equipment.ToString()}");
            Console.WriteLine($"  Stats: {Stats.ToString()}");
        }

        public override string GetCharacterType() => "Warrior";
    }

    public class Mage : GameCharacter
    {
        public int Intelligence { get; set; }
        public int MagicPower { get; set; }

        public Mage(string name)
        {
            Name = name;
            Level = 1;
            Health = 80;
            Mana = 150;
            Intelligence = 25;
            MagicPower = 30;
            Abilities.Add("Fireball");
            Abilities.Add("Ice sheild");
            Abilities.Add("Teleport");
        }

        public override GameCharacter Clone()
        {
            Console.WriteLine($"🧙  Creating shallow clone of Mage '{Name}'");
            return (Mage)this.MemberwiseClone();
        }

        public override GameCharacter DeepClone()
        {
            Console.WriteLine($"🧙  Creating deep clone of Mage '{Name}'");
            Mage cloned = (Mage)this.MemberwiseClone();
            cloned.Abilities = new List<string>(this.Abilities);
            cloned.Equipment = this.Equipment.DeepClone();
            cloned.Stats = this.Stats.DeepClone();
            return cloned;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"\n🧙 Mage: {Name}");
            Console.WriteLine($"  Level: {Level} | HP: {Health} | Mana: {Mana}");
            Console.WriteLine($"  Intelligence: {Intelligence} | Magic Power: {MagicPower}");
            Console.WriteLine($"  Abilities: {string.Join(", ", Abilities)}");
            Console.WriteLine($"  Equipment: {Equipment.ToString()}");
            Console.WriteLine($"  Stats: {Stats.ToString()}");
        }

        public override string GetCharacterType() => "Mage";
    }

    public class Rogue : GameCharacter
    {
        public int Agility { get; set; }
        public int CriticalChance { get; set; }

        public Rogue(string name)
        {
            Name = name;
            Level = 1;
            Health = 100;
            Mana = 75;
            Agility = 30;
            CriticalChance = 25;
            Abilities.Add("Backstab");
            Abilities.Add("Stealth");
            Abilities.Add("Poison Dagger");
        }

        public override GameCharacter Clone()
        {
            Console.WriteLine($"🗡️  Creating shallow clone of Rogue '{Name}'");
            return (Rogue)this.MemberwiseClone();
        }

        public override GameCharacter DeepClone()
        {
            Console.WriteLine($"🗡️  Creating deep clone of Rogue '{Name}'");
            Rogue cloned = (Rogue)this.MemberwiseClone();
            cloned.Abilities = new List<string>(this.Abilities);
            cloned.Equipment = this.Equipment.DeepClone();
            cloned.Stats = this.Stats.DeepClone();
            return cloned;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"\n🗡️  Rogue: {Name}");
            Console.WriteLine($"  Level: {Level} | HP: {Health} | Mana: {Mana}");
            Console.WriteLine($"  Agility: {Agility} | Critical Chance: {CriticalChance}%");
            Console.WriteLine($"  Abilities: {string.Join(", ", Abilities)}");
            Console.WriteLine($"  Equipment: {Equipment.ToString()}");
            Console.WriteLine($"  Stats: {Stats.ToString()}");
        }

        public override string GetCharacterType() => "Rogue";
    }

    public class Equipment
    {
        public string Weapon { get; set; }
        public string Armor { get; set; }
        public string Accessory { get; set; }

        public Equipment()
        {
            Weapon = "Basic Weapon";
            Armor = "Basic Armor";
            Accessory = "None";
        }

        public Equipment DeepClone()
        {
            return new Equipment
            {
                Weapon = this.Weapon,
                Armor = this.Armor,
                Accessory = this.Accessory
            };
        }

        public override string ToString()
        {
            return $"Weapon: {Weapon}, Armor: {Armor}, Accessory: {Accessory}";
        }
    }

    public class CharacterStats
    {
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public CharacterStats DeepClone()
        {
            return new CharacterStats
            {
                GamesPlayed = this.GamesPlayed,
                Wins = this.Wins,
                Losses = this.Losses
            };
        }

        public override string ToString()
        {
            return $"Games: {GamesPlayed}, W/L: {Wins}/{Losses}";
        }
    }

    public class CharacterRegistry
    {
        public Dictionary<string, GameCharacter> _prototypes;
        public CharacterRegistry()
        {
            _prototypes = new Dictionary<string, GameCharacter>();
            InitializePrototypes();
        }

        private void InitializePrototypes()
        {
            Warrior basicWarrior = new Warrior("Template Warrior");
            basicWarrior.Equipment.Weapon = "Iron Sword";
            basicWarrior.Equipment.Armor = "Chain Mail";
            _prototypes.Add("BaicWarrior", basicWarrior);

            Mage basicMage = new Mage("Template Mage");
            basicMage.Equipment.Weapon = "Wooden Staff";
            basicMage.Equipment.Armor = "Cloth Robe";
            _prototypes.Add("BasicMage", basicMage);

            Rogue basicRogue = new Rogue("Template Rogue");
            basicRogue.Equipment.Weapon = "Dagger";
            basicRogue.Equipment.Armor = "Leather Armor";
            _prototypes.Add("BasicRogue", basicRogue);

            Warrior eliteWarrior = new Warrior("Elite Warrior");
            eliteWarrior.Level = 10;
            eliteWarrior.Health = 300;
            eliteWarrior.Strength = 50;
            eliteWarrior.Armor = 40;
            eliteWarrior.Equipment.Weapon = "Legendary Sword";
            eliteWarrior.Equipment.Armor = "Plate Armor";
            eliteWarrior.Abilities.Add("Whirlwind");
            eliteWarrior.Abilities.Add("Battle Cry");
            _prototypes.Add("EliteWarrior", eliteWarrior);

            Console.WriteLine("✅ Character prototypes initialized");
        }

        public GameCharacter CreateCharacter(string type, string name)
        {
            if(_prototypes.ContainsKey(type))
            {
                GameCharacter prototype = _prototypes[type];
                GameCharacter clone = prototype.DeepClone();
                clone.Name = name;
                return clone;
            }

            Console.WriteLine($"❌ Prototype '{type}' not found");
            return null!;
        }

        public void ListPrototypes()
        {
            Console.WriteLine("\n📋  Available Prototypes:");
            foreach(var prototype in _prototypes)
            {
                Console.WriteLine($"   - {prototype.Key}: {prototype.Value.GetCharacterType()} (Level {prototype.Value.Level})");
            }
        }
    }

    public class PrototypePatternDemo()
    {
        public static void Run()
        {
            Console.WriteLine("=== Prototype Pattern Demo ===\n");

            Console.WriteLine("--- Document Cloning ---\n");

            Document original = new Document("Project Proposal", "John Doe");
            original.Content = "This is a comprehesive project proposal for the new system...";
            original.Tags.Add("proposal");
            original.Tags.Add("2024");
            original.Tags.Add("important");
            original.Metadata.Status = "In Review";
            original.Metadata.Properties.Add("Department", "Engineering");

            Console.WriteLine("Original Document:");
            original.Display();

            Console.WriteLine("\n--- Shallow Clone Test ---");
            Document shallowClone = original.Clone();
            shallowClone.Title = "Cloned Proposal (Shallow)";
            shallowClone.Tags.Add("clone");

            Console.WriteLine("\nAfter modifying shallow clone:");
            Console.WriteLine("Original tags: " + string.Join(", ", original.Tags));
            Console.WriteLine("Shallow clone tags: " + string.Join(", ", shallowClone.Tags));
            Console.WriteLine("⚠️  Notice: Tags list is shared!");

            Console.WriteLine("\n\n--- Deep clone test ---");
            Document deepClone = original.DeepClone();
            deepClone.Title = "Cloned Proposal (deep)";
            deepClone.Tags.Add("independent");
            deepClone.Metadata.Status = "Approved";

            Console.WriteLine("\nAfter modifying deep clone:");
            original.Display();
            deepClone.Display();
            Console.WriteLine("✅  Tags and metadata are independent");

            Console.WriteLine("\n\n--- Game Character Cloning ---\n");

            CharacterRegistry registry = new CharacterRegistry();
            registry.ListPrototypes();

            Console.WriteLine("\n--- Creating Characters from Prototypes ---");

            GameCharacter player1 = registry.CreateCharacter("BasicWarrior", "Aragon");
            GameCharacter player2 = registry.CreateCharacter("BasicMage", "Gandalf");
            GameCharacter player3 = registry.CreateCharacter("BasicRogue", "Legolas");
            GameCharacter player4 = registry.CreateCharacter("EliteWarrior", "Conan");

            player1?.DisplayInfo();
            player2?.DisplayInfo();
            player3?.DisplayInfo();
            player4?.DisplayInfo();

            Console.WriteLine("\n\n--- Modifying Cloned Character ---");

            if (player1 != null)
            {
                player1.Level = 5;
                player1.Health = 200;
                player1.Abilities.Add("Heroic Strike");
                player1.Equipment.Weapon = "Excalibur";
                player1.Stats.GamesPlayed = 10;
                player1.Stats.Wins = 7;
                
                Console.WriteLine("\nModified Character:");
                player1.DisplayInfo();

                GameCharacter player5 = registry.CreateCharacter("BasicWarrior", "Borimir");
                Console.WriteLine("\nNew Character from Same Prototype:");
                player5?.DisplayInfo();
                Console.WriteLine("✅ Modifications don't affect prototype!");
            }

            Console.WriteLine("\n\n--- Performance Comparision");
            CompareCreationPerformance();
        }

        public static void CompareCreationPerformance()
        {
            const int iterations = 10000;

            Warrior prototypeWarrior = new Warrior("Template");
            prototypeWarrior.Equipment.Weapon = "Legendary Sword";
            prototypeWarrior.Abilities.Add("Extra Abilities 1");
            prototypeWarrior.Abilities.Add("Extra Abilities 2");

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                var clone = prototypeWarrior.DeepClone();
            }
            stopwatch.Stop();

            long cloneTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                var newWarrior = new Warrior("New Warrior");
                newWarrior.Equipment.Weapon = "Legendary Sword";
                newWarrior.Abilities.Add("Extra Abilities 1");
                newWarrior.Abilities.Add("Extra Abilities 2");
            }
            stopwatch.Stop();

            long constructionTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Creating {iterations} characters:");
            Console.WriteLine($"  Prototype cloning: {cloneTime}ms");
            Console.WriteLine($"  Regular construction: {constructionTime}ms");
            Console.WriteLine($"  Speedup: {(double)constructionTime / cloneTime:F2}x faster");
        }
    }
}
