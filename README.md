# Gravital Shots

![Unity 2022.3.45f1](https://img.shields.io/badge/unity-2022.3.45f1-blue)
![License: MIT](https://img.shields.io/badge/license-MIT-lightgrey)
[![Play on itch.io](https://img.shields.io/badge/Play%20on-itch.io-red)](https://deltaforcer1.itch.io/gravital-shots)
[![View on GitHub](https://img.shields.io/badge/View%20on-GitHub-black?logo=github)](https://github.com/OliverReuss/Gravital-Shots)

Gravital Shots is a short space shooter demo built around planetary gravity. Instead of flying across a flat plane, you navigate your ship around curved, geometric planetoids. The demo includes three stages with different enemy types, a power-up system, and score tracking.

> Built in Unity (URP, Shader Graph, new Input System) as a student group project during my Erasmus semester at SETU Ireland. I recently adapted the original PC version into a WebGL build so it can be played directly in the browser on itch.io.

---

## The Core Mechanic

Traditional top-down shooters operate on a flat 2D grid. In this project, movement is entirely tied to spherical and geometric gravity fields. You have to constantly adapt your aiming and dodging to the 3D curvature of the current object you are orbiting. 

---

## Features

* **Dynamic Surface Gravity:** Custom movement logic that keeps the player anchored to various 3D shapes.
* **Three Stages:** Escalating difficulty with different enemy AI behaviors.
* **Combat System:** Mouse-aimed shooting, custom particle effects, and item drops.
* **UI and Polish:** A complete game loop (menus, win/lose states, scoring) built with TextMesh Pro, alongside integrated audio.

---

## Play the Game

* **Browser (WebGL):** Play it directly on itch.io
* **PC Standalone:** Clone the repo and build it locally for Windows, Linux, or macOS.

---

## Controls

| Action | Input |
| :--- | :--- |
| **Move** | `W`, `A`, `S`, `D` |
| **Aim** | Mouse cursor |
| **Shoot** | Left Mouse Button |
| **Pause** | `Esc` |

Use WASD to steer along the planet's surface, aim with your mouse, and click to shoot. Hit Esc at any time to pause.

---

## Screenshots

<div align="center">
  <img src="Assets/Resources/Project%20Logo.png" width="200" alt="Gravital Shots Logo">
</div>

<div align="center">
  <img src="docs/menu.png" width="600" alt="Menu">
</div>

<div align="center">
  <img src="docs/stage_1.png" width="600" alt="Gameplay - Stage 1">
  <img src="docs/stage_2.png" width="600" alt="Gameplay - Stage 2">
</div>

<div align="center">
  <img src="docs/stage_3.png" width="600" alt="Gameplay - Stage 3">
</div>

<div align="center">
  <img src="docs/instructions.png" width="600" alt="Instructions">
</div>

---

## License

MIT

---

## Credits

* **Author:** Oliver Reuß
* **Developers:** Oliver Reuß, Jonathan Dellenbach, Daniel Algandro Mendioza Sermont
* **Academic Context:** Created during the 2024/25 winter semester for the 3D Graphics course (Computer Games Development B.Sc. Hons) during an Erasmus+ stay in Carlow, Ireland.
