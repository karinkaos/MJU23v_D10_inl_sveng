namespace MJU23v_D10_inl_sveng
{
    internal class Program
    {
        static List<SweEngGloss> dictionary;
        class SweEngGloss
        {
            public string word_swe, word_eng;
            public SweEngGloss(string word_swe, string word_eng)
            {
                this.word_swe = word_swe; this.word_eng = word_eng;
            }
            public SweEngGloss(string line)
            {
                string[] words = line.Split('|');
                this.word_swe = words[0]; this.word_eng = words[1];
            }
        }
        static void Main(string[] args)
        {
            string defaultFile = "..\\..\\..\\dict\\sweeng.lis";
            Console.WriteLine("Welcome to the dictionary app!");
            do
            {
                Console.Write("> ");
                string[] argument = Console.ReadLine().Split();
                string command = argument[0];
                if (command == "quit")
                {
                    Console.WriteLine("Goodbye!"); // FIXME: programmet ska stängas
                }
                else if (command == "load")
                {
                    if(argument.Length == 2)
                    {
                        using (StreamReader sr = new StreamReader(argument[1]))
                        LoadList(sr);
                    }
                    else if(argument.Length == 1)
                    {
                        using (StreamReader sr = new StreamReader(defaultFile))
                        LoadList(sr);
                    }
                }
                else if (command == "list")
                {
                    List();
                }
                else if (command == "new")
                {
                    if (argument.Length == 3)
                    {
                        dictionary.Add(new SweEngGloss(argument[1], argument[2]));
                    }
                    else if(argument.Length == 1)
                    {
                        Console.WriteLine("Write word in Swedish: ");
                        string sweNew = Console.ReadLine();
                        Console.Write("Write word in English: ");
                        string engNew = Console.ReadLine();
                        dictionary.Add(new SweEngGloss(sweNew, engNew));
                    }
                }
                else DeleteGloss(argument, command);
            }
            while (true);
        }

        private static void DeleteGloss(string[] argument, string command)
        {
            if (command == "delete")
            {
                if (argument.Length == 3)
                {
                    int index = -1;
                    for (int i = 0; i < dictionary.Count; i++)
                    {
                        SweEngGloss gloss = dictionary[i];
                        if (gloss.word_swe == argument[1] && gloss.word_eng == argument[2])
                            index = i;
                    }
                    dictionary.RemoveAt(index);
                }
                else if (argument.Length == 1)
                {
                    Console.WriteLine("Write word in Swedish: ");
                    string sweNew = Console.ReadLine();
                    Console.Write("Write word in English: ");
                    string engNew = Console.ReadLine();
                    int index = -1;
                    for (int i = 0; i < dictionary.Count; i++)
                    {
                        SweEngGloss gloss = dictionary[i];
                        if (gloss.word_swe == sweNew && gloss.word_eng == engNew)
                            index = i;
                    }
                    dictionary.RemoveAt(index);
                }
            }
            else if (command == "translate")
            {
                if (argument.Length == 2)
                {
                    foreach (SweEngGloss gloss in dictionary)
                    {
                        WordTranslate();
                    }
                }
                else if (argument.Length == 1)
                {
                    Console.WriteLine("Write word to be translated: ");
                    WordTranslate();
                }
            }
            else
            {
                Console.WriteLine($"Unknown command: '{command}'");
            }
        }

        private static void WordTranslate()
        {
            string sweNew = Console.ReadLine();
            string engNew = Console.ReadLine();
            foreach (SweEngGloss gloss in dictionary)
            {
                if (gloss.word_swe == sweNew)
                    Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                if (gloss.word_eng == engNew)
                    Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
            }
        }
        static void LoadList(StreamReader sr)
        {
            dictionary = new List<SweEngGloss>(); // Empty it!
            string line = sr.ReadLine();
            while (line != null)
            {
                SweEngGloss gloss = new(line);
                dictionary.Add(gloss);
                line = sr.ReadLine();
            }
        }
        static void List()
        {
            foreach (SweEngGloss gloss in dictionary)
            {
                Console.WriteLine($"{gloss.word_swe,-10}  - {gloss.word_eng,-10}");
            }
        }
        private static void DeleteGloss(string[] argument)
        {
            if (argument.Length == 3)
            {
                int index = -1;
                for (int i = 0; i < dictionary.Count; i++)
                {
                    SweEngGloss gloss = dictionary[i];
                    if (gloss.word_swe == argument[1] && gloss.word_eng == argument[2])
                        index = i;
                }
                dictionary.RemoveAt(index);
            }
            else if (argument.Length == 1)
            {
                Console.WriteLine("Write word in Swedish: ");
                string sweNew = Console.ReadLine();
                Console.Write("Write word in English: ");
                string engNew = Console.ReadLine();
                int index = -1;
                for (int i = 0; i < dictionary.Count; i++)
                {
                    SweEngGloss gloss = dictionary[i];
                    if (gloss.word_swe == sweNew && gloss.word_eng == engNew)
                        index = i;
                }
                dictionary.RemoveAt(index);
            }
        }
    }
}
