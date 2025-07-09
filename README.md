# Viscerality Spotify Patcher

**Join our Discord for support and updates:** [https://discord.gg/gFpmqJCt](https://discord.gg/gFpmqJCt)

---

This tool patches the Spotify client by replacing specific DLLs in the `%AppData%\Spotify` directory to disable advertisements.

---

## ⚠️ About Safety & Misconceptions

If you have **any doubts or suspicions**, feel free to upload the executable to [VirusTotal](https://www.virustotal.com/) or inspect the source code yourself. This project is **not a RAT**, trojan, or malicious in any way.

The term "**RAT**" is often misused to describe suspicious tools without understanding their function. This software does **not** provide remote access, steal data, or perform any background actions. It simply modifies Spotify's local configuration to disable ads.

- **Fully open source.** You can open the project in Visual Studio and inspect every line of code.
- **No network communication.** The tool does not connect to the internet.
- **No persistence.** It doesn't alter system registry or install startup services.
- **Only patches local files** (`dpapi.dll` and `config.ini`) inside Spotify's directory.

---

## 💡 Credit & Respect

If you use or modify this project, **please keep this notice intact** and give credit to the original author. It helps support the community and maintains transparency.

---

## ✅ Requirements

- Windows OS
- Spotify installed via official installer

---

## 📦 How It Works

1. Detects if Spotify is running and prompts you to close it.
2. Replaces `dpapi.dll` and `config.ini` in the Spotify folder with patched versions.
3. Spotify runs normally but with advertisements disabled.

---

## ⚙️ Build & Usage

Open the project in Visual Studio, build the executable, and run it with administrator privileges if needed. Always close Spotify before patching or unpatching.

---

## 📞 Support & Community

Join our Discord server for support, bug reports, and updates:

[https://discord.gg/gFpmqJCt](https://discord.gg/gFpmqJCt)

---

## 📝 License

This project is licensed under the MIT License — see the [LICENSE](LICENSE.txt) file for details.

---

**Happy listening!**
