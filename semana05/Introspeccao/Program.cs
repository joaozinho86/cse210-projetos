class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu de Opções:");
            Console.WriteLine("  1. Iniciar atividade de respiração");
            Console.WriteLine("  2. Iniciar atividade de reflexão");
            Console.WriteLine("  3. Iniciar atividade de listagem");
            // ===== FUNÇÃO EXTRA: opção para ver o registro de atividades =====
            Console.WriteLine("  4. Ver registro de atividades realizadas");
            Console.WriteLine("  5. Sair");
            // =================================================================
            Console.Write("Selecione uma opção do menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectingActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                // ===== FUNÇÃO EXTRA: exibir estatísticas =====
                case "4":
                    ActivityStatistics.DisplayStatistics();
                    break;
                // =============================================
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}

// ===== FUNÇÃO EXTRA: classe responsável por manter o registro de quantas vezes
// as atividades foram realizadas. Usa encapsulamento com um dicionário privado. =====
public static class ActivityStatistics
{
    private static Dictionary<string, int> _counts = new Dictionary<string, int>();

    public static void RegisterCompletion(string activityName)
    {
        if (_counts.ContainsKey(activityName))
        {
            _counts[activityName]++;
        }
        else
        {
            _counts[activityName] = 1;
        }
    }

    public static int GetCount(string activityName)
    {
        return _counts.ContainsKey(activityName) ? _counts[activityName] : 0;
    }

    public static void DisplayStatistics()
    {
        Console.Clear();
        Console.WriteLine("=== Registro de Atividades Realizadas ===");
        Console.WriteLine();

        if (_counts.Count == 0)
        {
            Console.WriteLine("Nenhuma atividade foi realizada ainda.");
        }
        else
        {
            foreach (var entry in _counts)
            {
                Console.WriteLine($"  {entry.Key}: {entry.Value} vez(es)");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Pressione Enter para voltar ao menu.");
        Console.ReadLine();
    }
}
// =================================================================================

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à Atividade de {_name}.\n");
        Console.WriteLine(_description);
        Console.WriteLine();

        // ===== FUNÇÃO EXTRA: mostra quantas vezes essa atividade já foi feita antes =====
        int previous = ActivityStatistics.GetCount(_name);
        Console.WriteLine($"(Você já realizou esta atividade {previous} vez(es) antes.)");
        // =================================================================================

        Console.WriteLine();
        Console.Write("Quantos segundos você gostaria que durasse sua sessão? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Prepare-se...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Muito bem!!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"Você completou mais {_duration} segundos da Atividade de {_name}.");
        ShowSpinner(3);

        // ===== FUNÇÃO EXTRA: registra que a atividade foi concluída e mostra o total =====
        ActivityStatistics.RegisterCompletion(_name);
        int total = ActivityStatistics.GetCount(_name);
        Console.WriteLine();
        Console.WriteLine($"[Registro] Atividade de {_name} realizada {total} vez(es) no total.");
        // =================================================================================
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animation[i % animation.Count];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);

            int digits = i.ToString().Length;
            Console.Write(new string('\b', digits));
            Console.Write(new string(' ', digits));
            Console.Write(new string('\b', digits));
        }

        Console.WriteLine();
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Respiração",
            "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Inspire...");
            int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
            if (remaining <= 0) break;
            ShowCountDown(Math.Min(4, remaining));

            if (DateTime.Now >= endTime) break;

            Console.WriteLine("Expire...");
            remaining = (int)(endTime - DateTime.Now).TotalSeconds;
            if (remaining <= 0) break;
            ShowCountDown(Math.Min(4, remaining));
        }

        DisplayEndingMessage();
    }
}

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Pense em uma ocasião em que você defendeu outra pessoa.",
        "Pense em uma ocasião em que você fez algo realmente difícil.",
        "Pense em uma ocasião em que você ajudou alguém necessitado.",
        "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
    };

    private List<string> _questions = new List<string>
    {
        "Por que essa experiência foi significativa para você?",
        "Você já fez algo assim antes?",
        "Como você começou?",
        "Como você se sentiu quando terminou?",
        "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
        "Qual é a sua coisa favorita sobre essa experiência?",
        "O que você pode aprender com essa experiência que se aplica a outras situações?",
        "O que você aprendeu sobre si mesmo por meio dessa experiência?",
        "Como você pode manter essa experiência em mente no futuro?"
    };

    public ReflectingActivity()
        : base(
            "Reflexão",
            "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Considere a seguinte mensagem:");
        Console.WriteLine();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.WriteLine("Quando tiver algo em mente, pressione Enter para continuar.");
        Console.ReadLine();

        Console.WriteLine("Agora reflita sobre cada uma das seguintes perguntas relacionadas a essa experiência.");
        Console.Write("Você pode começar em: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");

            int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
            if (remaining <= 0) break;

            ShowSpinner(Math.Min(10, remaining));
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }
}

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Quem são as pessoas que você aprecia?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu o Espírito Santo neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    public ListingActivity()
        : base(
            "Listagem",
            "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Liste o máximo de respostas que puder para a seguinte mensagem:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");

        Console.Write("Você pode começar em: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"Você listou {items.Count} itens!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
}