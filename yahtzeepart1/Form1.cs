#region using statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace yahtzeepart1
{
    public partial class Form1 : Form
    {


        Image[] diceimages;
        int[] dice;
        Random rand;




        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //the images of the dice's
            diceimages = new Image[7];
            diceimages[0] = Properties.Resources._120px_Dice_0;
            diceimages[1] = Properties.Resources.Alea_1;
            diceimages[2] = Properties.Resources.Alea_2;
            diceimages[3] = Properties.Resources.Alea_3;
            diceimages[4] = Properties.Resources.Alea_4;
            diceimages[5] = Properties.Resources.Alea_5;
            diceimages[6] = Properties.Resources.Alea_6;

            dice = new int[5] { 0, 0, 0, 0, 0, };

            rand = new Random();


        }

        //how many times the dice has been rolled
        public int aantaly = 0;
        public int aantal3 = 0;
        public int aantal4 = 0;
        public int aantalg = 0;
        public int aantalk = 0;
        public int aantalf = 0;
        public int aantalc = 0;
        //how many points you have scored
        public int pointsy = 0;
        public int points3 = 0;
        public int points4 = 0;
        public int pointsg = 0;
        public int pointsk = 0;
        public int pointsf = 0;
        public int pointsc = 0;

        private bool yahtzeeFound = false;
        public void dobbelen_Click(object sender, EventArgs e)
        {
            while (yahtzeeFound == false)
            {


                Rolldice();


                int dobbel1 = (dice[0]);
                int dobbel2 = (dice[1]);
                int dobbel3 = (dice[2]);
                int dobbel4 = (dice[3]);
                int dobbel5 = (dice[4]);
                int score = dobbel1 + dobbel2 + dobbel3 + dobbel4 + dobbel5;
                textBox1.Text = Convert.ToString(score);

                //sorts dice 
                Array.Sort(dice);

                //cant get the text to prioritise Yahtzee as an output.
                //calculates yahtzee
                if (dobbel1 == dobbel2 && dobbel2 == dobbel3 && dobbel3 == dobbel4 && dobbel4 == dobbel5)
                {
                    aantaly = aantaly + 1;
                    yAmount.Text = Convert.ToString(aantaly);
                    pointsy = pointsy + 50;
                    puntenY.Text = Convert.ToString(pointsy);
                    yahtzeeFound = true;
                    bonusTextbox.Text = "yahtzee";
                }
                //calculates fullhouse
                bool FullHouse = (dice.Distinct().Count() == 2) &&
                                dice.GroupBy(x => x).Any(g => g.Count() == 2);
                if (FullHouse == true)
                {
                    bonusTextbox.Text = "fullhouse!";
                    aantalf = aantalf + 1;
                    FullHouseAmount.Text = Convert.ToString(aantalf);
                    pointsf = pointsf + 25;
                    PuntenF.Text = Convert.ToString(pointsf);
                }
                //calculates large street 
                if (dice[0] == 1 && dice[1] == 2 && dice[2] == 3 && dice[3] == 4 && dice[4] == 5 || dice[0] == 2 && dice[1] == 3 && dice[2] == 4 && dice[3] == 5 && dice[4] == 6)
                {
                    bonusTextbox.Text = "grote straat";
                    aantalg = aantalg + 1;
                    grotestraatAmount.Text = Convert.ToString(aantalg);
                    pointsg = pointsg + 40;
                    puntenG.Text = Convert.ToString(pointsg);
                }
                //calculates small street
                if (dice[0] == 1 && dice[1] == 2 && dice[2] == 3 && dice[3] == 4 || dice[0] == 2 && dice[1] == 3 && dice[2] == 4 && dice[3] == 5
                    || dice[0] == 3 && dice[1] == 4 && dice[2] == 5 && dice[3] == 6 || dice[1] == 1 && dice[2] == 2 && dice[3] == 3 && dice[4] == 4
                    || dice[1] == 2 && dice[2] == 3 && dice[3] == 4 && dice[4] == 5 || dice[1] == 3 && dice[2] == 4 && dice[3] == 5 && dice[4] == 6)
                {
                    bonusTextbox.Text = "kleine straat";
                    aantalk = aantalk + 1;
                    kleinestraatAmount.Text = Convert.ToString(aantalk);
                    pointsk = pointsk + 30;
                    puntenK.Text = Convert.ToString(pointsk);
                }
                //calculates 3 of a kind 
                if (dobbel1 == dobbel2 && dobbel2 == dobbel3 || dobbel3 == dobbel4 && dobbel4 == dobbel5)
                {
                    bonusTextbox.Text = "3 gelijke";
                    aantal3 = aantal3 + 1;
                    gelijke3Amount.Text = Convert.ToString(aantal3);
                    points3 += dobbel1 + dobbel2 + dobbel3 + dobbel4 + dobbel5;
                    punten3.Text = Convert.ToString(points3);
                }
                //calculates 4 of a kind/carré 
                if (dobbel1 == dobbel2 && dobbel2 == dobbel3 && dobbel3 == dobbel4 || dobbel2 == dobbel3 && dobbel3 == dobbel4 && dobbel4 == dobbel5)
                {
                    bonusTextbox.Text = "4 gelijke";
                    aantal4 = aantal4 + 1;
                    gelijke4amount.Text = Convert.ToString(aantal4);
                    points4 += dobbel1 + dobbel2 + dobbel3 + dobbel4 + dobbel5;
                    punten4.Text = Convert.ToString(points4);
                }
                for (int i = 0; i < 5; i++)
                {
                    bonusTextbox.Text = "chance";
                    aantalc = aantalc + 1;
                    chanceAmount.Text = Convert.ToString(aantalc);
                    pointsc += dobbel1 + dobbel2 + dobbel3 + dobbel4 + dobbel5;
                    puntenC.Text = Convert.ToString(pointsc);
                }


                //calculates how many times 3 of a kind / 4 of a kind etc. Is thrown
                int amount = aantal3 + aantal4 + aantaly + aantalk + aantalg + aantalf + aantalc;
                totalAmount.Text = Convert.ToString(amount);
                //calculates total amount of the points 
                int points = points3 + points4 + pointsy + pointsk + pointsg + pointsf + pointsc; 
                TotalScore.Text = Convert.ToString(points);
            }
        }


      
          

        //changes the images
        private void Rolldice()
        {
            for (int i = 0; i < dice.Length; i++)
                dice[i] = rand.Next(1, 7);

            
            pictureBox1.Image = diceimages[dice[0]];
            pictureBox2.Image = diceimages[dice[1]];
            pictureBox3.Image = diceimages[dice[2]];
            pictureBox4.Image = diceimages[dice[3]];
            pictureBox5.Image = diceimages[dice[4]];
        }



        //the rule button 
        private void spelregels_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Spelregels Yahtzee \nHoe werkt het? \nHet spel Yahtzee is een dobbelspel dat gespeeld wordt met 5 dobbelstenen en een scoreblok. Elke speler mag per beurt maximaal 3 x met de dobbelstenen gooien en proberen een zo hoog mogelijke score te behalen die hij kan opschrijven bij een van de combinaties op het scoreblok. Je bent verplicht om na elke beurt een vakje in te kruisen. \n                                                                                                                         Scores:\nBovenste vakken Bij de vakken 1 t / m 6 is het aantal punten gelijk aan het aantal keer dat een dobbelsteen het overeenkomstige aantal ogen aanwijst, vermenigvuldigd met het aantal ogen.\nOnderste vakken:\nDrie gelijke: De score is het totaal van alle ogen, als er minstens 3 dobbelstenen met hetzelfde aantal ogen zijn.\nVier gelijke: De score is het totaal van alle ogen, als er minstens 4 dobbelstenen met hetzelfde aantal ogen zijn.\nleine straat: 30 punten voor 4 oplopende dobbelstenen. (de volgorde speelt geen rol)\nGrote straat: 40 punten voor 5 oplopende dobbelstenen. (de volgorde speelt geen rol)\nFull House: 25 punten voor 3 gelijke en één paar. (5 gelijke telt niet als Full House, tenzij het vak Yahtzee reeds ingevuld is).\nKans: De score is het totaal aantal ogen van alle dobbelstenen.\nYahtzee: 50 punten als alle dobbelstenen hetzelfde aantal ogen hebben.");
        }

        
    }
}