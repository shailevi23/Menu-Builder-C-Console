using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
     public delegate void ItemWasClicked();

     public class MenuItem
     {
          protected List<MenuItem> m_Menus = new List<MenuItem>();
          protected string m_Title;
          protected int m_Level;
          private readonly string m_Enter = Environment.NewLine;

          public event ItemWasClicked MenuItemClickInvoker;

          public int Level
          {
               get { return m_Level; }
               set { m_Level = value; }
          }

          public string Title
          {
               get { return m_Title; }
               set { m_Title = value; }
          }

          public List<MenuItem> SubMenu
          {
               get { return m_Menus; }
               set { m_Menus = value; }
          }

          public void Show(List<MenuItem> i_MenuItems, int i_Level, string i_Title)
          {
               int counterItems = 0;
               Console.WriteLine(m_Enter + "Menu Level: " + i_Level + m_Enter + i_Title + m_Enter);
               Console.WriteLine("Please choose an option: ");

               foreach (MenuItem menuItem in i_MenuItems)
               {
                    Console.WriteLine(counterItems + ". " + menuItem.Title);
                    counterItems++;
               }
          }

          public int ReadInput(int i_Size)
          {
               int choiceInput;
               string input = Console.ReadLine();
               bool checkInput = int.TryParse(input, out choiceInput);
               if (!checkInput)
               {
                    throw new FormatException(input);
               }
               else
               {
                    if (choiceInput < 0 || choiceInput >= i_Size)
                    {
                        throw new ArgumentOutOfRangeException(choiceInput.ToString());
                    }
               }

               return choiceInput;
          }

          public void ItemFunctionWasClicked()
          {
               OnItemWasClicked();
          }

          protected virtual void OnItemWasClicked()
          {
               if (MenuItemClickInvoker != null)
               {
                    MenuItemClickInvoker.Invoke();
               }
          }
     }
}
