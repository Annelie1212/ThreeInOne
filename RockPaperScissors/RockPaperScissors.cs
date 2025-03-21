using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ThreeInOne;
using ThreeInOne.Data;
using ThreeInOne.DatabaseServices;

using FluentValidation.Results;
using System.Globalization;
using Microsoft.Extensions.Options;

namespace RockPaperScissors
{
    internal class RockPaperScissors
    {

        public int UserValue1 { get; set; }

        public int ComputerValue1 { get; set; }
        public int UserValue2 { get; set; }
        public int ComputerValue2 { get; set; }
        public int UserValue3 { get; set; }
        public int ComputerValue3 { get; set; }

        //TODO LOOK HERE
        public int computerPoints { get; set; }
        //TODO LOOK HERE STATIC??
        public int playerPoints { get; set; }

        public DateTime CurrentDateTime { get; set; }

        //Move order in array:
        //{player,computer,player2,computer2,player3,computer3}
        //public int[] PlayerComputerMoves { get; set; } = new int[6];
        //Dictionary som innehåller <runda,utfall>
        //utfallslista = { win, loss, tie}

        
        //sten or sax or påse
        public string[] PlayerMoves = new string[3];
        public string[] ComputerMoves = new string[3];

        
        //public Dictionary<int, List<int>> PlayerComputerRoundResults { get; set; } = new Dictionary<int, List<int>>
        //{     
        //    {0, new List<int>{0,0,0 } },
        //    {1 , new List<int>{0,0,0 }},
        //    {2 , new List<int>{0,0,0 }}
        //};

        //win or loss or tie
        public string[] RoundResults = new string[3];


        public int Win { get; set; }
        public int Loss { get; set; }
        public int Tie { get; set; }
        public RockPaperScissors()
        {
            DateTime rawDateTime = DateTime.Now;
            string stringDateTime = rawDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string format = "yyyy-MM-dd HH:mm:ss";
            this.CurrentDateTime = DateTime.ParseExact(stringDateTime, format, CultureInfo.InvariantCulture);
        }

        public string Winner(string userValue, string computerValue) 
        {
            if (userValue == computerValue)
            {
                computerPoints += 0;
                playerPoints += 0;
                return "Ställningen blev lika";
            }   
            else if ( userValue == "sten" && computerValue == "sax")
            {
                computerPoints += 0;
                playerPoints += 1;
                return "Spelaren vann!";
            }
            else if (userValue == "sax" && computerValue == "påse")
            {
                computerPoints += 0;
                playerPoints += 1;
                return "Spelaren vann!";
            }
            else if (userValue == "påse" && computerValue == "sten")
            {
                computerPoints += 0;
                playerPoints += 1;
                return "Spelaren vann!";
            }
            else
            {
                computerPoints += 1;
                playerPoints += 0;
                return "Datorn vann";
            }            
        }

        public void ShowResults()
        {
            Console.WriteLine("SLUTRESULTAT");

            Console.WriteLine($"Spelaren vann{playerPoints} gånger.");
            Console.WriteLine($"Datorn vann{computerPoints} gånger.");

            if (computerPoints > playerPoints)
            {
                this.Win = 0;
                this.Loss = 1;
                this.Tie = 0;

                Console.Write("Datorn vann!");
            }
            else if (computerPoints < playerPoints)
            {
                this.Win = 1;
                this.Loss = 0;
                this.Tie = 0;

                Console.Write("Spelaren vann!");
                              
            }
            else 
            {
                this.Win = 0;
                this.Loss = 0;
                this.Tie = 1;

                Console.Write("Det blev lika!");
            }
            Console.WriteLine();
            Console.WriteLine();
            
        }

