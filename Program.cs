using System;
using System.Collections.Generic;

namespace TextAdventureProject
{
    class Program
    {
        static void Main(string[] args)
        {

            // Levels 
            int Level = 1;


            // Floor 1
            Random rnd = new Random();
            bool picklock = false;
            bool book = false;
            bool lighter = false;
            bool choselighter = false;
            bool choseflashlight = false;
            bool chosepicklock = false;
            bool lighterOn = false;
            bool flashlight = false;
            bool flashlightOn = false;
            bool rope = false;
            bool passcode = false;
            bool left = false, middle = false, right = false;


            // Floor 2
            Random diceRoll = new Random();
            string weapon = "";
            string secondary = "";
            int playerHP = 20;
            int enemyHP = 0;
            int food = 0;
            bool Level2_FightWon = false;

            // Floor 3
            bool lever1 = false;
            bool lever2 = false;
            bool lever3 = false;
            bool endLever = false;
            int enemy1HP = 15;
            int enemy2HP = 20;
            bool Level3_FightWon = false;

            // PUZZLE GAME ROOM
            // Floor 1 : Start
            Console.WriteLine("You wake up in a room alone and don't know what is going on around you. You look around to find a picklock.");
            while (chosepicklock == false)
            {
                    Console.WriteLine("Do you want to keep the picklock? (Y) Yes | (N) No");
                    string readline = Console.ReadLine();
                    if (readline.ToUpper() == "Y")
                    {
                        Console.WriteLine("You take the picklock and walk to the door at the end of the room.");
                        picklock = true;
                        flashlight = true;
                        chosepicklock = true;
                    }
                    else if (readline.ToUpper() == "N")
                    {
                        Console.WriteLine("You choose to leave the lockpick behind and walk to the door at the end of the room");
                        chosepicklock = true;
                    }
            }
            Console.WriteLine("You travel down the hall and approach a Large Door.");

            if (picklock)
            {
                int doorcode = rnd.Next(1, 10);
                bool guessed = false;
                Console.WriteLine("The door reads - In order to open the door you must pick the lock using the correct number below 10 and above 0.\n");
                while (guessed == false)
                {
                    int pickdoor = 0;
                    try
                    {
                        pickdoor = int.Parse(Console.ReadLine());
                    } catch (Exception)
                    {
                        Console.WriteLine("Invalid Input, Try Again.");
                    }
                    if (pickdoor == doorcode) {
                        guessed = true;
                        Console.WriteLine("You have unlocked the door. You continue through the door and take the flashlight on the shelf next to the door.\nYou enter a dark room.");
                    } else
                    {
                        Console.WriteLine("Wrong Code, Try Again.");
                    }
                }
            } else
            {
                book = true;
                lighter = true;
                Console.WriteLine("You forgot to bring your picklock. You look over to the side of the door and find a book. You open the book which reads -P4SSC0DE");
                Console.WriteLine("You close the book and see a hole in the wall. You enter a dark room and find a lighter on the way in.");
            }

            if (lighter)
            {
                choselighter = true;
                while(choselighter)
                {
                        Console.WriteLine("Do you want to use your Lighter? Y/N");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            lighterOn = true;
                            Console.WriteLine("You turn your lighter on and step further into the room.");
                            choselighter = false;
                        }
                        else if (Console.ReadLine().ToUpper() == "N")
                        {
                            lighterOn = false;
                            Console.WriteLine("You choose not to use the lighter and go futher into the room.");
                            choselighter = false;
                        } else
                    {
                        Console.WriteLine("Invalid Input, Try Again");
                    }
                }
            }
            if (flashlight)
            {
                choseflashlight = true;
                while(choseflashlight)
                {
                        Console.WriteLine("Do you want to use your Flashlight? Y/N");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            flashlightOn = true;
                            Console.WriteLine("You turn your flashlight on and step further into the room.");
                            choseflashlight = false;
                        }
                        else if (Console.ReadLine().ToUpper() == "N")
                        {
                            flashlightOn = false;
                            Console.WriteLine("You choose not to use the flashlight and go further into the room.");
                            choseflashlight = false;
                        } else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
            }

