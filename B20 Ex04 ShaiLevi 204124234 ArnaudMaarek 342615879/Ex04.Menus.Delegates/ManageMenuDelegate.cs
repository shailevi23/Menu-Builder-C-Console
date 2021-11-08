using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class ManageMenuDelegate
    {
        public void RunMenu(MenuItem i_MainMenu)
        {
            MenuItem currentMenuItem, previousMenuItem;
            int userChoice;
            bool isMenu = true;
            currentMenuItem = i_MainMenu;
            previousMenuItem = currentMenuItem;

            while (isMenu)
            {
                try
                {
                    currentMenuItem.Show(currentMenuItem.SubMenu, currentMenuItem.Level, currentMenuItem.Title);
                    userChoice = currentMenuItem.ReadInput(currentMenuItem.SubMenu.Count);
                    if (!CheckCurrentMenuItemAction(userChoice, ref currentMenuItem, ref previousMenuItem))
                    {
                        isMenu = false;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("The input: " + fe.Message + " is not a number" + Environment.NewLine);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    Console.WriteLine("The input: " + aoore.ParamName + " is out of range" + Environment.NewLine);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        public bool CheckCurrentMenuItemAction(int i_UserChoice, ref MenuItem io_CurrentMenu, ref MenuItem io_PreviusMenu)
            {
                bool checkIsMenu = true;

                if (i_UserChoice == 0)
                {
                    if (io_CurrentMenu.Level != 1)
                    {
                        io_CurrentMenu = io_PreviusMenu;
                    }
                    else
                    {
                        io_CurrentMenu = io_CurrentMenu.SubMenu[0];
                        io_CurrentMenu.ItemFunctionWasClicked();
                        checkIsMenu = false;
                    }
                }
                else
                {
                    io_PreviusMenu = io_CurrentMenu;
                    io_CurrentMenu = io_CurrentMenu.SubMenu[i_UserChoice];
                    if (io_CurrentMenu.SubMenu.Count == 0)
                    {
                        io_CurrentMenu.ItemFunctionWasClicked();
                        checkIsMenu = false;
                    }
                }

                return checkIsMenu;
            }
    }
}