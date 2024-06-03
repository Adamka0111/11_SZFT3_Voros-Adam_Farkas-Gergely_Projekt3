using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMayhem_Lib
{
    public class Menu
    {
        public Menu()
        {
            MainMenu = new string[,] { { " ", "Játék kezdése" }, { " ", "Tutorial" }, { " ", "Irányítás" }, { " ", "Kilépés" } };
            ClassMenu = new string[,] { { " ", "Nehéz öklű" }, { " ", "Vas bőrű" }, { " ", "Gyors lábú" }, { " ", "Izompacsirta" }, { " ", "Erőberő" }, { " ", "Mitugrász" } };
            ShopMenu = new string[,] { { " ", "Súllyozott boxkesztyűk (ütés bónusz)" }, { " ", "Kar védők (blokk bónusz)" }, { " ", "Edző cipők (kitérés bónusz)" }, { " ", "Testépítő olaj (flex bónusz)" }, { " ", "Étrendkiegészítők (életerő bónusz)" }, { " ", "Energiaital (energia bónusz))" }, { " ", "Vissza" } };
            LevelUpMenu = new string[,] { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" }, { " ", "Élet" }, { " ", "Energia" } };
            CombatMenu = new string[,] { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" } };
            CombatTutorial = new string[,] { { " ", "Ütés (Sebzést okoz az ellenfélnek)" }, { " ", "Blokk (Sebzést blokkol az ellenféltől)" }, { " ", "Kitérés (Teljesen elkerül minden sebzést)" }, { " ", "Flex (Flexelés után erősebb az ütés)" } };
            MenuPoint = 0;
            MenuChoice = 0;
        }

        public string[,] MainMenu { get; set; }
        public string[,] ClassMenu { get; set; }
        public string[,] ShopMenu { get; set; }
        public string[,] LevelUpMenu { get; set; }
        public string[,] CombatMenu { get; set; }
        public string[,] CombatTutorial { get; set; }
        public int MenuPoint { get; set; }
        public int MenuChoice { get; set; }
    }
}