            if (lighterOn || flashlightOn)
            {
                while (!left || !middle || !right)
                {
                    try
                    {
                        Console.WriteLine("Which part of the room would you like to search? Left | Middle | Right");
                        string search = Console.ReadLine().ToLower();
                        if (search == "left")
                        {
                            rope = true;
                            left = true;
                            Console.WriteLine("You use your light to search the left part of the room. You find a rope to use.");
                        }
                        if (search == "middle")
                        {
                            middle = true;
                            Console.WriteLine("You use your light to search the middle part of the room. You find a balcony with a railing.");
                        }
                        if (search == "right")
                        {
                            right = true;
                            Console.WriteLine("You use your light to search the right part of the room. You find nothing.");
                        }
                        if (search != "left" && search != "middle" && search != "right")
                        {
                            Console.WriteLine("You did not select a part of the room to search.");
                        }
                    } catch (Exception)
                    {
                        Console.WriteLine("Invalid Input, Try Again");
                    }
                }
            }
            if (!lighterOn || !flashlightOn){
                while (!left || !middle || !right)
                {
                    try
                    {
                        Console.WriteLine("Which part of the room would you like to search? Left | Middle | Right");
                        string search = Console.ReadLine().ToLower();
                        if (search == "left")
                        {
                            left = true;
                            Console.WriteLine("You forgot your light but search the left part of the room anyway.");
                        }
                        if (search == "middle")
                        {
                            middle = true;
                            Console.WriteLine("You couldn't fully see where you were walking. You fall into a hole.");
                            if (lighter)
                            {
                                Console.WriteLine("You use your lighter and see a door in front of you.");
                                Console.WriteLine("The door reads -Input the P4SSC0DE to exit.");
                                while (!passcode)
                                {
                                    if (Console.ReadLine() == "P4SSC0DE")
                                    {
                                        Console.WriteLine("The P4SSC0DE you entered was correct. You make it to the other side of the door as it opens.");
                                        Console.WriteLine("You have made it through the tunnel without dying and enter into another room.");
                                        passcode = true;
                                        Level = 2;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You entered the wrong P4SSC0DE. Try Again.");
                                    }
                                }
                            }
                        }
                        if (search == "right")
                        {
                            right = true;
                            Console.WriteLine("You look around but don't see anything.");
                        }
                        if (search != "left" && search != "middle" && search != "right")
                        {
                            Console.WriteLine("You did not select a part of the room to search.");
                        }
                    } catch (Exception)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
            }
            if (left && middle && right) {
                if (lighterOn || flashlightOn) {
                    if (rope == true)
                    {
                        Console.WriteLine("You've searched every part of the room. You use the rope on the railing of the balcony and tie the rope in place.");
                        Console.WriteLine("You climb down the rope and enter into another room.");
                        Level = 2;
                    } else
                    {
                        Console.WriteLine("You forgot the rope and fell to your death over the railing.");
                    }
                }
            } else
            {
                Console.WriteLine(">>End Game [You did not reach Level 2.]");
                Console.ReadLine();
                System.Environment.Exit(1);
            }

            // FIGHT AN ENEMY
            // Floor 2 : Start
            if (Level == 2)
            {
                Console.WriteLine("\n\nYou have reached the second floor of the building, and escape.");
                Console.Write("You walk around and find yourself outside. You grab the axe next to you. ");
                Console.Write("You walk toward the trees and start swinging your axe to make a weapon. ");
                Console.Write("You chop down the tree and decide what weapon you would like to make. \n");
                Console.WriteLine("What weapon would you like to make?\n");
                Console.Write("[1] Sword and Shield [2] Bow and Arrow\n");
                bool weaponChosen = false;
                do
                {
                    if (Convert.ToInt32(Console.ReadLine()) == 1)
                    {
                        weapon = "Sword";
                        secondary = "Shield";
                        weaponChosen = true;
                    }
                    else if (Convert.ToInt32(Console.ReadLine()) == 2)
                    {
                        weapon = "Bow";
                        secondary = "Arrow";
                        weaponChosen = true;
                    }
                    else
                    {
                        Console.WriteLine("You didnt choose a weapon!");
                    }
                } while (weaponChosen == false);
                Console.WriteLine($"You chose the {weapon} for your weapon and continue walking forward down the path. ");
                Console.WriteLine("You find 5 Apples along the way to save for later. ");
                food = 5;
                Console.WriteLine("You see something up ahead, what looks like a person");
                Console.WriteLine("As you approach, the person tries to attack you, and you pull out your {0}", weapon);
                enemyHP = 10;
                Console.WriteLine("The person has begun to attack. What do you do?\n");
                do
                {
                    Console.WriteLine("[1] Attack [2] Eat Food\n");
                    if (Convert.ToInt32(Console.ReadLine()) == 1)
                    {
                        // player attack
                        int playerDMG = diceRoll.Next(1, 4);
                        enemyHP -= playerDMG;
                        Console.WriteLine($"You dealt {playerDMG} to the person, he has {enemyHP} health remaining. ");
                        if (enemyHP <= 0)
                        {
                            Console.WriteLine("You have slain the person. He is now dead. ");
                        } else
                        {
                            // enemy attack
                            int enemyDMG = diceRoll.Next(1, 4);
                            playerHP -= enemyDMG;
                            Console.WriteLine($"You took {enemyDMG} from the person, you have {playerHP} health. ");
                        }
                    }
                    else if (Convert.ToInt32(Console.ReadLine()) == 2)
                    {
                        if ((food - 1) > 0)
                        {
                            food--;
                            if ((playerHP + 5) > 20)
                            {
                                playerHP = 20;
                                Console.WriteLine("You have eatin an apple and gained 5 health. ");
                            }
                            else
                            {
                                playerHP += 5;
                                Console.WriteLine("You have eatin an apple and gained 5 health. ");
                            }
                        } else
                        {
                            Console.WriteLine("You have ran out of food!");
                        }

                        // enemy attack
                        int enemyDMG = diceRoll.Next(0, 4);
                        playerHP -= enemyDMG;
                        Console.WriteLine($"You took {enemyDMG} from the person, you have {playerHP} health. ");
                    }
                } while (playerHP > 0 && enemyHP > 0);
                if (playerHP > 0)
                {
                    Console.WriteLine("\nYou survived the attack and find a key from the person. You continue walking forward down the path. ");
                    Level2_FightWon = true;
                } else if (enemyHP > 0)
                {
                    Console.WriteLine("You have died from the persons attack. [GAME OVER]");
                    Console.ReadLine();
                    System.Environment.Exit(1);
                }

                Console.WriteLine("You make it to a house and use the key, but it does not appear to work. ");
                Level = 3;
                playerHP = 20;
            }

            // LEVERS THAT WILL DROP YOUR HP
            // Going into a wrong room? 
            // Floor 3 : Start
            if (Level == 3 && Level2_FightWon == true)
            {
                Console.WriteLine("You notice a switch on the door. It looks like the switch on the door still works. ");
                Console.WriteLine("You walk around the house and find 3 levers. They appear to be mechanisms for the door switch. ");
                Console.WriteLine("You walk up to the first lever and pull it. ");
                Console.WriteLine("Two people from the woods come out and attack you. ");
                Console.WriteLine($"You pull out your {weapon} and {secondary}");
                do
                {
                    Console.WriteLine("[1] Attack [2] Eat Food\n");
                    if (Convert.ToInt32(Console.ReadLine()) == 1)
                    {
                        // player attack
                        int playerDMG = diceRoll.Next(1, 4);
                        if (enemy1HP > 0)
                        {
                            enemy1HP -= playerDMG;
                            Console.WriteLine($"You dealt {playerDMG} to the first attacking woodsman, he has {enemy1HP} health remaining. ");
                            if (enemy1HP <= 0)
                            {
                                Console.WriteLine("You have slain the first woodsman. He has died. ");
                            }
                        } else if (enemy1HP <= 0 && enemy2HP > 0)
                        {
                            enemy2HP -= playerDMG;
                            Console.WriteLine($"You dealt {playerDMG} to the second attacking woodsman, he has {enemy2HP} health remaining. ");
                            if (enemy2HP <= 0)
                            {
                                Console.WriteLine("You have slain the second woodsman. He has now died. ");
                            }
                        }

                        // enemy attack 
                        // player block
                        if (enemy1HP > 0)
                        {
                            bool enemyRoll1 = false;
                            do
                            {
                                int enemyDMG1 = diceRoll.Next(1, 4);
                                if ((enemyDMG1 - 2) > 0)
                                {
                                    playerHP -= (enemyDMG1 - 2);
                                    Console.WriteLine($"You took {enemyDMG1} from the first person, but you blocked some damage. You have {playerHP} health left. ");
                                    enemyRoll1 = true;
                                }
                            } while (enemyRoll1 == false);
                        } else if (enemy1HP <= 0 && enemy2HP > 0)
                        {
                            bool enemyRoll2 = false;
                            do
                            {
                                int enemyDMG2 = diceRoll.Next(1, 5);
                                if ((enemyDMG2 - 2) > 0)
                                {
                                    playerHP -= enemyDMG2 - 2;
                                    Console.WriteLine($"You took {enemyDMG2} from the second person, but you blocked some damage. You have {playerHP} health left. ");
                                    enemyRoll2 = true;
                                }
                            } while (enemyRoll2 == false);
                        }
                    }
                    else if (Convert.ToInt32(Console.ReadLine()) == 2)
                    {
                        if ((food - 1) > 0)
                        {
                            food--;
                            if ((playerHP + 5) > 20)
                            {
                                playerHP = 20;
                                Console.WriteLine("You have eatin an apple and gained 5 health. ");
                            }
                            else
                            {
                                playerHP += 5;
                                Console.WriteLine("You have eatin an apple and gained 5 health. ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have ran out of food!");
                            Console.WriteLine("You choose to attack instead. ");
                            int playerDMG = diceRoll.Next(1, 4);
                            if (enemy1HP > 0)
                            {
                                enemy1HP -= playerDMG;
                                Console.WriteLine($"You dealt {playerDMG} to the first woodsman, he has {enemy1HP} health remaining. ");
                                if (enemy1HP <= 0)
                                {
                                    Console.WriteLine("You have slain the first woodsman. He has died. ");
                                }
                            }
                            else if (enemy1HP <= 0 && enemy2HP > 0)
                            {
                                enemy2HP -= playerDMG;
                                Console.WriteLine($"You dealt {playerDMG} to the second woodsman, he has {enemy2HP} health remaining. ");
                                if (enemy2HP <= 0)
                                {
                                    Console.WriteLine("You have slain the second woodsman. He has now died. ");
                                }
                            }
                        }

                        // enemy attacks
                        if (enemy1HP > 0)
                        {
                            bool enemyRoll1 = false;
                            do
                            {
                                int enemyDMG1 = diceRoll.Next(1, 4);
                                if ((enemyDMG1 - 2) > 0)
                                {
                                    playerHP -= enemyDMG1 - 2;
                                    Console.WriteLine($"You took {enemyDMG1} from the first person, but you blocked some damage. You have {playerHP} health left. ");
                                    enemyRoll1 = true;
                                }
                            } while (enemyRoll1 == false);
                        }
                        else if (enemy1HP <= 0 && enemy2HP > 0)
                        {
                            bool enemyRoll2 = false;
                            do
                            {
                                int enemyDMG2 = diceRoll.Next(1, 5);
                                if ((enemyDMG2 - 2) > 0)
                                {
                                    playerHP -= enemyDMG2 - 2;
                                    Console.WriteLine($"You took {enemyDMG2} from the second person, but you blocked some damage. You have {playerHP} health left. ");
                                    enemyRoll2 = true;
                                }
                            } while (enemyRoll2 == false);
                        }
                    }
                } while (playerHP > 0 && enemy2HP > 0);
                if (playerHP > 0)
                {
                    Console.WriteLine("You won the fight and continue to the next lever. ");
                    Level3_FightWon = true;
                } else
                {
                    Console.WriteLine("You have lost the fight. [GAME OVER]");
                    Console.ReadLine();
                    System.Environment.Exit(1);
                }
                if (Level3_FightWon == true)
                {
                    Console.WriteLine("You make it to the next lever and pull the lever. You take -3 Damage");
                    playerHP -= 3;
                    if (playerHP <= 0)
                    {
                        Console.WriteLine("You have died from the lever. [GAME OVER]");
                        Console.ReadLine();
                        System.Environment.Exit(1);
                    }
                }
                Console.WriteLine("You move to the final lever and see that it requires the key. ");
                Console.WriteLine("The key fits into the lever and the door opens from the house. ");
                Console.WriteLine("As you walk back to the door of the house, you can hear someone inside. ");
                Console.WriteLine("The door opens and you see your wife and kids. You decide to take a rest. The fight is over. ");
                Console.WriteLine("[GAME WON]");
                Console.ReadLine();
                System.Environment.Exit(1);
            }
        }
    }
}
