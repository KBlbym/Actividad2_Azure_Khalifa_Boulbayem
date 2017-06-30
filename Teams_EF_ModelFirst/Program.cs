////////////////////////////////////////
//                                    //
//  Actividad 2 del Examen de Azure   // 
//  Author:  Khalifa Boulbayem        //
//  Github: Kblbym                    //
//  Linkedin: khalifaboulbayem        //
//  Twitter: @khalifablbym            //
//                                    //
////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams_EF_ModelFirst
{
    class Program
    {
         
        

        static void Main(string[] args)
        {
            Model1Container conexion = new Model1Container();
            using (conexion)
            {

                //TeamsInitialize(conexion);
                //conexion.SaveChanges();


                //Show All Teams
                Console.WriteLine("Show All Teams");
                var showteams = ShowTeam(conexion);
                showteams.ForEach(a =>
                {
                    Console.WriteLine("Name :{0} \t Champions luegue nº:{1}\t Leugue nº:{2} \t statum Id {3}", a.Name, a. ChampionsLeagueNum, a.LeagueNum, a.Stadium.Id);
                });
                Console.ReadLine();

                //Show Staduims
                Console.WriteLine("Show Staduims");
                var showsataduims = ShowStadium(conexion);
                showsataduims.ForEach(a =>
                {
                    Console.WriteLine("Id : {3} \tName :{0} \t capacity:{1}\t City nº:{2}", a.Name, a.Capacity, a.Capacity, a.Id);
                });

                //Find Team
                Console.WriteLine();
                Console.WriteLine("Find Team 'Equipo 1', 'Equipo 2' , 'Equipo 2' ...");
                var TeamName = Console.ReadLine();
                var findteam = FindTeam(conexion, TeamName);

                Console.WriteLine("Name :{0} \t Champions luegue nº:{1}\t Leugue nº:{2} \t statum Id {3}", findteam.Name, findteam.ChampionsLeagueNum, findteam.LeagueNum, findteam.Stadium.Id);
                Console.ReadLine();

                //Find Team by Staduim
                Console.WriteLine("Find Team by Staduim 'estadio 3'");
                var findteambyStd = FindTeamsByStadium(conexion, "estadio 3");
                findteambyStd.ForEach(a =>
                {
                    Console.WriteLine("Name :{0} \t Champions luegue nº:{1}\t Leugue nº:{2} \t statum Id {3} \t Staduim Name:{4}", a.Name, a.ChampionsLeagueNum, a.LeagueNum, a.Stadium.Id, a.Stadium.Name);
                });
                Console.ReadLine();

            }

            }
        public static void TeamsInitialize(Model1Container cnx)
        {
            List<Stadium> estadiums = new List<Stadium>()
            {
            new Stadium() { Name = "estadio 1",  Capacity= 25000 , City = "city 1"   },
            new Stadium() { Name = "estadio 2", Capacity = 30000,  City = "city 1"   },
            new Stadium() { Name = "estadio 1",  Capacity= 25000 , City = "city 1"   },
            new Stadium() { Name = "estadio 2", Capacity = 30000,  City = "city 1"   },
            new Stadium() { Name = "estadio 3", Capacity = 70000,  City = "city 1"  },
            new Stadium() { Name = "estadio 3", Capacity = 70000,  City = "city 1"  }
            };
            cnx.Stadiums.AddRange(estadiums);
            
            List<Team> teams = new List<Team>()
            {
            new Team() { Name = "Equipo 1", ChampionsLeagueNum = 5 , LeagueNum = 24, Stadium = estadiums[0]},
            new Team() { Name = "Equipo 2", ChampionsLeagueNum = 0, LeagueNum = 10, Stadium =  estadiums[1] },
            new Team() { Name = "Equipo 3", ChampionsLeagueNum = 5, LeagueNum = 27, Stadium =  estadiums[2] },
            new Team() { Name = "Equipo 4", ChampionsLeagueNum = 7, LeagueNum = 18, Stadium = estadiums[3] },
            new Team() { Name = "Equipo 5", ChampionsLeagueNum = 7, LeagueNum = 18, Stadium = estadiums[4] },
            new Team() { Name = "Equipo 6", ChampionsLeagueNum = 5 , LeagueNum = 24, Stadium = estadiums[5]},
            new Team() { Name = "Equipo 7", ChampionsLeagueNum = 0, LeagueNum = 10, Stadium =  estadiums[5] },
            new Team() { Name = "Equipo 8", ChampionsLeagueNum = 5, LeagueNum = 27, Stadium =  estadiums[5] },
            new Team() { Name = "Equipo 9", ChampionsLeagueNum = 7, LeagueNum = 18, Stadium =  estadiums[5] },
            new Team() { Name = "Equipo 10", ChampionsLeagueNum = 7, LeagueNum = 18, Stadium = estadiums[5] },
            new Team() { Name = "Equipo 11", ChampionsLeagueNum = 7, LeagueNum = 18, Stadium = estadiums[5] },
            };
            cnx.Teams.AddRange(teams);
            


        }

        public static List<Team> ShowTeam(Model1Container cnx)
        {
            var getTeams = cnx.Teams.ToList();
            return getTeams;
        }
        public static List<Stadium> ShowStadium(Model1Container cnx)
        {
            var getsataduim = cnx.Stadiums.ToList();
            return getsataduim;
        }
        public static Team FindTeam(Model1Container cnx,string name)
        {
            var findTeam = cnx.Teams.Where(a => a.Name == name).FirstOrDefault();
            return findTeam;
        }
        public static List<Team> FindTeamsByStadium(Model1Container cnx, string namestd)
        {
            return cnx.Teams.Where(a => a.Stadium.Name == namestd).ToList();
            
            //if (findTeam.Count() > 1)
            //{
            //    return findTeam.ToList();
            //}
            //else
            //{
            //    return findTeam;
            //}
        }
        
    }
}
