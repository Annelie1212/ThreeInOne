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

        Dictionary<int, string> Move = new Dictionary<int, string>()
        {
            {1,"sten" },
            {2,"sax" },
            {3,"påse" }
        };

        public int UserValue1 { get; set; }

        public int ComputerValue1 { get; set; }
        public int UserValue2 { get; set; }
        public int ComputerValue2 { get; set; }
        public int UserValue3 { get; set; }
        public int ComputerValue3 { get; set; }

        //TODO LOOK HERE
        public int ComputerPoints { get; set; }
        //TODO LOOK HERE STATIC??
        public int PlayerPoints { get; set; }

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

        public string PlayerName { get; set; }
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
                ComputerPoints += 0;
                PlayerPoints += 0;
                return "Ställningen blev lika";
            }   
            else if ( userValue == "sten" && computerValue == "sax")
            {
                ComputerPoints += 0;
                PlayerPoints += 1;
                return "Spelaren vann!";
            }
            else if (userValue == "sax" && computerValue == "påse")
            {
                ComputerPoints += 0;
                PlayerPoints += 1;
                return "Spelaren vann!";
            }
            else if (userValue == "påse" && computerValue == "sten")
            {
                ComputerPoints += 0;
                PlayerPoints += 1;
                return "Spelaren vann!";
            }
            else
            {
                ComputerPoints += 1;
                PlayerPoints += 0;
                return "Datorn vann";
            }            
        }

        public void ShowResults()
        {
            Console.WriteLine("\nSLUTRESULTAT\n");

            Console.WriteLine($"Spelaren vann {PlayerPoints} gånger.");
            Console.WriteLine($"Datorn vann {ComputerPoints} gånger.");

            if (ComputerPoints > PlayerPoints)
            {
                this.Win = 0;
                this.Loss = 1;
                this.Tie = 0;

                Console.Write("Datorn vann!");
            }
            else if (ComputerPoints < PlayerPoints)
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

        public bool PlayMatch()
        {
            Menu insertNameMenu = new Menu(MenuData.InsertNameNr, MenuData.InsertNameMenu);
            insertNameMenu.Display();
            string playerName = Console.ReadLine();

            AppValidation playerValidation = new AppValidation(new PlayerModel(playerName));
            bool isPlayerNameInputValid = playerValidation.ValidatePlayerModel();

            if (isPlayerNameInputValid) 
            {

                this.PlayerName = playerName;

                Random random = new Random();

                for (int roundNr = 0; roundNr < 3; roundNr++)
                {
                    bool playRoundBool = PlayRound(Move, random,roundNr);
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
                        AverageWin = wins.Average(),
                        PlayerName = this.PlayerName
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
                        if (this.RoundResults[i] == "win")
                        {
                            tempWin = 1;
                            tempLoss = 0;
                            tempTie = 0;
                        }
                        else if (this.RoundResults[i] == "loss")
                        {
                            tempWin = 0;
                            tempLoss = 1;
                            tempTie = 0;
                        }
                        else if (this.RoundResults[i] == "tie")
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
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //move är en dictionary som översätter talen 1,2,3 till sten sax påse.
        public bool PlayRound(Dictionary<int, string> move, Random random,int roundNr)
        {
            Menu matchMenu = new Menu(MenuData.RPSMatchMenuNr, MenuData.RPSMatchMenu);
            matchMenu.Display();
            string value1 = Console.ReadLine();


            RockPaperScissorsModel rockPaperScissorsModel = new RockPaperScissorsModel(value1);
            RockPaperScissorsValidator rockPaperScissorsValidator = new RockPaperScissorsValidator();
            ValidationResult validationResults = rockPaperScissorsValidator.Validate(rockPaperScissorsModel);
            bool isInputValid = ErrorMessageDiplay(validationResults);

            if (isInputValid)
            {
                int valueInt = int.Parse(value1);


                Console.WriteLine(MenuData.playersMove + move[valueInt]);

                int randomNumber1 = random.Next(1, 4);
                Console.WriteLine(MenuData.computersMove + move[randomNumber1]);

                string roundResult = Winner(move[valueInt], move[randomNumber1]);
                //continue
                //PlayerComputerRoundResults (win,loss,tie)
                if (roundResult == MenuData.playerWins) { 
                    RoundResults[roundNr] = "win"; }
                else if (roundResult == MenuData.computerWins) { 
                    RoundResults[roundNr] = "loss"; }
                else if (roundResult == MenuData.tie) { 
                    RoundResults[roundNr] = "tie"; }
                
                Console.WriteLine(roundResult);

                this.PlayerMoves[roundNr] = move[valueInt];
                this.ComputerMoves[roundNr] = move[randomNumber1];
                //Console.WriteLine();

                return true;
            }

            return false;


        }
        public void ShowTotalResults()
        {
            using (ThreeInOneAppDbContext dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                Console.WriteLine("MATCHERNAS RESULTAT\n");
                foreach (var matchData in dbContext.RockPaperScissorsMatchData)
                {
                    Console.WriteLine($"Datum: {matchData.DateTime}");
                    Console.WriteLine($"Namn: {matchData.PlayerName}");
                    Console.WriteLine($"Match-ID: {matchData.MatchId}");
                    Console.WriteLine($"Vinst: {matchData.Win}");
                    Console.WriteLine($"Förlust: {matchData.Loss}");
                    Console.WriteLine($"Oavgjort: {matchData.Tie}");
                    Console.WriteLine($"Total medelvinst (för alla spelare sammanlagt): {matchData.AverageWin}");
                    Console.WriteLine("====================");
                }
            }
        }

        public void ShowTotalRounds()
        {
            Console.WriteLine("RESULTAT FÖR ALLA RUNDOR\n");
            using (ThreeInOneAppDbContext dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                int rowNr = 0;
                foreach (var roundData in dbContext.RockPaperScissorsRoundData)
                {
                    Console.WriteLine($"Datum: {roundData.DateTime}");
                    Console.WriteLine($"Match-ID: {roundData.MatchId}");
                    Console.WriteLine($"Runda-ID: {roundData.MatchId}");
                    Console.WriteLine($"Vinst: {roundData.Win}");
                    Console.WriteLine($"Förlust: {roundData.Loss}");
                    Console.WriteLine($"Oavgjort: {roundData.Tie}");
                    Console.WriteLine($"Spelardrag: {roundData.PlayerMove}");
                    Console.WriteLine($"DatorDrag: {roundData.ComputerMove}");
                    rowNr++;
                    Console.WriteLine("");
                    if (rowNr%3 ==0)
                    {
                        Console.WriteLine("====================");

                    }
                }
            }
        }

        public void ShowPlayerResults()
        {
            Console.WriteLine("SPELARNAS RESULTAT\n");
            using (ThreeInOneAppDbContext dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                //Namn
                //Antal vinster: 12
                //Vinstandel: 5%
                //-------------------

                List<string> nameList = new List<string>();
                Dictionary<string,int> winDictionary = new Dictionary<string,int>();
                Dictionary<string, int> lossDictionary = new Dictionary<string, int>();
                Dictionary<string, int> tieDictionary = new Dictionary<string, int>();

                foreach (var matchData in dbContext.RockPaperScissorsMatchData)
                {
                    string tempName = matchData.PlayerName;
                    if (winDictionary.ContainsKey(tempName))
                    {
                        winDictionary[tempName] += matchData.Win;
                        
                    }if(lossDictionary.ContainsKey(tempName))
                    {
                        lossDictionary[tempName] += matchData.Loss;
                    }
                    if(tieDictionary.ContainsKey(tempName))
                    {
                        tieDictionary[tempName] += matchData.Tie;
                    }
                    else
                    {
                        winDictionary[tempName] = matchData.Win;
                        lossDictionary[tempName] = matchData.Loss;
                        tieDictionary[tempName] = matchData.Tie;
                    }
                }
                nameList = winDictionary.Keys.ToList();

                foreach(string name in nameList)
                {
                    Console.WriteLine($"Namn: {name}");
                    double wins = winDictionary[name];
                    double losses = lossDictionary[name];
                    double ties = tieDictionary[name];

                    Console.WriteLine($"Vinster: {wins}");
                    Console.WriteLine($"Förluster: {losses}");
                    Console.WriteLine($"Oavgjort: {ties}");
                    double winRate = wins / (wins + losses + ties);
                    
                    Console.WriteLine($"Vinstandel: {winRate*100:F2}%");
                    Console.WriteLine("====================");
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