        public void PlayMatch()
        {
            Dictionary<int, string> move = new Dictionary<int, string>();
            move[1] = "sten";
            move[2] = "sax";
            move[3] = "påse";

            //Console.WriteLine("Sten Sax Påse");
            //Console.WriteLine("Välj ditt drag ur menyn\n");
            //Console.WriteLine("1 Sten");
            //Console.WriteLine("2 Sax");
            //Console.WriteLine("3 Påse\n");

            Menu rockPaperScissorsMenu = new Menu();
            rockPaperScissorsMenu.AppName = "Sten Sax Påse" + "\n";
            rockPaperScissorsMenu.NrChoices = new List<string> { "1", "2", "3" };
            rockPaperScissorsMenu.TextChoices = new List<string> {
                    "Sten",
                    "Sax",
                    "Påse"
                };
            rockPaperScissorsMenu.Display();

            Random random = new Random();

            for (int roundNr = 0; roundNr < 3; roundNr++)
            {
                bool playRoundBool = PlayRound(move, random,roundNr);
                if (playRoundBool == false)
                {
                    //Rundan backar en runda om spelaren matar in fel.
                    roundNr--;
                }
            }

            #region all rounds
            //Console.Write("Ange ditt första drag: " + "\n");
            //int value1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("spelarens drag: "+move[value1]+"\n");

            //int randomNumber1 = random.Next(1, 4);
            //Console.WriteLine("Datorns drag: "+move[randomNumber1]+"\n");
            //Console.WriteLine(RockPaperScissors.Winner(move[value1],move[randomNumber1]));


            //Console.Write("Ange ditt andra drag: ");
            //int value2 = int.Parse(Console.ReadLine());
            //Console.WriteLine("spelarens drag: " + move[value2]+"\n");

            //int randomNumber2 = random.Next(1, 4);
            //Console.WriteLine("Datorns drag: "+move[randomNumber2]+"\n");
            //Console.WriteLine(RockPaperScissors.Winner(move[value2], move[randomNumber2]));

            //Console.Write("Ange ditt tredje drag: ");
            //int value3 = int.Parse(Console.ReadLine());
            //Console.WriteLine("spelarens drag: " + move[value3]+"\n");

            //int randomNumber3 = random.Next(1, 4);
            //Console.WriteLine("Datorns drag: "+move[randomNumber3]+"\n");
            //Console.WriteLine(RockPaperScissors.Winner(move[value3], move[randomNumber3]));
            #endregion

            this.ShowResults();



            //DATABASE
            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                //READ
                List<double> wins = new List<double>();
                double average = 0;
                foreach (var matchData in dbContext.RockPaperScissorsMatchData)
                {
                    //Console.WriteLine(matchData.Win);
                    wins.Add(matchData.Win);
                }
                wins.Add(this.Win);

                //CREATE
                dbContext.RockPaperScissorsMatchData.Add(new RockPaperScissorsMatchData
                {
                    DateTime = this.CurrentDateTime,
                    Win = this.Win,
                    Loss = this.Loss,
                    Tie = this.Tie,
                    AverageWin = wins.Average()
                });
                dbContext.SaveChanges();

                //READs last row from matchdata.
                //Från stack overflow
                int currentMatchId = int.Parse(dbContext.RockPaperScissorsMatchData
                                            .OrderByDescending(match => match.MatchId)
                                            .Select(match => match.MatchId)
                                            .First().ToString());

                //CREATE ROUND
                for (int i = 0; i < 3; i++)
                {
                    int tempWin = 0;
                    int tempLoss = 0;
                    int tempTie = 0;
                    if (this.RoundResults[i]=="win")
                    {
                        tempWin = 1;
                        tempLoss = 0;
                        tempTie = 0;
                    }else if(this.RoundResults[i] == "loss")
                    {
                        tempWin = 0;
                        tempLoss = 1;
                        tempTie = 0;
                    }else if(this.RoundResults[i] == "tie")
                    {
                        tempWin = 0;
                        tempLoss = 0;
                        tempTie = 1;
                    }

                    dbContext.RockPaperScissorsRoundData.Add(new RockPaperScissorsRoundData
                    {
                        MatchId = currentMatchId,
                        DateTime = this.CurrentDateTime,
                        Win = tempWin,
                        Loss = tempLoss,
                        Tie = tempTie,
                        PlayerMove = this.PlayerMoves[i],
                        ComputerMove = this.ComputerMoves[i]
                    });
                    dbContext.SaveChanges();
                }

            }
        }

        //move är en dictionary som översätter talen 1,2,3 till sten sax påse.
        public bool PlayRound(Dictionary<int, string> move, Random random,int roundNr)
        {
            Console.WriteLine();
            Console.Write("Ange ditt drag: ");
            string value1 = Console.ReadLine();


            RockPaperScissorsModel rockPaperScissorsModel = new RockPaperScissorsModel(value1);
            RockPaperScissorsValidator rockPaperScissorsValidator = new RockPaperScissorsValidator();
            ValidationResult validationResults = rockPaperScissorsValidator.Validate(rockPaperScissorsModel);
            bool isInputValid = ErrorMessageDiplay(validationResults);

            if (isInputValid)
            {
                int valueInt = int.Parse(value1);


                Console.WriteLine("Spelarens drag: " + move[valueInt]);

                int randomNumber1 = random.Next(1, 4);
                Console.WriteLine("Datorns drag: " + move[randomNumber1]);

                string roundResult = Winner(move[valueInt], move[randomNumber1]);
                //continue
                //PlayerComputerRoundResults (win,loss,tie)
                if (roundResult == "Spelaren vann!") { 
                    RoundResults[roundNr] = "win"; }
                else if (roundResult == "Datorn vann") { 
                    RoundResults[roundNr] = "loss"; }
                else if (roundResult == "Ställningen blev lika") { 
                    RoundResults[roundNr] = "tie"; }
                
                Console.WriteLine(roundResult);



                this.PlayerMoves[roundNr] = move[valueInt];
                this.ComputerMoves[roundNr] = move[randomNumber1];
                Console.WriteLine();

                return true;
            }

            return false;


        }
        public void ShowTotalResults()
        {
            using (ThreeInOneAppDbContext dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                foreach (var matchData in dbContext.RockPaperScissorsMatchData)
                {
                    Console.WriteLine($"DateTime: {matchData.DateTime}");
                    Console.WriteLine($"Namn: {"Annelie"/*.Name*/}");
                    Console.WriteLine($"MatchId: {matchData.MatchId}");
                    Console.WriteLine($"Win: {matchData.Win}");
                    Console.WriteLine("====================");
                }
            }
        }

        public void ShowTotalRounds()
        {
            using (ThreeInOneAppDbContext dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                int rowNr = 0;
                foreach (var roundData in dbContext.RockPaperScissorsRoundData)
                {
                    Console.WriteLine($"DateTime: {roundData.DateTime}");
                    Console.WriteLine($"Namn: {"Annelie"/*.Name*/}");
                    Console.WriteLine($"MatchId: {roundData.MatchId}");
                    Console.WriteLine($"Win: {roundData.Win}");
                    rowNr++;
                    if (rowNr%3 ==0)
                    {
                        Console.WriteLine("====================");

                    }
                    
                    
                }
            }
        }
        public static bool ErrorMessageDiplay(ValidationResult ValidationResults)
        {
            if (ValidationResults.IsValid == false)
            {
                foreach (ValidationFailure failure in ValidationResults.Errors)
                {
                    Console.WriteLine($"{failure.PropertyName}:{failure.ErrorMessage}");
                }
            }

            return ValidationResults.IsValid;
        }

    }
}
