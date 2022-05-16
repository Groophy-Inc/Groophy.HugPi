## HugPi

[![NuGet version (Groophy.HugPi)](https://img.shields.io/nuget/v/Groophy.HugPi.svg?style=flat-square)](https://www.nuget.org/packages/Groophy.HugPi/)

[Source Code](https://github.com/Groophy-Inc/Groophy.HugPi/blob/main/hugging_api/HugPi.cs)

# Usage

```
Install-Package HugPi -Version 1.0.0
```

```cs
using hugging_api;
```

download webdriver who is your chrome version.
https://chromedriver.storage.googleapis.com/index.html
<br>

---
Create an instance

![spt](https://user-images.githubusercontent.com/77299279/168550591-e0c829f4-34ce-4226-9a4c-8103e1969f34.png)
```cs
//public HugPi(string DriverPATH,string api = "facebook/blenderbot-400M-distill")

HugPi hug = new HugPi(@"C:\Users\GROOPHY\Desktop\desktop\Apps", "facebook/blenderbot-400M-distill");
```

Start asking to ai
```cs
Console.WriteLine("AI: " + hug.Ask("How are you?"));
```

at the end, don't forget kill or windows will can not close.
```cs
hug.Kill();
```

if you want to be sure about close all
```cs
HugPi.KillAllProcess();
```

---

## sample

```cs
            HugPi hug = new HugPi(@"C:\Users\GROOPHY\Desktop\desktop\Apps");

            Console.Clear();

            while (true)
            {
                Console.Write("You: ");

                string input = Console.ReadLine();

                if (input == "quit")
                {
                    break;
                }

                Console.WriteLine("AI: " + hug.Ask(input));
            }

            hug.Kill();
```
![assd](https://user-images.githubusercontent.com/77299279/168552347-003cc3b0-5b10-449a-acc4-edf781441d2e.png)
