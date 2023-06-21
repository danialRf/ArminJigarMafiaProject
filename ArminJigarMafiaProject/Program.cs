using ArminJigarMafiaProject;



Console.WriteLine("Enter the number of players:");
int numPlayers = Convert.ToInt32(Console.ReadLine());

List<Person> players = new List<Person>();

for (int i = 0; i < numPlayers; i++)
{
    Console.WriteLine("Enter the name of player {0}:", i + 1);
    string? name = Console.ReadLine();
    players.Add(new Person { Id = i + 1, Name = name });
}

List<MafiaRole> MafiasRoleList = new List<MafiaRole>
        {
    MafiaRole.LecterDoc,
    MafiaRole.NormaMafia,
    MafiaRole.GodFather,

        };
List<ShahrvandRole> ShahrvandsRoleList = new List<ShahrvandRole>
{
    ShahrvandRole.Sniper,
    ShahrvandRole.Kargah,
    ShahrvandRole.Doc
};
List<ShahrvandRole> shuffleShahrvandRole = new List<ShahrvandRole>(ShahrvandsRoleList);
List<MafiaRole> shuffledRoles = new List<MafiaRole>(MafiasRoleList);

Random random = new Random();
double MafiaCount = Math.Ceiling((double)players.Count / 3);
for (int i = 0; i < MafiaCount; i++)
{
    int PlayerRandomIndex = random.Next(players.Count);
    int RoleRandomIndex = random.Next(MafiasRoleList.Count);

    if (MafiasRoleList.Count > 0)
    {
        
        players[PlayerRandomIndex].MafiaRole = MafiasRoleList[RoleRandomIndex];
        MafiasRoleList.RemoveAt(RoleRandomIndex);
    }
    else
    {
        players[PlayerRandomIndex].MafiaRole = MafiaRole.NormaMafia;
    }
    //int PlayerRandomIndex = random.Next(players.Count);
    //int RoleRandomIndex = random.Next(MafiasRoleList.Count);

    //players[PlayerRandomIndex].MafiaRole = MafiasRoleList[RoleRandomIndex];
    //MafiasRoleList.RemoveAt(RoleRandomIndex);
}
int ShahrvandCount = players.Count - (int)MafiaCount;


if (players.Any(player => player.MafiaRole == null || player.ShahrvandRole == null))
{
    for (int i = 0; i <= ShahrvandCount; i++)
    {
        int PlayerRandomIndex = random.Next(players.Count);

        // Find a player who doesn't have any role assigned
        while (players[PlayerRandomIndex].MafiaRole != null || players[PlayerRandomIndex].ShahrvandRole != null)
        {
            PlayerRandomIndex = random.Next(players.Count);
        }

        int RoleRandomIndex = random.Next(ShahrvandsRoleList.Count);
        
        if (ShahrvandsRoleList.Count > 0)
        {
            players[PlayerRandomIndex].ShahrvandRole = ShahrvandsRoleList[RoleRandomIndex];
            ShahrvandsRoleList.RemoveAt(RoleRandomIndex);
        }
        else
        {
            players[PlayerRandomIndex].ShahrvandRole=ShahrvandRole.NormalShahrvand;
        }
    }
}

Console.WriteLine("Assigned Roles:");
foreach (Person player in players)
{
    Console.WriteLine("{0} - {1}{2}", player.Name, player.ShahrvandRole, player.MafiaRole);
}
