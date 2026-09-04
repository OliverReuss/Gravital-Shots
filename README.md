# Gravital Shots

Space shooter demo for PC — featuring a menu, 3 stages, varied enemy AI, power-ups, score tracking, and win/lose screens.

> **In short:** A small learning project built with Unity (URP, Shader Graph, Input System).

---

## Features

* **Menu + Stage Selection**
* **3 Game Stages** with distinct enemy logic
* **Shooting Mechanics, Power-Ups, and Particle Effects**
* **Audio + UI (UGUI) + TextMesh Pro**

---

## Prerequisites

* **Unity:** `2022.3.45f1 (LTS)`
* **OS:** Windows / Linux / macOS — Editor via Unity Hub
* **Recommended Packages:** Universal RP, TextMeshPro, Input System

---

## Quickstart (Editor)

1. **Unity Hub** → *Add* → Select the project folder.
2. **Open Project** (`Unity 2022.3.45f1`).
3. **Open Scene:** `Stage1.unity` (or `Menu`).
4. Press **Play**.

### Build (Windows)

1. **File** → **Build Settings** → Verify *Scenes in Build*.
2. **Platform** → *PC, Mac & Linux Standalone* → **Build**.
3. Run the executable output.

---

## Controls

| Action | Input |
| --- | --- |
| **Movement** | `WASD` / Gamepad (Input System) |
| **Fire** | Left Mouse Button / Trigger |
| **Pause** | `Esc` |

---

## Architecture (Overview)

* `GameController` — Stage management & enemy count
* `MovementController` — Player input + shooting
* `ShotScript` — Bullet behavior & collision
* `StageXEnemyScript` — Enemy AI per stage

*(Implementing a simple `IEnemy` interface is recommended; see `CONTRIBUTING`)*

---

## Screenshots

*(Replace with your own images / GIFs in `docs/`)*

---

## Known Issues

* Some script files have a file name to class name mismatch (see Code Quality).
* `HitRecieved` is misspelled — will be fixed in future commits.

---

## Contributing

Open issues or simple PRs are welcome (see `CONTRIBUTING.md`).

---

## License

[MIT](https://www.google.com/search?q=LICENSE) — see `LICENSE`

---

## Contact / Credits

* **Author:** Your Name — [Link to GitHub Profile](https://github.com)
* **Asset Credits:** *(3D Models, Sounds — list sources here)*
