using Console_RPG.Entities;
using Console_RPG.Items;
using System.Numerics;
using System.Xml.Linq;

namespace Console_RPG.Assistant
{
    internal class Events
    {
        private static List<Weapons> Weapons = new()
        {
            new ("Adaga", "Arma de curto alcance, porém, quando usada por |mãos hábeis, pode causar grande dano.",4),
            new ("Falcata de Ferro Antiga", "Uma antiga espada de ferro, tão desgastada que |quase não se vê fio. Há algo gravado nela, mas |não é possível ler.",2),
            new ("Falcata de Ferro", "Espada feita de ferro fundido, possui um bom fio|e uma resistência mediana. Geralmente é usada |por bandidos e exploradores.",4),
            new ("Claymore de Aço", "Espada feita puramente de aço, possui um ótimo |fio e uma grande resistência. Quase sempre usada|pelo exército real.", 6),
            new ("Radiante", "Uma rara espada feita de um material misterioso,|era usada por clérigos para combater os |mortos-vivos e hereges.", 8),
            new ("Serpentina dos Homens Serpentes", "Espada curva usada por estranhas criaturas |encontradas em cavernas. Relatos dizem que a |aparência desses seres é descrita como metade |homem, metade serpente.", 6),
            new ("Cimitarra", "Espada curva usada por habilidosos espadachins |que habitam os desertos do sul.", 4),
            new ("Eclipse", "Uma espada mística de aparência única, com |letras gravadas nela que aparentam ser de uma |língua muito antiga.|“Lunae Lumen”.", 8),
            new ("Machado", "Usado por camponeses que habitavam a |região.", 4),
            new ("Devastador", "Machado usado em batalhas, comumente portado por|guerreiros do norte. Com a técnica certa, é |possível cortar um homem adulto em dois.", 8),
            new ("Cortador de Queixos", "Um estranho machado usado exclusivamente para |matar. Por alguma razão, o alvo de seus golpes |sempre é o queixo.", 8)
        };
        private static List<Armors> Armors = new()
        {
            new ("Roupas Esfarrapadas", "Roupas muito velhas que não proporcionam quase |nenhuma defesa. Há alguns buracos e pequenas |manchas de sangue.", 2),
            new ("Couraça de Couro", "A proteção mais básica que você vai encontrar |por aqui. Quase sempre usada por ladrões e |soldados de baixa categoria.", 4),
            new ("Jaquetão de Explorador", "Concede proteção suficiente para aqueles que |desejam explorar o mundo.", 4),
            new ("Cota de Malha de Ferro", "Usada por bandidos e soldados do exército real, |oferece uma boa proteção nos combates.", 6),
            new ("Armadura de Placas","Usada apenas por membros da elite do exército |real, oferece uma grande proteção nos combates.", 8),
            new ("Manto Negro", "Armadura usada por membros da antiga seita que |trabalhava a mando do Rei Dorian. Exala um odor |forte de sangue... humano?", 6)
        };
        private static List<Keys> Keys = new()
        {
            new ("Chave Enferrujada","Uma chave bem deteriorada, talvez abra as portas|deste maldito lugar."),
            new ("Chave das Ruínas","Chave antiga e de aspecto rústico que abre a |porta para a antiga ruína cujo nome já foi |esquecido há muito tempo."),
            new ("Chave do Selo","Possui formato arredondado e inscrições |retratando datas muito antigas. Há um nome |escrito na parte de trás.|“Jasmine”."),
            new ("Grande Chave Antiga","Chave feita de ferro fundido, bastante pesada e |com alguns detalhes semelhantes a escamas."),
            new ("Chave do Confinamento","Chave simples em aparência, mas complexa em |proteção. Abre as portas para a área solitária."),
            new ("Chave de Baú","Usada para trancar ou destrancar baús.")
        };
        private static List<Potions> Potions = new()
        {
            new ("Poção de Calêndula Pequena", "Feita de flores colhidas nos campos no início do|verão. Ao ingerir, causa uma sensação agradável |e recupera um pouco de sua vitalidade.", 15),
            new ("Poção de Calêndula Média","Feita de flores colhidas nos campos no início do|verão. Ao ingerir, causa uma sensação moderada |e recupera razoavelmente sua vitalidade.",25),
            new ("Poção de Calêndula Grande","Feita de flores colhidas nos campos no início do|verão. Ao ingerir, causa uma sensação muito |agradável e recupera significativamente sua |vitalidade.",50),
            new ("Poção de Ephedra Pequena","Feita de flores colhidas nas montanhas no meio |da primavera. Ao ingerir, acelera um pouco os |batimentos cardíacos e recupera um pouco seu |vigor.",15),
            new ("Poção de Ephedra Média","Feita de flores colhidas nas montanhas no meio |da primavera. Ao ingerir, acelera |consideravelmente os batimentos cardíacos e |recupera razoavelmente seu vigor.", 25),
            new ("Poção de Ephedra Grande","Feita de flores colhidas nas montanhas no meio |da primavera. Ao ingerir, acelera bastante os |batimentos cardíacos e recupera |significativamente seu vigor.",50),
        };
        private static List<Foods> Foods = new()
        {
            new ("Carne de Rato Gigante", "Coletada de Ratos Gigantes, pode facilmente |matar se não for preparada corretamente.", "Bad", 15),
            new ("Carne de Rato Gigante Cozida", "Mesmo algo grotesco como isso pode saciar a fome|dos mais desesperados.", "Good", 10),
            new ("Pão Preto", "Feito de farinha de trigo, sal, mel e fermento. |É um ótimo acompanhamento para carnes e sopas.", "Good", 10),
            new ("Quarto de Queijo", "Uma boa fonte de gordura, feito por fazendeiros |das redondezas.", "Excellent", 20),
            new ("Maçãs", "Não parecem estar frescas, mas ainda são |comestíveis.", "Good", 10),
            new ("Peixe", "Algumas criaturas conseguem viver nesses |lugares, mesmo sendo tão sujos.", "Bad", 15),
            new ("Peixe Assado", "Essa refeição com certeza vai encher o seu |estômago.", "Good", 10),
            new ("Maça Dourada", "Feita com várias tiras finas de ouro... Quem |será o criador disso?", "Excellent", 20)
        };
        private static List<Miscellaneous> Miscellaneous = new()
        {
            new ("Colar", "Colar feito de prata, possui um pingente em |formato de folha. Alguém perdeu isso há muito |tempo atrás."),
            new ("Colar Dourado", "Colar feito de ouro, possui um pingente em |formato de lua. Provavelmente foi usado por uma |rainha."),
            new ("Pintura Antiga", "Antiga pintura retratando o rosto do Major |Edward, o administrador das catacumbas."),
            new ("Livro de Histórias Infantis", "Pequeno livro azul, a capa, mesmo deteriorada, |mostra duas crianças brincando com seu cachorro.|O título é ilegível."),
            new ("Antiga Escama de Dragão", "Pedaço de escama de um dragão negro. Esta pode |ser a primeira ou a última vez que você |encontrará isso."),
            new ("Raízes Secas", "Raízes secas de uma margarida."),
            new ("Pedra Estranha", "Pedra de coloração preta, quando reflete a luz, |revela pequenos pontos brancos semelhantes a |estrelas."),
            new ("Anel", "Anel de ouro já opaco pelo tempo. Há uma data |gravada nele... Seria o dia de um casamento?"),
            new ("Gazua", "Conjunto enferrujado de gazuas, uma delas ainda |é utilizável. Pode ser usada para abrir algo."),
        };
        private static List<Notes> Notes = new()
        {
            //012345678901234567890123456789012345678901234567|
            new ("Nota:Fuga", "Pegue esses itens e dê o seu melhor para escapar|com vida."),
            new ("Nota:Aviso", "Apenas pessoas autorizadas deverão entrar nessa |parte da prisão, e de forma alguma deixe essa |porta aberta."),
            new ("Nota:Indagação","Tentei abrir esse baú usando todas as minhas cha|ves, mas nenhuma encaixa na fechadura."),
            new ("Nota:Viagem", "Vou seguir viagem com uma caravana, ficarei fora|durante 7 meses para melhorar minhas habilidades|de combate."),                                  
            new ("Nota:Expedição", "Hoje iniciaremos a expedição para matar o grande|dragão Visari..."),
            new ("Nota:Ensanguentada", "Acredito que fui o único a sobreviver dessa bata|lha. Visari é um dragão formidável, sua força é |incomparável. Consegui cavar um túnel usando as |mãos, vou me recuperar e vou sair daqui amanh...")
        };
        internal static void GameEventChests(Player player, string[,] map, string currentMap, string element)
        {
            switch (currentMap)
            {
                case "Catacombs":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 38:
                            Sound.SFXPlayer("ChestSFX.wav");
                            player.FoundItem(Armors[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 85:
                            Sound.SFXPlayer("ChestSFX.wav");
                            player.FoundItem(Potions[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 43:
                            if (player.Inventory.Contains(Miscellaneous[8]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Miscellaneous[8]);
                                player.FoundItem(Weapons[4]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                    }
                    break;
                case "Ruins":
                    break;
                case "Old_Crypt":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 57:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[3]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 42:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[5]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                    }
                    break;
                case "Bandits_Domain":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 48:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Armors[4]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                        case 70:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[7]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                    }
                    break;
                case "Underground_Passage":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 47:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[10]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;                        
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    break;
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 21:
                            if (player.Inventory.Contains(Keys[5]))
                            {
                                Sound.SFXPlayer("ChestSFX.wav");
                                player.RemoveItem(Keys[5]);
                                player.FoundItem(Weapons[9]);
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                    }
                    break;
            }
        }
        internal static void GameEventBattles(Player player, string[,] map, string currentMap, string element) //Acredito que funcionou.
        {
            Enemy Target;
            GameConsole.ConsoleOutput("A batalha irá começar");

            int[] ReturnsFromEnemySumPosition = new int[3];

            switch (currentMap)
            {
                case "Catacombs":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);                    
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 48:
                            Target = new GiantRat();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 44:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 72:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 84:
                            Target = new GiantRat();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 75:
                            Target = new Undead();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 81:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 22:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 43:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Ruins":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 55:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 33:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 87:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 68:
                            Target = new Undead();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 20:
                            Target = new Undead();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Old_Crypt":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 22:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 71:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 49:
                            Target = new Thief();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 84:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 62:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 83:
                            Target = new SerpentMan();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 60:
                            Target = new SerpentMan();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 30:
                            Target = new SerpentMan();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 44:
                            Target = new SerpentMan();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 71:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 26:
                            Target = new Undead();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Bandits_Domain":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 77:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 36:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 67:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 71:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 84:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 53:
                            Target = new Bandit();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 32:
                            Target = new BanditMarauder();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                    }
                    break;
                case "Underground_Passage":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 49:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 77:
                            Target = new GiantRat();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 76:
                            Target = new GiantRat();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;
                        case 48:
                            Target = new Skeleton();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;                        
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 72:
                            Target = new UndeadDragon();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            break;                        
                    }
                    break;
                case "Confinement":
                    ReturnsFromEnemySumPosition = EnemySumPosition(player.Y, player.X, map, element);
                    switch (ReturnsFromEnemySumPosition[2])
                    {
                        case 60:
                            Target = new MadWarrior();
                            Battle.OneVersusOne(player, Target);
                            Render.KillObject(ReturnsFromEnemySumPosition[1], ReturnsFromEnemySumPosition[0], element, map, currentMap);
                            Render.ModifyMap(69, 6, "!", map, currentMap);
                            Render.ModifyMap(71, 10, "─", map, currentMap);
                            Render.ModifyMap(72, 10, "─", map, currentMap);
                            break;
                    }
                    break;
            }
        }
        internal static void GameEventInterestPoints(Player player, string[,] map, string currentMap, string element)
        {
            switch (currentMap)         {
                case "Catacombs":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 27:
                            GameConsole.ConsoleOutput("Placa: Acesso restrito.");
                            break;
                        case 31:
                            GameConsole.ConsoleOutput("Cadáver de um carcereiro, os vermes já começaram a comer sua carne.");
                            break;
                        case 30:
                            GameConsole.ConsoleOutput("Esqueleto de um prisioneiro, número de identificação: 0178.");
                            break;
                        case 55:
                            GameConsole.ConsoleOutput("Placa: Portão de entrada para as Catacumbas.");
                            break;
                        case 67:
                            GameConsole.ConsoleOutput("Cadáver de um homem, não consta número de identificação.");
                            break;
                        case 83:
                            GameConsole.ConsoleOutput("Suporte para molho de chave.");
                            break;
                        case 84:
                            GameConsole.ConsoleOutput("Esqueleto de um guarda, ainda permanece sentado no seu posto.");
                            break;
                        case 94:
                            GameConsole.ConsoleOutput("Corpo do supervisor, Laurence, não apresenta sinais de violência, talvez tenha morrido de fome.");
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {                            
                        case 14:
                            GameConsole.ConsoleOutput("Acampamento abandonado, sua construção foi feita de forma precária.");
                            break;
                        case 59:
                            GameConsole.ConsoleOutput("Corpo sem vida de um homem, seu rosto está dilacerado e suas roupas estão completamente sujas.");
                            break;
                        case 93:
                            GameConsole.ConsoleOutput("Corpo sem vida de um jovem explorador, que infelicidade...");
                            break;
                        case 70:
                            GameConsole.ConsoleOutput("Placa: Estrada que leva para as antigas ruinas.");
                            break;
                    }
                    break;
                case "Ruins":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 33:
                            GameConsole.ConsoleOutput("Esqueleto bastante antigo, está sem cabeça e cheio de musgo.");
                            break;                        
                        case 49:
                            GameConsole.ConsoleOutput("Placa deteriorada: P s agem  ubter ân a log  em f ent .");
                            break;
                        case 55:
                            GameConsole.ConsoleOutput("Corpo sem vida de um jovem ladrão, há várias mordidas profundas no seu braço.");
                            if (!player.Skills.Contains("Estocada"))
                            {
                                player.TakeSkill("Estocada");
                                GameConsole.ConsoleOutput("Nova técnica aprendida.");
                            }
                            break;
                    }
                    break;
                case "Old_Crypt":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 27:
                            GameConsole.ConsoleOutput("Tumba de Major Edward o carrasco real.");
                            break;
                        case 46:
                            GameConsole.ConsoleOutput("Tumba de Dorian o antigo rei de Trina.");
                            break;
                        case 49:
                            GameConsole.ConsoleOutput("Tumba de Jasmine a antiga rainha de Trina.");
                            break;
                        case 60:
                            GameConsole.ConsoleOutput("Tumba sem identificação, uma grossa camada de poeira está sobre ela.");
                            break;
                        case 92:
                            GameConsole.ConsoleOutput("Tumba de Sir Jones, o cavaleiro responsável por destruir a seita dos assassinos.");
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 40:
                            GameConsole.ConsoleOutput("Estátua de uma grande serpente.");
                            if (!player.Skills.Contains("Corte da Lua"))
                            {
                                player.TakeSkill("Corte da Lua");
                                GameConsole.ConsoleOutput("Nova técnica aprendida.");
                            }
                            break;
                        case 55:
                            GameConsole.ConsoleOutput("Pilha de ossos humanos.");
                            break;
                        case 35:
                            GameConsole.ConsoleOutput("Cadáver de um espadachim, há um corte bem profundo em seu peito.");
                            break;                        
                    }
                    break;
                case "Bandits_Domain":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 30:
                            GameConsole.ConsoleOutput("Grande gaiola de ferro usada para encarcerar prisioneiros.");
                            break;
                        case 72:
                            GameConsole.ConsoleOutput("Baú usado para guardar itens saqueados.");
                            break;                        
                    }
                    break;
                case "Underground_Passage":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 30:
                            GameConsole.ConsoleOutput("Esqueleto de um guarda, pelo visto ele nunca foi liberado dos seus serviços.");
                            break;
                        case 72:
                            GameConsole.ConsoleOutput("Baú usado para guardar itens saqueados.");
                            break;
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 62:
                            GameConsole.ConsoleOutput("Corpo carbonizado.");
                            break;
                        case 52:
                            GameConsole.ConsoleOutput("Corpo carbonizado.");
                            break;
                        case 74:
                            GameConsole.ConsoleOutput("Esqueleto antigo.");
                            break;
                        case 41:
                            GameConsole.ConsoleOutput("Pilha de ossos.");
                            break;
                        case 42:
                            GameConsole.ConsoleOutput("Pilha de ossos.");
                            break;
                        case 77:
                            GameConsole.ConsoleOutput("Cadáver mumificado de um clérigo.");
                            if (!player.Inventory.Contains(Notes[5]))
                            {
                                Sound.SFXPlayer("ItemPickupSFX.wav");
                                player.FoundItem(Notes[5]);
                            }                            
                            if (!player.Skills.Contains("Raios Divinos"))
                            {
                                player.TakeSkill("Raios Divinos");
                                GameConsole.ConsoleOutput("Nova técnica aprendida.");
                            }
                            break;
                    }
                    break;
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 54:
                            GameConsole.ConsoleOutput("Esqueleto pendurado na grade da cela.");
                            break;
                        case 91:
                            GameConsole.ConsoleOutput("Esqueleto sem identificação.");
                            if (!player.Skills.Contains("Dilacerar"))
                            {
                                player.TakeSkill("Dilacerar");
                                GameConsole.ConsoleOutput("Nova técnica aprendida.");
                            }
                            break;
                        case 77:
                            GameConsole.ConsoleOutput("Rato Gigante morto, seu estomago está dilacerado.");
                            break;
                        case 67:
                            GameConsole.ConsoleOutput("Rato Gigante morto.");
                            break;                        
                    }
                    break;
            }
        }
        internal static void GameEventObjectivePoints(Player player, string[,] map, string currentMap, string element)
        {
            switch (currentMap)
            {
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 75:
                            GameConsole.ConsoleOutput("E assim essa aventura termina.");
                            GameConsole.ConsoleOutput("Obrigado por ter jogado o meu jogo!");
                            player.TakeDamage(999);
                            GameConsole.ConsoleOutput($"{player.Name} recebeu 999 pontos de dano!");
                            Game.GameOver();
                            break;
                    }
                break;
            }
        }
        internal static void GameEventDoors(Player player, string[,] map, string currentMap, string element)
        {
            switch (currentMap)
            {
                case "Catacombs":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 13:
                            if (player.Inventory.Contains(Keys[0]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[0]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                        case 30:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 46:
                            GameConsole.ConsoleOutput("Está trancado.");
                            break;
                        case 58:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 41:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 55:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 74:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 78:
                            if (player.Inventory.Contains(Keys[4]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[4]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                        case 101:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 52:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 58:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 21:
                            if (player.Inventory.Contains(Keys[3]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[3]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                        case 63:
                            if (player.Y == 29)
                            {
                                Sound.SFXPlayer("DoorSFX.wav");
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Não abre por esse lado.");
                            }
                            break;
                        case 73:
                            if (player.Inventory.Contains(Keys[1]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[1]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                    }
                    break;
                case "Ruins":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 14:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 72:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 101:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 70:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 48:
                            if (player.Inventory.Contains(Keys[2]))
                            {
                                Sound.SFXPlayer("DoorSFX.wav");                                
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                                player.RemoveItem(Keys[2]);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Está trancado.");
                            }
                            break;
                    }
                    break;
                case "Old_Crypt":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 29:
                            if (player.Y == 20)
                            {
                                Sound.SFXPlayer("DoorSFX.wav");
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Não abre por esse lado.");
                            }
                            break;
                        case 45:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 23:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 53:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 71:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 72:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 73:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 89:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 103:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 69:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 46:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 45:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 22:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 17:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 38:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Bandits_Domain":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 21:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 22:
                            if(player.X == 14)
                            {
                                Sound.SFXPlayer("DoorSFX.wav");
                                Render.KillObject(player.X, player.Y, element, map, currentMap);
                            }
                            else
                            {
                                GameConsole.ConsoleOutput("Não abre por esse lado.");
                            }
                            break;
                        case 93:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 44:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;                        
                    }
                    break;
                case "Underground_Passage":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {                        
                        case 58:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    break;
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 54:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 78:
                            Sound.SFXPlayer("DoorSFX.wav");
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 98:
                            GameConsole.ConsoleOutput("Está trancado.");
                            break;
                    }
                    break;
            }
        }
        internal static void GameEventItems(Player player, string[,] map, string currentMap, string element)
        {
            Sound.SFXPlayer("ItemPickupSFX.wav");
            switch (currentMap)
            {
                case "Catacombs":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 13:
                            player.FoundItem(Foods[2]);
                            player.FoundItem(Foods[2]);
                            player.FoundItem(Keys[0]);
                            player.FoundItem(Notes[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 30:
                            player.FoundItem(Weapons[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 50:
                            player.FoundItem(Potions[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 77:
                            player.FoundItem(Notes[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 88:
                            player.FoundItem(Miscellaneous[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 95:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Abandoned_Fortress":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 15:
                            player.FoundItem(Weapons[2]);
                            player.FoundItem(Foods[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 71:
                            player.FoundItem(Foods[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 82:
                            player.FoundItem(Foods[6]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 92:
                            player.FoundItem(Armors[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 18:
                            player.FoundItem(Miscellaneous[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 49:
                            player.FoundItem(Potions[1]);
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 45:
                            player.FoundItem(Notes[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 51:
                            player.FoundItem(Keys[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Ruins":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 44:
                            player.FoundItem(Weapons[8]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 48:
                            player.FoundItem(Potions[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 51:
                            player.FoundItem(Miscellaneous[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 56:
                            player.FoundItem(Weapons[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 103:
                            player.FoundItem(Armors[1]);
                            player.FoundItem(Foods[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 17:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 29:
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 60:
                            player.FoundItem(Potions[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 81:
                            player.FoundItem(Foods[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            player.FoundItem(Foods[2]);
                            player.FoundItem(Foods[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Old_Crypt":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 109:
                            player.FoundItem(Armors[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 78:
                            player.FoundItem(Keys[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 79:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 21:
                            player.FoundItem(Miscellaneous[8]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 62:
                            player.FoundItem(Foods[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 24:
                            player.FoundItem(Potions[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 6:
                            GameConsole.ConsoleOutput("Bolsa pequena de couro.");
                            player.FoundItem(Potions[0]);
                            player.FoundItem(Potions[3]);
                            player.FoundItem(Potions[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Serpent_Man_Dungeon":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 34:
                            player.FoundItem(Weapons[6]);
                            player.FoundItem(Notes[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 63:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 72:
                            player.FoundItem(Miscellaneous[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 100:
                            player.FoundItem(Potions[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 10:
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 91:
                            player.FoundItem(Foods[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 24:
                            player.FoundItem(Foods[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 82:
                            player.FoundItem(Potions[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 74:
                            player.FoundItem(Foods[6]);
                            player.FoundItem(Foods[6]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 11:
                            player.FoundItem(Potions[0]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Bandits_Domain":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 60:
                            player.FoundItem(Potions[2]);                                                       
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 86:
                            player.FoundItem(Foods[6]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            player.FoundItem(Potions[1]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 52:
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 35:
                            player.FoundItem(Keys[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 30:
                            player.FoundItem(Foods[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 84:
                            player.FoundItem(Miscellaneous[3]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;                    
                case "Underground_Passage":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 39:
                            GameConsole.ConsoleOutput("Bolsa grande de couro.");
                            player.FoundItem(Potions[2]);
                            player.FoundItem(Potions[1]);
                            player.FoundItem(Potions[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 75:
                            player.FoundItem(Miscellaneous[7]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 80:
                            player.FoundItem(Keys[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;                                                
                    }
                    break;
                case "Ancient_Dragon_Cave":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 76:
                            player.FoundItem(Miscellaneous[6]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 73:
                            player.FoundItem(Notes[4]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
                case "Confinement":
                    switch (ElementSumPosition(player.Y, player.X, map, element))
                    {
                        case 4:
                            player.FoundItem(Keys[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 76:
                            player.FoundItem(Armors[5]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                        case 22:
                            player.FoundItem(Miscellaneous[2]);
                            Render.KillObject(player.X, player.Y, element, map, currentMap);
                            break;
                    }
                    break;
            }
        }
        private static int ElementSumPosition(int pY, int pX, string[,] map, string element)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (map[pY - 1 + i, pX - 1 + j] == element)
                    {
                        return (pY - 1 + i) + (pX - 1 + j);
                    };
                }
            }
            return 0;
        }        
        private static int[] EnemySumPosition(int pY, int pX, string[,] map, string element)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (map[pY - 2 + j, pX - 4 + i] == element)
                    {
                        return [(pY - 2 + j), (pX - 4 + i), (pY - 2 + j) + (pX - 4 + i)];
                    };
                }
            }
            return [];
        }
    }
}