# Gravital Shots

![Unity 2022.3.45f1](https://img.shields.io/badge/unity-2022.3.45f1-blue)
![License: MIT](https://img.shields.io/badge/license-MIT-lightgrey)
[![Play on itch.io](https://img.shields.io/badge/Play%20on-itch.io-red)](https://deltaforcer1.itch.io/gravital-shots)

Space shooter demo featuring planetary gravity mechanics. Navigate your spaceship around geometric celestial bodies across 3 stages with unique enemy AI, power-ups, score tracking, and win/lose screens.

> **About this project:** Developed as a group project during a semester abroad in the **Computer Games Development** program in Ireland. Originally developed for PC, the project has been adapted and deployed as a **WebGL build hosted on itch.io**. Built with Unity (URP, Shader Graph, Input System).

---

## Key Gameplay Concept

Unlike traditional top-down or linear space shooters, **Gravital Shots** incorporates spherical and geometric gravity fields. Your spaceship orbits and navigates around geometric planetoids, requiring you to adapt your movement and aiming around 3D curved surfaces.

---

## Features

* **Gravity-Based Movement:** Control your spaceship around geometric 3D shapes with dynamic surface gravity.
* **3 Game Stages:** Features distinct enemy behavior and AI patterns per stage.
* **Shooting & Upgrades:** Fluid shooting mechanics, power-ups, and custom particle effects.
* **Audio & Interface:** Full UI powered by TextMesh Pro and integrated sound effects.

---

## Play Online / Builds

* **Browser (WebGL):** Play directly on [itch.io](https://deltaforcer1.itch.io/gravital-shots) *(adapted via CI/CD deployment)*.
* **PC Standalone:** Download or build locally for Windows / Linux / macOS.

---

## Prerequisites (Editor Setup)

* **Unity:** `2022.3.45f1 (LTS)`
* **OS:** Windows / Linux / macOS — Editor via Unity Hub
* **Recommended Packages:** Universal RP, TextMeshPro, Input System

---

## Quickstart (Editor)

1. **Unity Hub** → *Add* → Select the project folder.
2. **Open Project** (`Unity 2022.3.45f1`).
3. **Open Scene:** `Stage1.unity` (or `Menu`).
4. Press **Play**.

### Local Build (PC Standalone)

1. **File** → **Build Settings** → Verify *Scenes in Build*.
2. **Platform** → *PC, Mac & Linux Standalone* → **Build**.
3. Run the executable output.

---

## Controls

| Action | Input |
| :--- | :--- |
| **Movement** | `WASD` / Gamepad (Input System) |
| **Fire** | Left Mouse Button / Trigger |
| **Pause** | `Esc` |

---

## Architecture (Overview)

* `GameController` — Stage management & enemy tracking
* `MovementController` — Player input, gravity orientation & shooting
* `ShotScript` — Bullet behavior & collision detection
* `StageXEnemyScript` — Stage-specific enemy AI logic

---

## Screenshots

![Gameplay](docs/gameplay.png)
![Menu](docs/menu.png)

---

## License

[MIT](LICENSE) — see `LICENSE` for details.

---

## Contact / Credits

* **Author:** [Oliver Reuß](https://github.com/OliverReuss)
* **Academic Context:** Developed as a group project during an Erasmus+ semester abroad in Games Development (Ireland).
