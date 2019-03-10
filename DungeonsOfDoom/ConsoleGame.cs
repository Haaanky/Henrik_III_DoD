using FirstClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class ConsoleGame
    {
        public const int gameBoardX = 20;
        public const int gameBoardY = 5;

        Player player;
        World world; //gjorde om world till en klass med prop room[,] istället, för att lättare kunna återanvända world etc som instans
        //Random random = new Random();
        List<Archetype> archetypes = new List<Archetype>() { new Bard(), new FightingMan(), new MagicUser(), new Theif() }; //en lista med alla archetypes, kan nog göras lättare/mer DRY

        public void Play()
        {
            InitGame();
            CreatePlayer();
            CreateInventory();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayWorld();
                //DisplayStats();
                //DisplayInventory(); //skriver ut inventoryn
                AskForMovement();
                PlayerEnteredRoom(); //Kollar om det finns något i rummet och isf vad som ska hända
            } while (player.Health > 0 && Monster.NumberOfMonsters > 0);

            if (Monster.NumberOfMonsters == 0)
            {
                GameWin();
            }

            GameOver();
        }

        private void InitGame()
        {
            Console.Clear();
            Console.WindowHeight = 45;
            Console.WindowWidth = 180;
        }

        private void GameWin()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            TextUtils.AnimateText($"You are the chosen defender of the realm great champion..!\nThe kingdom is finally at peace from the scary monsters. \nLong live {player.Name} the queen!", 100);
            Console.ReadKey(true);
            Console.ResetColor();
        }

        private void CreatePlayer()
        {
            ChoosePlayerName();
            DisplayArchetypes();
            ChooseArchetype();
            player.Money = 100;
        }

        private void ChoosePlayerName()
        {
            Console.Write("Choose your name: ");
            player = new Player(Console.ReadLine());
        } // för att välja sitt namn

        private void CreateInventory()
        {
            player.CharacterInventory = new Inventory
            {
                ListOfItems = new List<IPackable>() { new Stick(1, 1, 2) }
            };
        } //Skapar en ny instans av inventory klassen som är en prop i alla character

        private void DisplayArchetypes()
        {
            Console.Clear();
            Console.WriteLine("Choose your class: \n");
            for (int i = 0; i < archetypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {archetypes[i].ArchtypeName}. Starting HP: {archetypes[i].BaseHealth}");
            }
        } // skriver ut vilka klasser som finns att välja

        private void ChooseArchetype()
        {
            bool menuLooop = false;

            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1: player.SetArchetype(new Bard()); break;
                    case ConsoleKey.D2: player.SetArchetype(new FightingMan()); break;
                    case ConsoleKey.D3: player.SetArchetype(new MagicUser()); break;
                    case ConsoleKey.D4: player.SetArchetype(new Theif()); break;
                    default: menuLooop = true; break;
                }
            } while (menuLooop);
            player.Health = player.ActiveArchetype.BaseHealth;
        } // switch-case för att välja sin klass

        private void CreateWorld()
        {
            //world = new Room[20, 5];
            Monster.NumberOfMonsters = 0;
            world = new World //skapar en ny instans av world och instansierar en ny karta med proppen Room array
            {
                Map = new Room[gameBoardX, gameBoardY]
            };

            for (int y = 0; y < world.Map.GetLength(1); y++)
            {
                for (int x = 0; x < world.Map.GetLength(0); x++)
                {
                    world.Map[x, y] = new Room(); //samma som innan fast via klassen instället för en variabel

                    if (!(player.X == x && player.Y == y)) //Se till att inget monster/item skapas i det rum som spelaren står i
                        if (RandomUtils.CheckPercentage(5))
                            world.Map[x, y].Monster = new WhiteWalker(50, "Larry");
                        else if (RandomUtils.CheckPercentage(5))
                            world.Map[x, y].Monster = new Skeleton(30, "Joe");
                        else if (RandomUtils.CheckPercentage(5))
                            world.Map[x, y].Item = new Sword("Sword", 1, 1, 5);
                        else if (RandomUtils.CheckPercentage(5))
                            world.Map[x, y].Item = new Apple(200, 0);
                        else if (RandomUtils.CheckPercentage(5))
                            world.Map[x, y].Item = new Chest("Mimic", 200, 5);
                }
            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.Map.GetLength(1); y++)
            {
                if (y == 0)
                {
                    Console.Write(" __");
                    for (int i = 0; i < world.Map.GetLength(0); i++)
                    {
                        Console.Write("_");
                    }
                    Console.Write($"__ Name: {player.Name}");
                    Console.WriteLine();
                }

                Console.Write(" | ");
                for (int x = 0; x < world.Map.GetLength(0); x++)
                {
                    Room room = world.Map[x, y];
                    if (player.X == x && player.Y == y)
                    {
                        //Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = player.ActiveArchetype.ColorToConsole;
                        Console.Write("P");
                        Console.ResetColor();
                    }
                    else if (room.Monster != null)
                        Console.Write("M");
                    else if (room.Item != null)
                        Console.Write("I");
                    else
                        Console.Write(".");
                }

                DisplayStats(y);
                Console.WriteLine();

                if (y == world.Map.GetLength(1) - 1)
                {
                    Console.OutputEncoding = Encoding.Unicode;
                    Console.Write(" \u203E\u203E");
                    for (int i = 0; i < world.Map.GetLength(0); i++)
                    {
                        Console.Write("\u203E");
                    }
                    Console.Write($"\u203E\u203E Number of monsters left: {Monster.NumberOfMonsters}");
                    Console.OutputEncoding = Encoding.Default;
                    Console.WriteLine();
                }

            }
        }

        private void DisplayStats(int y)
        {
            switch (y)
            {
                case 0: Console.Write($" | Class: {player.ActiveArchetype.ArchtypeName}"); break;
                case 1: Console.Write($" | Health: {player.Health}"); break;
                case 2:
                    Console.Write($" | Carrying Capacity Max: {player.MaxCarryingCapacity}kg | Current Inventory Weight: {player.CharacterInventory.Weight}kg | " +
                $"Remaining Carrying Capacity: {player.MaxCarryingCapacity - player.CharacterInventory.Weight}kg"); break;
                case 3: Console.Write($" | 1. Display Character Stats"); break;
                case 4: Console.Write($" | 2. Display Inventory"); break;
                default:
                    Console.Write(" | ");
                    break;
            }
        }

        private void DisplayInventory()  // skriver ut inventory
        {
            Console.WriteLine($"Inventory:{Environment.NewLine}");
            foreach (var item in player.CharacterInventory.ListOfItems)
            {
                Console.WriteLine(item);
            }

            TextUtils.PressAnyKey();
        }

        private void AskForMovement()
        {
            int newX = player.X;
            int newY = player.Y;
            bool isValidKey = true;

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.NumPad9: player.Health = 999; break;
                case ConsoleKey.D1: DisplayCharacterStats(); break;
                case ConsoleKey.D2: DisplayInventory(); break;
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidKey = false; break;
            }

            if (isValidKey &&
                newX >= 0 && newX < world.Map.GetLength(0) &&
                newY >= 0 && newY < world.Map.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;
                if (player.Name != "GodMode")
                    player.Health--; //minskar hälsan för varje steg
            }
        }

        private void DisplayCharacterStats()
        {
            Console.WriteLine($"Class: {player.ActiveArchetype.ArchtypeName}{Environment.NewLine}" +
                $"Strenght: {player.ActiveArchetype.Strength}{Environment.NewLine}" +
                $"Dexterity: {player.ActiveArchetype.Dexterity}{Environment.NewLine}" +
                $"Constitution: {player.ActiveArchetype.Constitution}{Environment.NewLine}" +
                $"Intelligence: {player.ActiveArchetype.Intelligence}{Environment.NewLine}" +
                $"Wisdom: {player.ActiveArchetype.Wisdom}{Environment.NewLine}" +
                $"Charisma: {player.ActiveArchetype.Charisma}{Environment.NewLine}");
            Console.ReadKey(true);
        }

        private void PlayerEnteredRoom() // kollar om det finns något i rummet och isf triggar event, lite underlig switch-case som är mer lik massa else/if, funkar bara med klasser/prop, mer DRY?
        {
            switch (world.Map[player.X, player.Y])
            {
                case Room val when val.Item is Item: PickupItem(val.Item); break;
                case Room val when val.Monster is Monster: MonsterEncounter(val.Monster); break;
                default:
                    break;
            }
        }

        private void PickupItem(IPackable item)
        {
            var tmpMap = world.Map[player.X, player.Y];
            if (item is IAttackable)
                MonsterEncounter((IAttackable)item);
            player.CharacterInventory.ListOfItems.Add(item);
            tmpMap.Item.ModifyPlayer(player);
            tmpMap.Item = null;
        }

        private void MonsterEncounter(IAttackable monster) // om man springer in i ett monster kommer den reagera beroende på vad som fanns i rummet, det som parametern frågar efter
        {
            var tmpMap = world.Map[player.X, player.Y];
            bool encounterResult = false;    // Temp set to true for now, need to check if win encounter or not

            if (monster is Skeleton)
                encounterResult = SkeletonEncounter(monster);
            else if (monster is WhiteWalker)
                encounterResult = WhiteWalkerEncounter(monster);
            else if (monster is Chest)
                encounterResult = ChestEncounter(monster);

            if (encounterResult) //tmp for now, needs to be updated later
            {
                Monster.NumberOfMonsters--;
                if (tmpMap.Monster is Monster)
                    player.CharacterInventory.ListOfItems.Add(tmpMap.Monster);
                tmpMap.Monster = null;
            }

            bool SkeletonEncounter(IAttackable monster1)
            {
                Console.WriteLine("\n\n\nWääh skelington");
                player.Attack(monster1);
                monster1.Attack(player);
                Console.ReadKey(true);

                if (monster1.Health <= 0)
                    encounterResult = true;

                return encounterResult;
            }

            bool WhiteWalkerEncounter(IAttackable monster2)
            {
                Console.WriteLine("\n\n\nSpooky white walker ... run!");
                player.Attack(monster2);
                monster2.Attack(player);
                Console.ReadKey(true);

                if (monster2.Health <= 0)
                    encounterResult = true;

                return encounterResult;
            }
        }

        private bool ChestEncounter(IAttackable monster)
        {
            var encounterResult = false;

            Console.WriteLine("\n\n\nIt's just a chest . . .");
            TextUtils.AnimateText($". . . . . . . . . .{Environment.NewLine}", 300);
            Console.ForegroundColor = ConsoleColor.Red;
            TextUtils.AnimateText($"or is it a Mimic?!", 200);
            player.Attack(monster);
            monster.Attack(player);
            Console.ResetColor();
            Console.ReadKey(true);

            if (monster.Health <= 0)
                encounterResult = true;

            return encounterResult;
        }

        private void GameOver() // störde mig på att det var ett oändligt spel bara
        {
            Console.Clear();
            Console.WriteLine("Game over...\n\nWould you like to play again?\nPress Y for yes! (any other and it will exit)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
                Play();

        }
    }
}
